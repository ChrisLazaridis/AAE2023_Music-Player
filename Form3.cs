using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AAE2023_Music_Player
{
    public partial class addForm : Form
    {
        private byte[] _MusicFile;
        private readonly Bitmap _imagebmp= Properties.Resources.default_image;
        private byte[] _image;
        private const string _connectionString = "Data Source=Music.db;Version=3;";
        public addForm()
        {
            InitializeComponent();
            ImageConverter converter = new ImageConverter();
            _image = (byte[])converter.ConvertTo(_imagebmp, typeof(byte[]));

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && textBoxArtist.Text != "" && textBoxGenre.Text != "" &&
                textBoxYear.Text != "" && int.TryParse(textBoxDuration.Text, out var duration) && int.TryParse(textBoxYear.Text, out var year))
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText =
                            "INSERT INTO Tracks (Title, " +
                            "Artist, " +
                            "Genre, " +
                            "Year, " +
                            "Duration, " +
                            "MusicFile, " +
                            "PictureFile) VALUES (@Title, " +
                            "@Artist, " +
                            "@Genre, " +
                            "@Year, " +
                            "@Duration, " +
                            "@MusicFile, " +
                            "@Image)";
                        command.Parameters.AddWithValue("@Title", textBoxTitle.Text);
                        command.Parameters.AddWithValue("@Artist", textBoxArtist.Text);
                        command.Parameters.AddWithValue("@Genre", textBoxGenre.Text);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@Duration", duration);
                        command.Parameters.AddWithValue("@MusicFile", _MusicFile);
                        command.Parameters.AddWithValue("@Image", _image);
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

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Music Files|*.mp3;*.wav";
            openFileDialog1.Title = "Select a Music File";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                _MusicFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                if (buttonAdd.Enabled == false)
                {
                    buttonAdd.Enabled = true;
                }
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
    }
}
