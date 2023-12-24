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

namespace AAE2023_Music_Player
{
    public partial class editForm : Form
    {
        private const string _connectionString = "Data Source=Music.db;Version=3;";
        private string _title;
        private string _artist;
        private string _genre;
        private int _year;
        private int _id;
        private byte[] _MusicFile;
        private byte[] _image;
        public editForm(Track track)
        {
            InitializeComponent();
            _title = track.Title;
            _artist = track.Artist;
            _genre = track.Genre;
            _year = track.Year;
            _MusicFile = track.MusicFile;
            _image = track.Image;
            _id = track.Id;
            textBoxTitle.Text = _title;
            textBoxArtist.Text = _artist;
            textBoxGenre.Text = _genre;
            textBoxYear.Text = _year.ToString();

        }

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Music Files|*.mp3;*.wav";
            openFileDialog1.Title = "Select a Music File";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                _MusicFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
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
                _image = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
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
                _title = textBoxTitle.Text;
                _artist = textBoxArtist.Text;
                _genre = textBoxGenre.Text;
                _year = year;
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
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
                        command.Parameters.AddWithValue("@Title", _title);
                        command.Parameters.AddWithValue("@Artist", _artist);
                        command.Parameters.AddWithValue("@Genre", _genre);
                        command.Parameters.AddWithValue("@Year", _year);
                        command.Parameters.AddWithValue("@MusicFile", _MusicFile);
                        command.Parameters.AddWithValue("@Image", _image);
                        command.Parameters.AddWithValue("@ID", _id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                this.Close();

            }
            else
            {
                MessageBox.Show("Please fill in all the fields");
            }
        }
    }
    }

