﻿using System.ComponentModel;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AAE2023_Music_Player
{
    partial class musicPlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(musicPlayerForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playPauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortTrackListByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearDescendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonTrackFavorites = new System.Windows.Forms.Button();
            this.flowLayoutPanelFavorites = new System.Windows.Forms.FlowLayoutPanel();
            this.labelSongName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTrackList = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBoxTitle = new System.Windows.Forms.RichTextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddTrack = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRandom = new System.Windows.Forms.Label();
            this.labelNumOfSongs = new System.Windows.Forms.Label();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.labelFinish = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.trackBarPlayer = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.timerUpdater = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPauseToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.prevToolStripMenuItem,
            this.shortTrackListByToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(51, 20);
            this.toolStripMenuItem1.Text = "Player";
            // 
            // playPauseToolStripMenuItem
            // 
            this.playPauseToolStripMenuItem.Name = "playPauseToolStripMenuItem";
            this.playPauseToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.playPauseToolStripMenuItem.Text = "Play./Pause";
            this.playPauseToolStripMenuItem.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // prevToolStripMenuItem
            // 
            this.prevToolStripMenuItem.Name = "prevToolStripMenuItem";
            this.prevToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.prevToolStripMenuItem.Text = "Prev";
            this.prevToolStripMenuItem.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // shortTrackListByToolStripMenuItem
            // 
            this.shortTrackListByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleToolStripMenuItem,
            this.artistToolStripMenuItem,
            this.genreToolStripMenuItem,
            this.yearToolStripMenuItem,
            this.yearDescendingToolStripMenuItem});
            this.shortTrackListByToolStripMenuItem.Name = "shortTrackListByToolStripMenuItem";
            this.shortTrackListByToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.shortTrackListByToolStripMenuItem.Text = "Short Track List By:";
            // 
            // titleToolStripMenuItem
            // 
            this.titleToolStripMenuItem.Name = "titleToolStripMenuItem";
            this.titleToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.titleToolStripMenuItem.Text = "Title";
            this.titleToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripShortByTitle_Click);
            // 
            // artistToolStripMenuItem
            // 
            this.artistToolStripMenuItem.Name = "artistToolStripMenuItem";
            this.artistToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.artistToolStripMenuItem.Text = "Artist";
            this.artistToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripShortByArtist_Click);
            // 
            // genreToolStripMenuItem
            // 
            this.genreToolStripMenuItem.Name = "genreToolStripMenuItem";
            this.genreToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.genreToolStripMenuItem.Text = "Genre";
            this.genreToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripShortByGenre_Click);
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yearToolStripMenuItem.Text = "Year(Ascending)";
            this.yearToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripShortByYearAsc_Click);
            // 
            // yearDescendingToolStripMenuItem
            // 
            this.yearDescendingToolStripMenuItem.Name = "yearDescendingToolStripMenuItem";
            this.yearDescendingToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.yearDescendingToolStripMenuItem.Text = "Year(Descending)";
            this.yearDescendingToolStripMenuItem.Click += new System.EventHandler(this.titleToolStripShortByYearDes_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 575);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1089, 473);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Controls.Add(this.buttonTrackFavorites);
            this.panel3.Controls.Add(this.flowLayoutPanelFavorites);
            this.panel3.Controls.Add(this.labelSongName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(244, 467);
            this.panel3.TabIndex = 1;
            // 
            // buttonTrackFavorites
            // 
            this.buttonTrackFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTrackFavorites.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTrackFavorites.ForeColor = System.Drawing.Color.GreenYellow;
            this.buttonTrackFavorites.Location = new System.Drawing.Point(133, 0);
            this.buttonTrackFavorites.Name = "buttonTrackFavorites";
            this.buttonTrackFavorites.Size = new System.Drawing.Size(108, 28);
            this.buttonTrackFavorites.TabIndex = 2;
            this.buttonTrackFavorites.Text = "Tracking Favorites";
            this.buttonTrackFavorites.UseVisualStyleBackColor = false;
            this.buttonTrackFavorites.Click += new System.EventHandler(this.buttonTrackFavorites_Click);
            // 
            // flowLayoutPanelFavorites
            // 
            this.flowLayoutPanelFavorites.AutoScroll = true;
            this.flowLayoutPanelFavorites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFavorites.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelFavorites.Location = new System.Drawing.Point(0, 31);
            this.flowLayoutPanelFavorites.Name = "flowLayoutPanelFavorites";
            this.flowLayoutPanelFavorites.Size = new System.Drawing.Size(244, 436);
            this.flowLayoutPanelFavorites.TabIndex = 1;
            this.flowLayoutPanelFavorites.WrapContents = false;
            // 
            // labelSongName
            // 
            this.labelSongName.AutoSize = true;
            this.labelSongName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSongName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSongName.ForeColor = System.Drawing.Color.Brown;
            this.labelSongName.Location = new System.Drawing.Point(0, 0);
            this.labelSongName.Name = "labelSongName";
            this.labelSongName.Size = new System.Drawing.Size(127, 31);
            this.labelSongName.TabIndex = 0;
            this.labelSongName.Text = "Favorites";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(253, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(833, 467);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel2.Controls.Add(this.flowLayoutPanelTrackList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 376);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanelTrackList
            // 
            this.flowLayoutPanelTrackList.AutoScroll = true;
            this.flowLayoutPanelTrackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTrackList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTrackList.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTrackList.Name = "flowLayoutPanelTrackList";
            this.flowLayoutPanelTrackList.Size = new System.Drawing.Size(827, 376);
            this.flowLayoutPanelTrackList.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel4.Controls.Add(this.richTextBoxTitle);
            this.panel4.Controls.Add(this.buttonEdit);
            this.panel4.Controls.Add(this.buttonDelete);
            this.panel4.Controls.Add(this.buttonAddTrack);
            this.panel4.Controls.Add(this.buttonRefresh);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(827, 79);
            this.panel4.TabIndex = 1;
            // 
            // richTextBoxTitle
            // 
            this.richTextBoxTitle.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.richTextBoxTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBoxTitle.Location = new System.Drawing.Point(96, 0);
            this.richTextBoxTitle.Name = "richTextBoxTitle";
            this.richTextBoxTitle.Size = new System.Drawing.Size(458, 79);
            this.richTextBoxTitle.TabIndex = 24;
            this.richTextBoxTitle.Text = "Search";
            this.richTextBoxTitle.TextChanged += new System.EventHandler(this.richTextBoxTitle_TextChanged);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonEdit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEdit.Image = global::AAE2023_Music_Player.Properties.Resources.edit;
            this.buttonEdit.Location = new System.Drawing.Point(554, 0);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(91, 79);
            this.buttonEdit.TabIndex = 23;
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.Image = global::AAE2023_Music_Player.Properties.Resources.trash_bin;
            this.buttonDelete.Location = new System.Drawing.Point(645, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(91, 79);
            this.buttonDelete.TabIndex = 22;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAddTrack
            // 
            this.buttonAddTrack.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddTrack.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddTrack.Image")));
            this.buttonAddTrack.Location = new System.Drawing.Point(736, 0);
            this.buttonAddTrack.Name = "buttonAddTrack";
            this.buttonAddTrack.Size = new System.Drawing.Size(91, 79);
            this.buttonAddTrack.TabIndex = 19;
            this.buttonAddTrack.UseVisualStyleBackColor = true;
            this.buttonAddTrack.Click += new System.EventHandler(this.buttonAddTrack_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
            this.buttonRefresh.Location = new System.Drawing.Point(0, 0);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(96, 79);
            this.buttonRefresh.TabIndex = 21;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.labelRandom);
            this.panel1.Controls.Add(this.labelNumOfSongs);
            this.panel1.Controls.Add(this.labelRepeat);
            this.panel1.Controls.Add(this.buttonRepeat);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.buttonShuffle);
            this.panel1.Controls.Add(this.labelFinish);
            this.panel1.Controls.Add(this.labelStart);
            this.panel1.Controls.Add(this.trackBarPlayer);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.trackBarVolume);
            this.panel1.Controls.Add(this.buttonNext);
            this.panel1.Controls.Add(this.buttonPrev);
            this.panel1.Controls.Add(this.buttonPlay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 90);
            this.panel1.TabIndex = 1;
            // 
            // labelRandom
            // 
            this.labelRandom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRandom.AutoSize = true;
            this.labelRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelRandom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelRandom.Location = new System.Drawing.Point(293, 24);
            this.labelRandom.Name = "labelRandom";
            this.labelRandom.Size = new System.Drawing.Size(81, 16);
            this.labelRandom.TabIndex = 13;
            this.labelRandom.Text = "Random: Off";
            // 
            // labelNumOfSongs
            // 
            this.labelNumOfSongs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumOfSongs.AutoSize = true;
            this.labelNumOfSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelNumOfSongs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNumOfSongs.Location = new System.Drawing.Point(898, 4);
            this.labelNumOfSongs.Name = "labelNumOfSongs";
            this.labelNumOfSongs.Size = new System.Drawing.Size(0, 16);
            this.labelNumOfSongs.TabIndex = 12;
            // 
            // labelRepeat
            // 
            this.labelRepeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelRepeat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelRepeat.Location = new System.Drawing.Point(300, 4);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Size = new System.Drawing.Size(74, 16);
            this.labelRepeat.TabIndex = 11;
            this.labelRepeat.Text = "Repeat: Off";
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRepeat.BackgroundImage")));
            this.buttonRepeat.Enabled = false;
            this.buttonRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRepeat.Image = global::AAE2023_Music_Player.Properties.Resources.repeat;
            this.buttonRepeat.Location = new System.Drawing.Point(377, 0);
            this.buttonRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(45, 43);
            this.buttonRepeat.TabIndex = 10;
            this.buttonRepeat.UseVisualStyleBackColor = true;
            this.buttonRepeat.Click += new System.EventHandler(this.buttonRepeat_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelName.Location = new System.Drawing.Point(43, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 24);
            this.labelName.TabIndex = 9;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShuffle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonShuffle.BackgroundImage")));
            this.buttonShuffle.Enabled = false;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Image = global::AAE2023_Music_Player.Properties.Resources.Shuffle;
            this.buttonShuffle.Location = new System.Drawing.Point(618, -1);
            this.buttonShuffle.Margin = new System.Windows.Forms.Padding(0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(45, 43);
            this.buttonShuffle.TabIndex = 8;
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // labelFinish
            // 
            this.labelFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFinish.AutoSize = true;
            this.labelFinish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFinish.Location = new System.Drawing.Point(959, 26);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(34, 13);
            this.labelFinish.TabIndex = 7;
            this.labelFinish.Text = "00:00";
            // 
            // labelStart
            // 
            this.labelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStart.AutoSize = true;
            this.labelStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelStart.Location = new System.Drawing.Point(3, 25);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(34, 13);
            this.labelStart.TabIndex = 6;
            this.labelStart.Text = "00:00";
            // 
            // trackBarPlayer
            // 
            this.trackBarPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPlayer.Enabled = false;
            this.trackBarPlayer.Location = new System.Drawing.Point(0, 42);
            this.trackBarPlayer.Name = "trackBarPlayer";
            this.trackBarPlayer.Size = new System.Drawing.Size(993, 45);
            this.trackBarPlayer.TabIndex = 5;
            this.trackBarPlayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPlayer_MouseDown);
            this.trackBarPlayer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPlayer_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1013, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 55);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trackBarVolume.Enabled = false;
            this.trackBarVolume.Location = new System.Drawing.Point(992, 51);
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(103, 45);
            this.trackBarVolume.TabIndex = 3;
            this.trackBarVolume.Value = 10;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNext.BackgroundImage")));
            this.buttonNext.Enabled = false;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(552, 10);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 21);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrev.BackgroundImage")));
            this.buttonPrev.Enabled = false;
            this.buttonPrev.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonPrev.FlatAppearance.BorderSize = 0;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(443, 10);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(32, 21);
            this.buttonPrev.TabIndex = 1;
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlay.BackgroundImage")));
            this.buttonPlay.Enabled = false;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(488, 4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(61, 41);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // sqLiteCommand1
            // 
            this.sqLiteCommand1.CommandText = null;
            // 
            // timerUpdater
            // 
            this.timerUpdater.Interval = 1000;
            this.timerUpdater.Tick += new System.EventHandler(this.timerUpdater_Tick);
            // 
            // musicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 599);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "musicPlayerForm";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.MusicPlayerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel3;
        private Panel panel1;
        private Button buttonPlay;
        private Button buttonPrev;
        private Button buttonNext;
        private TrackBar trackBarVolume;
        private PictureBox pictureBox1;
        private TrackBar trackBarPlayer;
        private SQLiteCommand sqLiteCommand1;
        private Label labelFinish;
        private Label labelStart;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel2;
        private Button buttonRefresh;
        private Button buttonAddTrack;
        private Panel panel4;
        private Button buttonDelete;
        private Button buttonEdit;
        private Timer timerUpdater;
        private FlowLayoutPanel flowLayoutPanelTrackList;
        private RichTextBox richTextBoxTitle;
        private Button buttonShuffle;
        private Label labelName;
        private FlowLayoutPanel flowLayoutPanelFavorites;
        private Label labelSongName;
        private Button buttonRepeat;
        private Label labelRepeat;
        private Label labelNumOfSongs;
        private ToolStripMenuItem playPauseToolStripMenuItem;
        private ToolStripMenuItem nextToolStripMenuItem;
        private ToolStripMenuItem prevToolStripMenuItem;
        private ToolStripMenuItem shortTrackListByToolStripMenuItem;
        private ToolStripMenuItem titleToolStripMenuItem;
        private ToolStripMenuItem artistToolStripMenuItem;
        private ToolStripMenuItem yearToolStripMenuItem;
        private ToolStripMenuItem yearDescendingToolStripMenuItem;
        private ToolStripMenuItem genreToolStripMenuItem;
        private Button buttonTrackFavorites;
        private Label labelRandom;
    }
}

