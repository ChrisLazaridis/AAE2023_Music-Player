using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace AAE2023_Music_Player
{
    public partial class musicPlayerForm : Form
    {
        private Control[] soundcontrols;
        private List<Track> tracks = new List<Track>();
        private List<Track> favorites = new List<Track>();
        private const string connectionString = "Data Source=Music.db;Version=3;";
        private int trackCounter;
        private Track currentTrack,nextTrack, prevTrack;
        private WaveOut player = new WaveOut();
        private bool isDragging;

        public musicPlayerForm()
        {
            InitializeComponent();
            soundcontrols =
            [
                buttonPlay,
                buttonNext,
                buttonPrev,
                trackBarPlayer,
                trackBarVolume,
                labelStart,
                labelFinish
            ];
            LockSoundControls(soundcontrols);
            getAllTracks(ref tracks, ref trackCounter);
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
        }
        // Used functions for various tasks
        private static int StringDistance(string s1, string s2)
        {
            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }

        public void LockSoundControls(Control[] soundcontrols)
        {
            foreach (var t in soundcontrols)
            {
                ((Control)t).Enabled = false;
            }
        }

        public void UnlockSoundControls(Control[] soundcontrols)
        {
            foreach (var t in soundcontrols)
            {
                ((Control)t).Enabled = true;
            }
        }

        public void DisplaySongInformation(List<Track> tracks)
        {
            int verticalGap = 20;

            foreach (Track track in tracks)
            {
                // Song title
                Label titleLabel = new Label();
                titleLabel.Text = track.Title;
                titleLabel.AutoSize = true;
                titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);

                // Artist
                Label artistLabel = new Label();
                artistLabel.Text = "Artist: " + track.Artist;
                artistLabel.AutoSize = true;
                artistLabel.Font = new Font("Arial", 10);

                // Genre
                Label genreLabel = new Label();
                genreLabel.Text = "Genre: " + track.Genre;
                genreLabel.AutoSize = true;
                genreLabel.Font = new Font("Arial", 10);

                // Year
                Label yearLabel = new Label();
                yearLabel.Text = "Year: " + track.Year.ToString();
                yearLabel.AutoSize = true;
                yearLabel.Font = new Font("Arial", 10);

                // Cover Image
                PictureBox imagePictureBox = new PictureBox();
                imagePictureBox.Image = Image.FromStream(new MemoryStream(track.Image));
                imagePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imagePictureBox.Size = new Size(60, 60);

                // Button
                Button songButton = new Button();
                songButton.AutoSize = true;
                songButton.BackColor = Color.Black;
                songButton.Image = Properties.Resources.next;
                songButton.Click += songButton_Click;
                songButton.Name = track.Title;

                // Add controls to the FlowLayoutPanel
                flowLayoutPanelTrackList.Controls.Add(titleLabel);
                flowLayoutPanelTrackList.Controls.Add(artistLabel);
                flowLayoutPanelTrackList.Controls.Add(genreLabel);
                flowLayoutPanelTrackList.Controls.Add(yearLabel);
                flowLayoutPanelTrackList.Controls.Add(imagePictureBox);
                flowLayoutPanelTrackList.Controls.Add(songButton);

                // Add spacing
                flowLayoutPanelTrackList.Controls.Add(new Label() { Text = "", Height = verticalGap });
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanelTrackList.Controls.Clear();
            DisplaySongInformation(tracks);
        }

        private async void songButton_Click(object sender, EventArgs e)
        {

            UnlockSoundControls(soundcontrols);
            Button button = (Button)sender;
            string title = button.Name;
            if (currentTrack != null)
            {
                prevTrack = currentTrack;
                player.Stop();
                favorites.Add(currentTrack);
            }
            foreach (Track t in tracks)
            {
                if (t.Title == title)
                {
                    currentTrack = t;
                    favorites.Add(currentTrack);
                    await Play(t);
                }
            }
        }
        public void getAllTracks(ref List<Track> tracks, ref int counter)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Tracks", connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tracks.Add(new Track(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetInt32(4),
                                    reader.GetInt32(5),
                                    (byte[])reader.GetValue(6),
                                    (byte[])reader.GetValue(7)
                                ));
                                counter++;
                            }
                        }
                    }
                }
                DisplaySongInformation(tracks);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
        private async Task Play(Track music)
        {
            try
            {
                using (var stream = new MemoryStream(music.MusicFile))
                using (var mp3Reader = new Mp3FileReader(stream))
                {
                    player.Init(mp3Reader);
                    player.Play();
                    while (player.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing MP3: {ex.Message}");
            }
        }

        private async Task Search(string term)
        {
            flowLayoutPanelTrackList.Controls.Clear();
            await Task.Run(() =>
            {
                List<Track> found = new List<Track>();
                foreach (Track t in tracks)
                {
                    if (StringDistance(t.Title, term) <= 6)
                    {
                        found.Add(t);
                    }
                }
                this.Invoke((MethodInvoker)delegate
                {
                    DisplaySongInformation(found);
                });
            });
        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {
            addForm addForm = new addForm();
            addForm.Show();
            addForm.FormClosed += (s, args) =>
            {
                tracks.Clear();
                getAllTracks(ref tracks, ref trackCounter);
            };
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentTrack != null)
            {
                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command =
                               new SQLiteCommand("DELETE FROM Tracks WHERE Id = @id", connection))
                        {
                            command.Parameters.AddWithValue("@id", currentTrack.Id);
                            command.ExecuteNonQuery();
                        }
                    }

                    tracks.Clear();
                    getAllTracks(ref tracks, ref trackCounter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (currentTrack != null)
            {
                editForm editForm = new editForm(currentTrack);
                editForm.Show();
                editForm.FormClosed += (s, args) =>
                {
                    tracks.Clear();
                    getAllTracks(ref tracks, ref trackCounter);
                };
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (player.PlaybackState == PlaybackState.Playing)
            {
                player.Pause();
            }
            else if (player.PlaybackState == PlaybackState.Paused)
            {
                player.Play();
            }
        }

        private async void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            await Search(textBoxTitle.Text);
        }
    }
}
