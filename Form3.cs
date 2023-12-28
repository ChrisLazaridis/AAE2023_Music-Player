using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace AAE2023_Music_Player
{
    public partial class addForm : Form
    {
        // Variables
        
        private byte[] MusicFile;
        private readonly Bitmap imagebmp= Properties.Resources.default_image;
        private byte[] image;
        DbConnection dbConnection = new DbConnection("Music.db");
       
        // Constructor(ας)
        
        public addForm()
        {
            InitializeComponent();
            ImageConverter converter = new ImageConverter();
            image = (byte[])converter.ConvertTo(imagebmp, typeof(byte[]));

        }

        // Events
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxTitle.Text != "" && textBoxArtist.Text != "" && textBoxGenre.Text != "" &&
                textBoxYear.Text != "" && int.TryParse(textBoxYear.Text, out var year))
            {
                using (SQLiteConnection connection = new SQLiteConnection(dbConnection.ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText =
                            "INSERT INTO Tracks (Title, " +
                            "Artist, " +
                            "Genre, " +
                            "Year, " +
                            "MusicFile, " +
                            "PictureFile) VALUES (@Title, " +
                            "@Artist, " +
                            "@Genre, " +
                            "@Year, " +
                            "@MusicFile, " +
                            "@Image)";
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
                MusicFile = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
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
                image = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                label7.Text = "Picture \u2713";
            }
            else
            {
                MessageBox.Show("Please select a file");
            }
        }
    }
}
