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

namespace AAE2023_Music_Player
{
    public partial class musicPlayerForm : Form
    {
        private Control[] soundcontrols;
        private List<Track> tracks = new List<Track>();
        private const string connectionString = "Data Source=Music.db;Version=3;";
        private int _trackCounter;
        private Track currentTrack, nextTrack, prevTrack;

        public musicPlayerForm()
        {
            InitializeComponent();
            soundcontrols = new Control[]
            {
                buttonPlay,
                buttonNext,
                buttonPrev,
                trackBarPlayer,
                trackBarVolume,
                labelStart,
                labelFinish
            };
            LockSoundControls(soundcontrols);
            buttonPlay.Enabled = true;
            getAllTracks(ref tracks, ref _trackCounter);
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

        public static void LockSoundControls(Control[] soundcontrols)
        {
            foreach (var t in soundcontrols)
            {
                ((Control)t).Enabled = false;
            }
        }

        public static void UnlockSoundControls(Control[] soundcontrols)
        {
            foreach (var t in soundcontrols)
            {
                ((Control)t).Enabled = true;
            }
        }

        public static void getAllTracks(ref List<Track> tracks, ref int counter)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
        private async Task Play(byte[] music)
        {
            try
            {
                using (var stream = new MemoryStream(music))
                using (var mp3Reader = new Mp3FileReader(stream))
                using (var waveOut = new WaveOutEvent())
                {
                    waveOut.Init(mp3Reader);
                    waveOut.Play();
                    while (waveOut.PlaybackState == PlaybackState.Playing)
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
            // search for the track from the List of tracks using the Levenshtein distance algorithm

            foreach (Track t in tracks)
            {
                if (StringDistance(t.Title, term) <= 2)
                {
                    // to be implemented with reactive UI
                }
            }
        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {
            addForm addForm = new addForm();
            addForm.Show();
            addForm.FormClosed += (s, args) =>
            {
                tracks.Clear();
                getAllTracks(ref tracks, ref _trackCounter);
            };
        }

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            // play a track from db
            foreach (Track t in tracks)
            {
                await Play(t.MusicFile);
            }
        }

        private async void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            await Search(textBoxTitle.Text);
        }
    }
}
