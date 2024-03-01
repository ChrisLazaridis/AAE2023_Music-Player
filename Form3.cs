using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AAE2023_Music_Player.Properties;

namespace AAE2023_Music_Player
{
    public partial class addForm : Form
    {
        // vars and objects

        private byte[] MusicFile;                                         // Music file of the track
        private readonly Bitmap imagebmp= Resources.default_image;        // Image file of the track
        private byte[] image;                                             // Image file of the track
        private int lastId;                                               // ID of the track
        private int year;                                                 // Year of the track
        DbConnection dbConnection = new DbConnection("Music.db");         // Connection to the database
       
        // constructor
        
        public addForm()
        {
            InitializeComponent();
            ImageConverter converter = new ImageConverter();
            image = (byte[])converter.ConvertTo(imagebmp, typeof(byte[]));

        }

        // Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && textBoxArtist.Text != "" && textBoxGenre.Text != "")
            {
                year = dateTimePickerYear.Value.Year;
                using (SQLiteConnection connection = new SQLiteConnection(dbConnection.ConnectionString))
                {
                    connection.Open();
                    // find the last id in the database and add 1 to it to get the new id
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText =
                            "SELECT MAX(ID) FROM Tracks";
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText =
                            "INSERT INTO Tracks (ID, " +
                            "Title, " +
                            "Artist, " +
                            "Genre, " +
                            "Year, " +
                            "MusicFile, " +
                            "PictureFile) VALUES (@ID," +
                            "@Title, " +
                            "@Artist, " +
                            "@Genre, " +
                            "@Year, " +
                            "@MusicFile, " +
                            "@Image)";
                        command.Parameters.AddWithValue("@ID", lastId + 1 );
                        command.Parameters.AddWithValue("@Title", textBoxTitle.Text);
                        command.Parameters.AddWithValue("@Artist", textBoxArtist.Text);
                        command.Parameters.AddWithValue("@Genre", textBoxGenre.Text);
                        command.Parameters.AddWithValue("@Year", year);
                        command.Parameters.AddWithValue("@MusicFile", MusicFile);
                        command.Parameters.AddWithValue("@Image", image);
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

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Music Files|*.mp3;*.wav";
            openFileDialog1.Title = "Select a Music File";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                MusicFile = File.ReadAllBytes(openFileDialog1.FileName);
                if (buttonAdd.Enabled == false)
                {
                    buttonAdd.Enabled = true;
                }
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
    }
}
