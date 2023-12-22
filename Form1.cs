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
    public partial class musicPlayerForm : Form
    {
        private Control[] _soundcontrols;
        private List<Track> tracks = new List<Track>();
        private const string _connectionString = "Data Source=Music.db;Version=3;";
        private int _trackCounter;

        public musicPlayerForm()
        {
            InitializeComponent();
            _soundcontrols = new Control[]
            {
                buttonPlay,
                buttonNext,
                buttonPrev,
                trackBarPlayer,
                trackBarVolume,
                labelStart,
                labelFinish
            };
            LockSoundControls(_soundcontrols);
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
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
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

        private void button1_Click(object sender, EventArgs e)
        {
            addForm addForm = new addForm();
            addForm.Show();
            // when the opened form closes, execute GetAllTracks() again
            addForm.FormClosed += (s, args) =>
            {
                tracks.Clear();
                getAllTracks(ref tracks, ref _trackCounter);
            };
        }
    }
}
