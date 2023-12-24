using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AAE2023_Music_Player
{
    public partial class editForm : Form
    {
        
        // Variables
        
        private DbConnection dbConnection = new DbConnection("Music.db");
        private string title;
        private string artist;
        private string genre;
        private int year;
        private readonly int id;
        private byte[] MusicFile;
        private byte[] image;
        
        // Constructor(ας)
        
        public editForm(Track track)
        {
            InitializeComponent();
            title = track.Title;
            artist = track.Artist;
            genre = track.Genre;
            year = track.Year;
            MusicFile = track.MusicFile;
            image = track.Image;
            id = track.Id;
            textBoxTitle.Text = title;
            textBoxArtist.Text = artist;
            textBoxGenre.Text = genre;
            textBoxYear.Text = year.ToString();

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
                MusicFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                label6.Text = openFileDialog1.FileName;
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
                image = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                label7.Text = openFileDialog1.FileName;
            }
            else
            {
                MessageBox.Show("Please select a file");
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && textBoxArtist.Text != "" && textBoxGenre.Text != "" &&
                textBoxYear.Text != "" && int.TryParse(textBoxYear.Text, out var year))
            {
                title = textBoxTitle.Text;
                artist = textBoxArtist.Text;
                genre = textBoxGenre.Text;
                this.year = year;
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
                        command.Parameters.AddWithValue("@Year", this.year);
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
    }
    }

