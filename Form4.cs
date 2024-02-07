using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace AAE2023_Music_Player
{
    public partial class selectUserForm : Form
    {
        public User[] users;
        public User selectedUser;
        public TaskCompletionSource<bool> UserSelectionTaskCompletionSource { get; private set; }
        private List<Color> colors = new List<Color>()
        {
           Color.Yellow, Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Orange, Color.Pink, Color.Brown, Color.Cyan, Color.Magenta, 
           Color.LightBlue, Color.LightGreen, Color.LightYellow, Color.LightGray, Color.LightCyan, Color.LightPink, Color.LightSalmon, 
           Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.Lime, Color.LimeGreen, 
           Color.Linen, Color.Maroon, Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, 
           Color.MediumSlateBlue, Color.MediumSpringGreen, Color.MediumTurquoise, Color.MediumVioletRed, Color.MidnightBlue, Color.MintCream, 
           Color.MistyRose, Color.Moccasin, Color.NavajoWhite, Color.Navy, Color.OldLace, Color.Olive, Color.OliveDrab, Color.OrangeRed, 
           Color.Orchid, Color.PaleGoldenrod, Color.PaleGreen, Color.PaleTurquoise, Color.PaleVioletRed, Color.PapayaWhip, Color.PeachPuff, 
           Color.Peru, Color.Plum, Color.PowderBlue, Color.RosyBrown, Color.RoyalBlue, Color.SaddleBrown, Color.Salmon, Color.SandyBrown, 
           Color.SeaGreen, Color.SeaShell, Color.Sienna, Color.Silver, Color.SkyBlue, Color.SlateBlue, Color.SlateGray, Color.Snow, 
           Color.SpringGreen, Color.SteelBlue, Color.Tan, Color.Teal, Color.Thistle, Color.Tomato, Color.Turquoise, Color.Violet, 
            Color.Wheat, Color.White, Color.WhiteSmoke, Color.YellowGreen
        };
        public selectUserForm()
        {
            InitializeComponent();
            UserSelectionTaskCompletionSource = new TaskCompletionSource<bool>();
            // get the user list from the file name "users.json" if it exists, else set the users array to null
            if (System.IO.File.Exists("users.json"))
            {
                string json = System.IO.File.ReadAllText("users.json");
                users = JsonConvert.DeserializeObject<User[]>(json);
            }
            else
            {
                users = null;
            }
            // bind the form closing event to the Form4_FormClosing method
            FormClosing += Form4_FormClosing;
            CreateUI();
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save the user list to the file name "users.json"
            string json = JsonConvert.SerializeObject(users);
            System.IO.File.WriteAllText("users.json", json);
        }
        private void ButtonAddUser_click(object sender, EventArgs e)
        {
            // Pop up a message asking for a username and do not allow the user to continue until a valid username is entered
            string username = "";
            User newUser;
            while (username == "")
            {
                username = Microsoft.VisualBasic.Interaction.InputBox("Enter a username", "Add User", "");
                if (username == "")
                {
                    MessageBox.Show("Username cannot be empty");
                }
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i].ToString() == username)
                    {
                        MessageBox.Show("Username already exists");
                        username = "";
                    }
                }
            }
            // Create a new user with the entered username and add it to the users array
            if(users == null)
            {
                newUser = new User(username, 0);
            }
            else
            {
                newUser = new User(username, users.Length);
            }
            if (users != null)
            {
                User[] newUsers = new User[users.Length + 1];
                for (int i = 0; i < users.Length; i++)
                {
                    newUsers[i] = users[i];
                }
                newUsers[users.Length] = newUser;
                users = newUsers;
            }
            else
            {
                users = new User[1];
                users[0] = newUser;
            }
            CreateUI();
            // ad the new user to the user array
            
            
        }
        private void CreateUI()
        {
            int buttonCount;
            flowLayoutPanel1.Controls.Clear(); // Clear any existing buttons in the FlowLayoutPanel1
            Random rand = new Random();

            if(users == null)
            {
                buttonCount = 0;
            }
            else
            {
                buttonCount = Math.Min(users.Length, 4);
            }

            for (int i = 0; i < buttonCount; i++)
            {
                Button button = new Button(); // Create a new button

                // Set button properties
                button.Width = 117;
                button.Height = 117;
                button.Text = users[i].Username;
                button.Font = new Font(button.Font.FontFamily, 12, FontStyle.Bold);
                int index = rand.Next(colors.Count);
                button.BackColor = colors[index];
                colors.RemoveAt(index);
                button.Click += buttonSelectUser_Click; 

                flowLayoutPanel1.Controls.Add(button); // Add the button to the FlowLayoutPanel1
            }

            if (buttonCount < 4)
            {
                Button addButton = new Button(); // Create a new button for adding users

                // Set button properties
                addButton.Width = 117;
                addButton.Height = 117;
                addButton.BackgroundImage = Properties.Resources.add;
                addButton.BackgroundImageLayout = ImageLayout.Stretch;
                addButton.Click += ButtonAddUser_click;

                flowLayoutPanel1.Controls.Add(addButton); // Add the add button to the FlowLayoutPanel1
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // delete the selected user from the array
            if (selectedUser != null)
            {
                User[] newUsers = new User[users.Length - 1];
                int j = 0;
                for (int i = 0; i < users.Length; i++)
                {
                    if (users[i] != selectedUser)
                    {
                        newUsers[j] = users[i];
                        j++;
                    }
                }
                users = newUsers;
                selectedUser = null;
                labelSelectedUser.Text = "No Selected User";
                CreateUI();
            }
        }
        private void buttonSelectUser_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < users.Length; i++)
            {
                if (users[i].Username == ((Button)sender).Text)
                {
                    selectedUser = users[i];
                    labelSelectedUser.Text = selectedUser.Username;
                    buttonLogIn.Enabled = true;
                    buttonDelete.Enabled = true;
                }
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            Close();
            UserSelectionTaskCompletionSource.SetResult(true);
        }
    }
}
