using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace AAE2023_Music_Player
{
    public partial class editForm : Form
    {

        // vars and objects

        private DbConnection dbConnection = new DbConnection("Music.db");       // Connection to the database
        private string title;                                                   // Title of the track
        private string artist;                                                  // Artist of the track
        private string genre;                                                   // Genre of the track
        private int year;                                                       // Year of the track
        private int id;                                                         // ID of the track
        private byte[] MusicFile;                                               // Music file of the track
        private byte[] image;                                                   // Image file of the track
        private List<Track> Tracks = new List<Track>();                         // List of tracks
        private Control[] controls;                                             // Array of controls
        
        // constructor
        
        public editForm(List<Track> MT)
        {
            InitializeComponent();
            foreach (Track t in MT)
            {
                comboBoxTitle.Items.Add(t.Title);
                Tracks.Add(t);
            }

            controls =
            [
                textBoxTitle,
                textBoxArtist,
                textBoxGenre,
                dateTimePickerYear,
                buttonMusic,
                buttonPicture,
                buttonEdit

            ];

        }

        //Events
        
        private void buttonMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Music Files|*.mp3;*.wav";
            openFileDialog1.Title = "Select a Music File";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                MusicFile = File.ReadAllBytes(openFileDialog1.FileName);
                label6.Text = "Music File \u2713";
            }
            else
            {
                MessageBox.Show("Please select a file");
            }

        }

        private void buttonPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png";
            openFileDialog1.Title = "Select an Image File";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                image = File.ReadAllBytes(openFileDialog1.FileName);
                label7.Text = "Picture \u2713";
            }
            else
            {
                MessageBox.Show("Please select a file");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && textBoxArtist.Text != "" && textBoxGenre.Text != "")
            {
                title = textBoxTitle.Text;
                artist = textBoxArtist.Text;
                genre = textBoxGenre.Text;
                year = dateTimePickerYear.Value.Year;
                using (SQLiteConnection connection = new SQLiteConnection(dbConnection.ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(
                               "UPDATE Tracks SET Title = @Title, " +
                               "Artist = @Artist, " +
                               "Genre = @Genre, " +
                               "Year = @Year, " +
                               "MusicFile = @MusicFile, " +
                               "PictureFile = @Image WHERE ID = @ID",
                               connection))
                    {
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Artist", artist);
                        command.Parameters.AddWithValue("@Genre", genre);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@MusicFile", MusicFile);
                        command.Parameters.AddWithValue("@Image", image);
                        command.Parameters.AddWithValue("@ID", id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                Close();

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }

        private void comboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Track t in Tracks)
            {
                if (t.Title == comboBoxTitle.SelectedItem.ToString())
                {
                    textBoxTitle.Text = t.Title;
                    textBoxArtist.Text = t.Artist;
                    textBoxGenre.Text = t.Genre;
                    dateTimePickerYear.Value = new DateTime(t.Year, 1, 1);
                    id = t.Id;
                    MusicFile = t.MusicFile;
                    image = t.Image;
                }
            }
            foreach(Control c in controls)
            {
                if (c.Enabled == false)
                {
                    c.Enabled = true;
                }
            }
        }
    }
    }

