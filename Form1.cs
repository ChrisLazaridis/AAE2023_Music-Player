using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AAE2023_Music_Player.Properties;
using Microsoft.VisualBasic.FileIO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Newtonsoft.Json;

namespace AAE2023_Music_Player
{
    public partial class musicPlayerForm : Form
    {
        // vars and objects

        private Control[] soundcontrols;
        private User[] users;
        private User user;
        private List<Track> tracks = new();
        private List<Track> favorites = new();
        private List<Track> currentOrder = new List<Track>();
        private DbConnection dBConnection = new("Music.db");
        private Track currentTrack;
        private Track nextTrack;
        private Track prevTrack;
        private WaveOut player = new();
        private LevenshteinDistance stringChecker = new();
        private bool TrackBarChanging;
        private bool repeat;
        private bool trackFavs = true;
        private bool deleted;
        private bool random;
        private bool paused;

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
            // Call for the form4 to get the user list and the selected user, and wait here until the users logs in
            selectUserForm form4 = new selectUserForm();
            Enabled = false;

            form4.ShowDialog();
            form4.UserSelectionTaskCompletionSource.Task.ContinueWith(task =>
            {
                // Enable this form when the user selection is completed
                Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
            // wait for the user to log in and then get the user list and the selected user as properties of the form
            object u = form4.selectedUser;
            object u2 = form4.users;
            GetAllTracks(ref tracks);
            currentOrder.AddRange(tracks);
            // set the volume of the player to the value of the trackBar for volume
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
            user = (User)u;
            if (user.Favorites != null)
            {
                // add the favourite track of the user, if they exist in the track list
                foreach (Track t in user.Favorites)
                {
                    if (tracks.Any(track => track.Id == t.Id))
                    {
                        favorites.Add(tracks.First(track => track.Id == t.Id));
                    }
                }
            }
            DisplayFavorites(favorites);
            users = (User[])u2;

            Application.ApplicationExit += OnApplicationExit;
        }

        // Created methods


        public void UnlockSoundControls()
        {
            deleted = false;
            foreach (Control t in soundcontrols)
            {
                t.Enabled = true;
            }
        }

        public void LockSoundControls()
        {
            foreach (Control t in soundcontrols)
            {
                t.Enabled = false;
            }
        }
        private void StopPlayer()
        {
            prevTrack = currentTrack;
            player.Stop();
        }

        private void AddToFavoriteIfNeeded(Track track)
        {
            if (trackFavs && !favorites.Any(f => f.Id == track.Id))
            {
                favorites.Add(track);
                DisplayFavorites(favorites);
            }
        }

        private void SetPreviousAndNextTracks()
        {
            // get the index of the current track in the list of tracks and set the previous and next tracks accordingly
            int currentIndex = currentOrder.IndexOf(currentTrack);
            int previousIndex = (currentIndex - 1 + currentOrder.Count) % currentOrder.Count;
            int nextIndex = (currentIndex + 1) % currentOrder.Count;

            prevTrack = currentOrder[previousIndex];
            nextTrack = currentOrder[nextIndex];
        }

        private async Task PlayPreviousTrack()
        {
            StopPlayer();
            if (repeat)
            {
                await Play(currentTrack, 0);
            }
            else if (random)
            {
                await PlayRandomTrack();
            }
            else
            {
                // get the index of the current track in the list of tracks and set the previous track to the one before it
                int currentIndex = currentOrder.IndexOf(currentTrack);
                int previousIndex = (currentIndex - 1 + currentOrder.Count) % currentOrder.Count;
                currentTrack = currentOrder[previousIndex];

                SetPreviousAndNextTracks();
                await Play(currentTrack, 0);
            }
        }

        private async Task PlayNextTrack()
        {
            StopPlayer();
            if (repeat)
            {
                await Play(currentTrack, 0);
            }
            else if (random)
            {
                await PlayRandomTrack();
            }
            else
            {
                currentTrack = nextTrack ?? currentOrder.First();
                SetPreviousAndNextTracks();
                await Play(currentTrack, 0);
            }
        }
        private async Task PlayRandomTrack()
        {
            // Πάρτα αρχίδια μ λάμπρο π θες και σχόλιο εδώ
            Random rnd = new Random();
            int randomTrackIndex = rnd.Next(0, tracks.Count);
            prevTrack = currentTrack;
            currentTrack = tracks[randomTrackIndex];
            SetPreviousAndNextTracks();
            await Play(currentTrack, 0);
        }

        private void DisplaySongInformation(List<Track> lt)
        {
            // here lie my hopes for a readable custom interactive UI
            int verticalGap = 20;

            flowLayoutPanelTrackList.Controls.Clear();

            foreach (Track track in lt)
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
                songButton.Image = Resources.next;
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
                flowLayoutPanelTrackList.Controls.Add(new Label { Text = "", Height = verticalGap });
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
                songButton.Image = Resources.next;
                songButton.Click += songButton_Click;
                songButton.Name = track.Title;

                // delete button
                Button deleteButton = new Button();
                deleteButton.AutoSize = true;
                deleteButton.BackColor = Color.Black;
                deleteButton.Image = Resources.delete;
                deleteButton.Click += deleteButton_Click;
                deleteButton.Name = track.Title;

                // Add controls to the FlowLayoutPanel
                flowLayoutPanelFavorites.Controls.Add(titleLabel);
                flowLayoutPanelFavorites.Controls.Add(artistLabel);
                flowLayoutPanelFavorites.Controls.Add(songButton);
                flowLayoutPanelFavorites.Controls.Add(deleteButton);

                // Add spacing
                flowLayoutPanelFavorites.Controls.Add(new Label { Text = "", Height = verticalGap });
            }
        }
        public void GetAllTracks(ref List<Track> lt)
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
                                lt.Add(new Track(
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
                DisplaySongInformation(lt);
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
                        await Task.Delay(
                            100); // this is async in order to not block the UI thread, the delay is in order to not perform checks every ms, instead every 100ms 
                        // imo the max acceptable delay in order for the app to not feel unresponsive
                    }
                }

                // stop the timer when the track has finished
                timerUpdater.Stop();
                // if the track has finished and repeat is on, play the track again
                if (!paused && !deleted)
                {
                    if (repeat)
                    {
                        await Play(currentTrack, 0);
                    }
                    else if (random)
                    {
                        await PlayRandomTrack();
                    }
                    else
                    {
                        await PlayNextTrack();
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
                UnlockSoundControls();
            }

            Button button = (Button)sender;
            string title = button.Name;

            // Stop the player if a track is already playing
            if (currentTrack != null)
            {
                StopPlayer();
            }

            // Find the selected track
            currentTrack = tracks.FirstOrDefault(t => t.Title == title);

            if (currentTrack != null)
            {
                // Add to favorites if necessary
                AddToFavoriteIfNeeded(currentTrack);

                // Set previous and next tracks
                SetPreviousAndNextTracks();

                // Play the selected track
                await Play(currentTrack, 0);
            }
        }

        private void buttonAddTrack_Click(object sender, EventArgs e)
        {
            // open the addForm and when it closes refresh the list of tracks
            addForm addForm = new addForm();
            addForm.Show();
            Enabled = false;
            addForm.FormClosed += (_, _) =>
            {
                Enabled = true;
                tracks.Clear();
                GetAllTracks(ref tracks);
                currentOrder.Clear();
                currentOrder.AddRange(tracks);
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

                    foreach (Track f in favorites)
                    {
                        if (f.Id == currentTrack.Id)
                        {
                            favorites.Remove(f);
                            break;
                        }
                    }

                    foreach (Track t in tracks)
                    {
                        if (t.Id == currentTrack.Id)
                        {
                            tracks.Remove(t);
                            break;
                        }
                    }
                    DisplaySongInformation(tracks);
                    DisplayFavorites(favorites);
                    currentTrack = null;
                    prevTrack = null;
                    nextTrack = null;
                    LockSoundControls();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error");
                }
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // open the editForm, when it closes refresh the list of tracks

            editForm editForm = new editForm(tracks);
            editForm.Show();
            Enabled = false;
            editForm.FormClosed += (_, _) =>
            {
                Enabled = true;
                tracks.Clear();
                GetAllTracks(ref tracks);
                currentOrder.Clear();
                currentOrder.AddRange(tracks);
                Refresh();
            };

        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            // set the volume of the player to the value of the trackBar for volume
            player.Volume = (float)trackBarVolume.Value / trackBarVolume.Maximum;
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            // flag the user want the next played song to be randomly selected and update the UI accordingly
            random = !random;
            if (!random)
            {
                labelRandom.Text = "Random: Off";
            }

            else
            {
                labelRandom.Text = "Random: On";
                repeat = false;
                labelRepeat.Text = "Repeat: Off";
            }
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
                await PlayPreviousTrack();
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
            // flag the user want the next played song to be the same as the current one and update the UI accordingly
            repeat = !repeat;
            if (!repeat)
            {
                labelRepeat.Text = "Repeat: Off";
            }
            else
            {
                labelRepeat.Text = "Repeat: On";
                random = false;
                labelRandom.Text = "Random: Off";
            }
        }

        private void titleToolStripShortByTitle_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by title (alphabetically)
            tracks.Sort((x, y) => String.CompareOrdinal(x.Title, y.Title));
            currentOrder.Clear();
            currentOrder.AddRange(tracks);
            DisplaySongInformation(tracks);
        }
        private void titleToolStripShortByArtist_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by artist (alphabetically)
            tracks.Sort((x, y) => String.CompareOrdinal(x.Artist, y.Artist));
            currentOrder.Clear();
            currentOrder.AddRange(tracks);
            DisplaySongInformation(tracks);
        }

        private void titleToolStripShortByYearAsc_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by year (ascending)
            tracks.Sort((x, y) => x.Year.CompareTo(y.Year));
            currentOrder.Clear();
            currentOrder.AddRange(tracks);
            DisplaySongInformation(tracks);
        }
        private void titleToolStripShortByYearDes_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by year (descending)
            tracks.Sort((x, y) => y.Year.CompareTo(x.Year));
            currentOrder.Clear();
            currentOrder.AddRange(tracks);
            DisplaySongInformation(tracks);
        }

        private void titleToolStripShortByGenre_Click(object sender, EventArgs e)
        {
            // sort the list of tracks by genre (alphabetically)
            tracks.Sort((x, y) => String.CompareOrdinal(x.Genre, y.Genre));
            currentOrder.Clear();
            currentOrder.AddRange(tracks);
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
                "The player can only play tracks stored as blobs in the local SQLite database. \n\n" +
                "The user can sort the track list in various ways by the use of the menu strip. \n\n" +
                "The list of favorites is saved on Application Exit and retrieved on application Startup!";
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
            // first if used because the event is shared with the menu strip
            if (buttonPlay.Enabled)
            {
                switch (player.PlaybackState)
                {
                    case PlaybackState.Playing:
                        {
                            paused = true;
                            player.Stop();
                            if (timerUpdater.Enabled)
                            {
                                timerUpdater.Stop();
                            }

                            break;
                        }
                    case PlaybackState.Stopped:
                        paused = false;
                        await Play(currentTrack, trackBarPlayer.Value);
                        break;
                }
            }
        }
        private async void buttonNext_Click(object sender, EventArgs e)
        {
            if (buttonNext.Enabled)
            {
                await PlayNextTrack();
            }
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
                user.Favorites = favorites;
                string json = JsonConvert.SerializeObject(users);
                System.IO.File.WriteAllText("users.json", json);
                Application.Exit();
        }
    }
}
