namespace AAE2023_Music_Player
{
    partial class editForm
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonPicture = new System.Windows.Forms.Button();
            this.buttonMusic = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTitle = new System.Windows.Forms.ComboBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Image = global::AAE2023_Music_Player.Properties.Resources.submit;
            this.buttonEdit.Location = new System.Drawing.Point(94, 303);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(95, 77);
            this.buttonEdit.TabIndex = 39;
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonPicture
            // 
            this.buttonPicture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonPicture.Enabled = false;
            this.buttonPicture.Image = global::AAE2023_Music_Player.Properties.Resources.send_file;
            this.buttonPicture.Location = new System.Drawing.Point(180, 220);
            this.buttonPicture.Name = "buttonPicture";
            this.buttonPicture.Size = new System.Drawing.Size(95, 77);
            this.buttonPicture.TabIndex = 38;
            this.buttonPicture.UseVisualStyleBackColor = true;
            this.buttonPicture.Click += new System.EventHandler(this.buttonPicture_Click);
            // 
            // buttonMusic
            // 
            this.buttonMusic.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonMusic.Enabled = false;
            this.buttonMusic.Image = global::AAE2023_Music_Player.Properties.Resources.send_file;
            this.buttonMusic.Location = new System.Drawing.Point(18, 220);
            this.buttonMusic.Name = "buttonMusic";
            this.buttonMusic.Size = new System.Drawing.Size(95, 77);
            this.buttonMusic.TabIndex = 37;
            this.buttonMusic.UseVisualStyleBackColor = true;
            this.buttonMusic.Click += new System.EventHandler(this.buttonMusic_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label7.Location = new System.Drawing.Point(174, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 33);
            this.label7.TabIndex = 36;
            this.label7.Text = "Picture:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label6.Location = new System.Drawing.Point(12, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 33);
            this.label6.TabIndex = 35;
            this.label6.Text = "Music File:*";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(12, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 33);
            this.label4.TabIndex = 32;
            this.label4.Text = "Year:*";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxYear.BackColor = System.Drawing.Color.Black;
            this.textBoxYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxYear.Enabled = false;
            this.textBoxYear.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxYear.Location = new System.Drawing.Point(167, 161);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(125, 20);
            this.textBoxYear.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 33);
            this.label3.TabIndex = 30;
            this.label3.Text = "Genre:*";
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxGenre.BackColor = System.Drawing.Color.Black;
            this.textBoxGenre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGenre.Enabled = false;
            this.textBoxGenre.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxGenre.Location = new System.Drawing.Point(167, 115);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(125, 20);
            this.textBoxGenre.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 33);
            this.label2.TabIndex = 28;
            this.label2.Text = "Artist:*";
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxArtist.BackColor = System.Drawing.Color.Black;
            this.textBoxArtist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxArtist.Enabled = false;
            this.textBoxArtist.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxArtist.Location = new System.Drawing.Point(167, 68);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.Size = new System.Drawing.Size(125, 20);
            this.textBoxArtist.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 33);
            this.label1.TabIndex = 25;
            this.label1.Text = "Title:*";
            // 
            // comboBoxTitle
            // 
            this.comboBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxTitle.BackColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBoxTitle.FormattingEnabled = true;
            this.comboBoxTitle.Location = new System.Drawing.Point(496, 21);
            this.comboBoxTitle.Name = "comboBoxTitle";
            this.comboBoxTitle.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTitle.TabIndex = 40;
            this.comboBoxTitle.SelectedIndexChanged += new System.EventHandler(this.comboBoxTitle_SelectedIndexChanged);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxTitle.BackColor = System.Drawing.Color.Black;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTitle.Enabled = false;
            this.textBoxTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.textBoxTitle.Location = new System.Drawing.Point(167, 21);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(125, 20);
            this.textBoxTitle.TabIndex = 41;
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.comboBoxTitle);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonPicture);
            this.Controls.Add(this.buttonMusic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxArtist);
            this.Controls.Add(this.label1);
            this.Name = "editForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonPicture;
        private System.Windows.Forms.Button buttonMusic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxArtist;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
    }
}