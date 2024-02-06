namespace AAE2023_Music_Player
{
    partial class selectUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSelectedUser = new System.Windows.Forms.Label();
            this.buttonLogIn = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(219, 105);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 250);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // labelSelectedUser
            // 
            this.labelSelectedUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectedUser.AutoSize = true;
            this.labelSelectedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelSelectedUser.Location = new System.Drawing.Point(551, 418);
            this.labelSelectedUser.Name = "labelSelectedUser";
            this.labelSelectedUser.Size = new System.Drawing.Size(180, 25);
            this.labelSelectedUser.TabIndex = 2;
            this.labelSelectedUser.Text = "No Selected User";
            // 
            // buttonLogIn
            // 
            this.buttonLogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogIn.Enabled = false;
            this.buttonLogIn.Image = global::AAE2023_Music_Player.Properties.Resources.submit;
            this.buttonLogIn.Location = new System.Drawing.Point(556, 446);
            this.buttonLogIn.Name = "buttonLogIn";
            this.buttonLogIn.Size = new System.Drawing.Size(81, 73);
            this.buttonLogIn.TabIndex = 3;
            this.buttonLogIn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonLogIn.UseVisualStyleBackColor = true;
            this.buttonLogIn.Click += new System.EventHandler(this.buttonLogIn_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Image = global::AAE2023_Music_Player.Properties.Resources.delete;
            this.buttonDelete.Location = new System.Drawing.Point(678, 470);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(53, 49);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // selectUserForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(740, 531);
            this.Controls.Add(this.buttonLogIn);
            this.Controls.Add(this.labelSelectedUser);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "selectUserForm";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelSelectedUser;
        private System.Windows.Forms.Button buttonLogIn;
    }
}