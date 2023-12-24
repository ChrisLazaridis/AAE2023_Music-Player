using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AAE2023_Music_Player
{
    public partial class musicPlayerForm : Form
    {
        // vars and objects
        
        private Control[] soundcontrols;
        private List<Track> tracks = new();
        private List<Track> favorites = new();
        private DbConnection dBConnection = new("Music.db");
        private Track currentTrack,nextTrack, prevTrack;
        private WaveOut player = new();
        private LevenshteinDistance stringChecker = new();
        private bool TrackBarChanging, repeat;
        private bool trackFavs = true;
        
        // constructor(ας)
        
        public musicPlayerForm()
        {
            InitializeComponent();
            // sound controls start as locked, and they become unlocked when the user selects a track
            soundcontrols =
            [
                buttonPlay,
                buttonNext,
                buttonPrev,
                trackBarPlayer,
                trackBarVolume,
                buttonShuffle,
                buttonRepeat
            ];
            GetAllTracks(ref tracks);
            // set the volume of the player to the value of the trackBar for volume
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
        }
        
        // Created methods
        

        public static void UnlockSoundControls(Control[] soundcontrols)
        {
            foreach (Control t in soundcontrols)
            {
                t.Enabled = true;
            }
        }

        public void DisplaySongInformation(List<Track> tracks)
        {
            // here lie my hopes for a readable custom interactive UI
            int verticalGap = 20;

            flowLayoutPanelTrackList.Controls.Clear();

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
                yearLabel.Text = "Year: " + track.Year;
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

        public void DisplayFavorites(List<Track> favs)
        {
            // here lie my hopes for a readable custom interactive UI vol. 2
            int verticalGap = 20;
            flowLayoutPanelFavorites.Controls.Clear();

            foreach (Track track in favs)
            {
                // Song title
                Label titleLabel = new Label();
                titleLabel.Text = track.Title;
                titleLabel.AutoSize = true;
                titleLabel.Font = new Font("Arial", 12, FontStyle.Bold);

                // Artist
                Label artistLabel = new Label();
                artistLabel.Text = "By " + track.Artist;
                artistLabel.AutoSize = true;
                artistLabel.Font = new Font("Arial", 10);

                // Button
                Button songButton = new Button();
                songButton.AutoSize = true;
                songButton.BackColor = Color.Black;
                songButton.Image = Properties.Resources.next;
                songButton.Click += songButton_Click;
                songButton.Name = track.Title;

                // delete button
                Button deleteButton = new Button();
                deleteButton.AutoSize = true;
                deleteButton.BackColor = Color.Black;
                deleteButton.Image = Properties.Resources.delete;
                deleteButton.Click += deleteButton_Click;
                deleteButton.Name = track.Title;

                // Add controls to the FlowLayoutPanel
                flowLayoutPanelFavorites.Controls.Add(titleLabel);
                flowLayoutPanelFavorites.Controls.Add(artistLabel);
                flowLayoutPanelFavorites.Controls.Add(songButton);
                flowLayoutPanelFavorites.Controls.Add(deleteButton);
                
                // Add spacing
                flowLayoutPanelFavorites.Controls.Add(new Label() { Text = "", Height = verticalGap });
            }
        }
        public void GetAllTracks(ref List<Track> tracks)
        {
            try
            {
                int TrackCounter = 0;
                // αν κάποιος δεν έχει ξαναδεί using, στο τέλος του block κάνει dispose το object που έφτιαξε
                using (SQLiteConnection connection = new SQLiteConnection(dBConnection.ConnectionString))
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
                                    (byte[])reader.GetValue(5),
                                    (byte[])reader.GetValue(6)
                                ));
                                TrackCounter++;
                            }
                        }
                    }
                }
                DisplaySongInformation(tracks);
                labelNumOfSongs.Text = $"Found Tracks: {TrackCounter}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error");
            }
        }
        private async Task Play(Track music, int startPositionInSeconds)
        {
            try
            {
                labelName.Text = music.Title;

                using (var stream = new MemoryStream(music.MusicFile))
                using (var mp3Reader = new Mp3FileReader(stream))
                {
                    // set the player to read from the position of the trackBar, or from the beginning when appropriate
                    var offsetSampleProvider = new OffsetSampleProvider(mp3Reader.ToSampleProvider())
                    {
                        SkipOver = TimeSpan.FromSeconds(startPositionInSeconds)
                    };
                    // initialize the player and begin playback
                    player.Init(new SampleToWaveProvider(offsetSampleProvider));
                    player.Play();
                    // initialize the trackBar and the timer used to update the trackbar on tick (invoke used to use the UI thread for the operation)
                    Invoke((MethodInvoker)delegate
                    {
                        trackBarPlayer.Maximum = (int)mp3Reader.TotalTime.TotalSeconds;
                        trackBarPlayer.Value = startPositionInSeconds;
                        labelFinish.Text = mp3Reader.TotalTime.ToString(@"mm\:ss");
                        timerUpdater.Start();
                    });

                    // do not exit this block while the playback is happening
                    while (player.PlaybackState == PlaybackState.Playing)
                    {
                        await Task.Delay(100); // this is async in order to not block the UI thread, the delay is in order to not perform checks every ms, instead every 100ms 
                                               // imo the max acceptable delay in order for the app to not feel unresponsive
                    }
                }
                // stop the timer when the track has finished
                timerUpdater.Stop();
                // if the track has finished and repeat is on, play the track again
                if (labelStart.Text == labelFinish.Text && repeat)
                {
                    await Play(currentTrack, 0);
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
            int counter = 0;
            // performing search, using the LevenshteinDistance class, asynchronously
            await Task.Run(() =>
            {
                List<Track> found = new List<Track>();
                // loop through the tracks and add the ones that match the search term to the found list
                foreach (Track t in tracks)
                {
                    if (stringChecker.Calculate(t.Title, term) <= 6)
                    {
                        found.Add(t);
                        counter++;
                    }
                }
                Invoke((MethodInvoker)delegate
                {
                    DisplaySongInformation(found);
                    labelNumOfSongs.Text = $"Found Tracks: {counter}";
                });
            });
        }
        
        // Events

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string title = button.Name;
            // iterate over the list of favorites and remove the one that matches the title of the button that was clicked
            for (int i = favorites.Count - 1; i >= 0; i--)
            {
                if (favorites[i].Title == title)
                {
                    favorites.RemoveAt(i);
                    break;
                }
            }

            DisplayFavorites(favorites);
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            // this is used to clear up search results and display every song again
            DisplaySongInformation(tracks);
        }

        private async void songButton_Click(object sender, EventArgs e)
        {

            if (soundcontrols[0].Enabled == false)
            {
                UnlockSoundControls(soundcontrols);
            }
            // get the title of the button that was clicked
            Button button = (Button)sender;
            string title = button.Name;
            // if this is not the first time a song is played, set the previous track to the current track and stop the player
            if (currentTrack != null)
            {
                prevTrack = currentTrack;
                player.Stop();
            }
            // iterate over the list of tracks and find the one that matches the title of the button that was clicked
            foreach (Track t in tracks)
            {
                if (t.Title == title)
                {
                    currentTrack = t;
                    // check if the track is already in the favorites list, if not add it
                    bool isFav = false;
                    foreach (Track f in favorites)
                    {
                        if (f.Id == currentTrack.Id)
                        {
                            isFav = true;
                        }
                    }
                    if (!isFav && trackFavs)
                    {
                        favorites.Add(currentTrack);
                        DisplayFavorites(favorites);
                    }
                    // set the next track to the next track in the original track list (if it exists
                    foreach (Track n in tracks)
                    {
                        if (n.Id == currentTrack.Id + 1)
                        {
                            nextTrack = n;
                        }
                    }
                    // finally play the Track
                    await Play(t, 0);
                    break;
                }
            }
        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {
            // open the addForm and when it closes refresh the list of tracks
            addForm addForm = new addForm();
            addForm.Show();
            addForm.FormClosed += (s, args) =>
            {
                tracks.Clear();
                GetAllTracks(ref tracks);
                Refresh();
            };
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // clicking this button will delete the current track from the database and refresh the list of tracks, as well as the UI
            if (currentTrack != null)
            {
                try
                {
                    player.Stop();
                    using (SQLiteConnection connection = new SQLiteConnection(dBConnection.ConnectionString))
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
                    GetAllTracks(ref tracks);
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // open the editForm, with the current track and when it closes refresh the list of tracks
            if (currentTrack != null)
            {
                editForm editForm = new editForm(currentTrack);
                editForm.Show();
                editForm.FormClosed += (s, args) =>
                {
                    tracks.Clear();
                    GetAllTracks(ref tracks);
                    Refresh();
                };
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            // set the volume of the player to the value of the trackBar for volume
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
        }

        private async void buttonShuffle_Click(object sender, EventArgs e)
        {
            // stop the player, choose a random track from the list and play it
            player.Stop();
            Random random = new Random();
            int index = random.Next(0, tracks.Count);
            prevTrack = currentTrack;
            currentTrack = tracks[index];
            await Play(currentTrack, 0);
        }

        private void timerUpdater_Tick(object sender, EventArgs e)
        {
            // on tick, update the trackBar and the labels that show the current position of the track
            if (trackBarPlayer.Value < trackBarPlayer.Maximum)
            {
                trackBarPlayer.Value++;
                labelStart.Text = TimeSpan.FromSeconds(trackBarPlayer.Value).ToString(@"mm\:ss");
            }
                
        }

        private async void buttonPrev_Click(object sender, EventArgs e)
        {
            if (buttonPrev.Enabled)
            {
                if (prevTrack != null)
                {
                    nextTrack = currentTrack;
                    player.Stop();
                    currentTrack = prevTrack;
                    prevTrack = null;
                    await Play(currentTrack, 0);
                }
            }
        }

        private void trackBarPlayer_MouseDown(object sender, MouseEventArgs e)
        {
            // flag that indicates the user is dragging the trackBar
            TrackBarChanging = true;
        }

        private async void trackBarPlayer_MouseUp(object sender, MouseEventArgs e)
        {
            if (TrackBarChanging)
            {
                // go to the trackBar's position in the player
                player.Stop();
                await Play(currentTrack, trackBarPlayer.Value);
                TrackBarChanging = false;
            }
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            if (repeat)
            {
                // flag that indicates the user does not want to repeat the current track
                repeat = false;
                labelRepeat.Text = "Repeat: Off";
            }
            else
            {
                // flag that indicates the user wants to repeat the current track
                repeat = true;
                labelRepeat.Text = "Repeat: On";
            }
        }

        private void titleToolStripShortByTitle_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by title (alphabetically)
            tracks.Sort((x, y) => string.Compare(x.Title, y.Title));
            DisplaySongInformation(tracks);
        }
        private void titleToolStripShortByArtist_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by artist (alphabetically)
            tracks.Sort((x, y) => string.Compare(x.Artist, y.Artist));
            DisplaySongInformation(tracks);
        }

        private void titleToolStripShortByYearAsc_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by year (ascending)
            tracks.Sort((x, y) => x.Year.CompareTo(y.Year));
            DisplaySongInformation(tracks);
        }
        private void titleToolStripShortByYearDes_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by year (descending)
            tracks.Sort((x, y) => y.Year.CompareTo(x.Year));
            DisplaySongInformation(tracks);
        }

        private void titleToolStripShortByGenre_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by genre (alphabetically)
            tracks.Sort((x, y) => string.Compare(x.Genre, y.Genre));
            DisplaySongInformation(tracks);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message =
                "This is one of the three final projects for the subject of Object-Oriented Programming Application Development for the year 2023. " +
                "The year 2023 and the students with IDs:\n\n" +
                "P22083\n\n" +
                "P22007\n\n" +
                "P22010\n\n" +
                "It consists of a media player, created using standard form controls and the NAudio.Wave library. \n\n" +
                "The user can add a track, delete, or edit the track that is currently playing by clicking the buttons at the top left.\n\n " +
                "For the addition and editing of tracks, two new forms have been implemented.\n\n " +
                "The user can also sort the track list by title, artist name, year, genre, and search in the tracklist using the search field and Player menu strip.\n\n " +
                "For the search implementation, the Levenshtein string distance algorithm has been used.\n\n " +
                "The tracks the user listens to will be added to favorites. The user can choose to delete them from there if he desires to or disable favorite tracking. \n\n" +
                "The user can add his own images to the tracks or choose to add the generic image by not selecting a file. \n\n" +
                "The player can only play tracks stored as blobs in the local SQLite database.";
            MessageBox.Show(message, "Info");
        }

        private void buttonTrackFavorites_Click(object sender, EventArgs e)
        {
            trackFavs = !trackFavs;
            if (trackFavs)
            {
                buttonTrackFavorites.Text = "Tracking Favorites";
            }
            else
            {
                buttonTrackFavorites.Text = "Track Favorites";
                flowLayoutPanelFavorites.Controls.Clear();
                favorites.Clear();
            }
        }

        private async void richTextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            // when the text in the search bar changes, perform a search
            await Search(richTextBoxTitle.Text);
        }
        

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            // this button is used to play and pause the current track
            if (buttonPlay.Enabled == true)
            {
                switch (player.PlaybackState)
                {
                    case PlaybackState.Playing:
                    {
                        player.Stop();
                        if (timerUpdater.Enabled)
                        {
                            timerUpdater.Stop();
                        }

                        break;
                    }
                    case PlaybackState.Stopped:
                        await Play(currentTrack, trackBarPlayer.Value);
                        break;
                }
            }
        }
        private async void buttonNext_Click(object sender, EventArgs e)
        {
            // play the next track in the list, if it exists
            if (buttonNext.Enabled)
            {
                if (nextTrack != null)
                {
                    prevTrack = currentTrack;
                    player.Stop();
                    bool isFav = false;
                    foreach (Track f in favorites)
                    {
                        if (f.Id == nextTrack.Id)
                        {
                            isFav = true;
                        }
                    }
                    // if the next track is not in the favorites list, add it
                    if (!isFav && trackFavs)
                    {
                        favorites.Add(nextTrack);
                        DisplayFavorites(favorites);
                    }
                    currentTrack = nextTrack;
                    // update the next track
                    foreach (Track n in tracks)
                    {
                        if (n.Id == currentTrack.Id + 1)
                        {
                            nextTrack = n;
                        }
                    }
                    await Play(currentTrack, 0);
                }
            }
        }
    }
}
