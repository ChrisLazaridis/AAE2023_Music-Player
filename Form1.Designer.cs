using System.ComponentModel;
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.panel14 = new System.Windows.Forms.Panel();
            this.buttonPrev = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.buttonRepeat = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.labelNumOfSongs = new System.Windows.Forms.Label();
            this.labelFinish = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelRandom = new System.Windows.Forms.Label();
            this.labelRepeat = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.trackBarPlayer = new System.Windows.Forms.TrackBar();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
            this.timerUpdater = new System.Windows.Forms.Timer(this.components);
            this.panel15 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayer)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.panel15.SuspendLayout();
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
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 90);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1089, 90);
            this.panel5.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(992, 90);
            this.panel7.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(992, 51);
            this.panel9.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel17);
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(343, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(409, 51);
            this.panel12.TabIndex = 3;
            // 
            // panel17
            // 
            this.panel17.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel17.Controls.Add(this.buttonNext);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel17.Location = new System.Drawing.Point(298, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(45, 51);
            this.panel17.TabIndex = 4;
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonShuffle.BackgroundImage")));
            this.buttonShuffle.Enabled = false;
            this.buttonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShuffle.Image = global::AAE2023_Music_Player.Properties.Resources.Shuffle;
            this.buttonShuffle.Location = new System.Drawing.Point(12, 3);
            this.buttonShuffle.Margin = new System.Windows.Forms.Padding(0);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(42, 43);
            this.buttonShuffle.TabIndex = 23;
            this.buttonShuffle.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel16.Controls.Add(this.buttonShuffle);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel16.Location = new System.Drawing.Point(343, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(66, 51);
            this.panel16.TabIndex = 3;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonNext.BackgroundImage")));
            this.buttonNext.Enabled = false;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(10, 15);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 21);
            this.buttonNext.TabIndex = 17;
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPlay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPlay.BackgroundImage")));
            this.buttonPlay.Enabled = false;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlay.Image")));
            this.buttonPlay.Location = new System.Drawing.Point(39, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(61, 46);
            this.buttonPlay.TabIndex = 15;
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            this.panel14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel14.Controls.Add(this.buttonPrev);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(76, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(76, 51);
            this.panel14.TabIndex = 1;
            // 
            // buttonPrev
            // 
            this.buttonPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPrev.BackgroundImage")));
            this.buttonPrev.Enabled = false;
            this.buttonPrev.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonPrev.FlatAppearance.BorderSize = 0;
            this.buttonPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrev.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrev.Image")));
            this.buttonPrev.Location = new System.Drawing.Point(22, 15);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(32, 21);
            this.buttonPrev.TabIndex = 16;
            this.buttonPrev.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel13.Controls.Add(this.buttonRepeat);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(76, 51);
            this.panel13.TabIndex = 0;
            // 
            // buttonRepeat
            // 
            this.buttonRepeat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRepeat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRepeat.BackgroundImage")));
            this.buttonRepeat.Enabled = false;
            this.buttonRepeat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRepeat.Image = global::AAE2023_Music_Player.Properties.Resources.repeat;
            this.buttonRepeat.Location = new System.Drawing.Point(16, 4);
            this.buttonRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRepeat.Name = "buttonRepeat";
            this.buttonRepeat.Size = new System.Drawing.Size(45, 43);
            this.buttonRepeat.TabIndex = 25;
            this.buttonRepeat.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.labelNumOfSongs);
            this.panel10.Controls.Add(this.labelFinish);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(752, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(240, 51);
            this.panel10.TabIndex = 2;
            // 
            // labelNumOfSongs
            // 
            this.labelNumOfSongs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNumOfSongs.AutoSize = true;
            this.labelNumOfSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelNumOfSongs.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelNumOfSongs.Location = new System.Drawing.Point(129, 5);
            this.labelNumOfSongs.Name = "labelNumOfSongs";
            this.labelNumOfSongs.Size = new System.Drawing.Size(0, 16);
            this.labelNumOfSongs.TabIndex = 27;
            // 
            // labelFinish
            // 
            this.labelFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFinish.AutoSize = true;
            this.labelFinish.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelFinish.Location = new System.Drawing.Point(203, 34);
            this.labelFinish.Name = "labelFinish";
            this.labelFinish.Size = new System.Drawing.Size(34, 13);
            this.labelFinish.TabIndex = 22;
            this.labelFinish.Text = "00:00";
            // 
            // panel11
            // 
            this.panel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel11.Controls.Add(this.labelRandom);
            this.panel11.Controls.Add(this.labelRepeat);
            this.panel11.Controls.Add(this.labelName);
            this.panel11.Controls.Add(this.labelStart);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(343, 51);
            this.panel11.TabIndex = 1;
            // 
            // labelRandom
            // 
            this.labelRandom.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRandom.AutoSize = true;
            this.labelRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelRandom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelRandom.Location = new System.Drawing.Point(256, 28);
            this.labelRandom.Name = "labelRandom";
            this.labelRandom.Size = new System.Drawing.Size(81, 16);
            this.labelRandom.TabIndex = 29;
            this.labelRandom.Text = "Random: Off";
            // 
            // labelRepeat
            // 
            this.labelRepeat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelRepeat.AutoSize = true;
            this.labelRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelRepeat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelRepeat.Location = new System.Drawing.Point(266, 4);
            this.labelRepeat.Name = "labelRepeat";
            this.labelRepeat.Size = new System.Drawing.Size(74, 16);
            this.labelRepeat.TabIndex = 28;
            this.labelRepeat.Text = "Repeat: Off";
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.labelName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelName.Location = new System.Drawing.Point(49, 28);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 24);
            this.labelName.TabIndex = 25;
            // 
            // labelStart
            // 
            this.labelStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStart.AutoSize = true;
            this.labelStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelStart.Location = new System.Drawing.Point(9, 35);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(34, 13);
            this.labelStart.TabIndex = 24;
            this.labelStart.Text = "00:00";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.trackBarPlayer);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 57);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(992, 33);
            this.panel8.TabIndex = 0;
            // 
            // trackBarPlayer
            // 
            this.trackBarPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPlayer.Enabled = false;
            this.trackBarPlayer.Location = new System.Drawing.Point(-5, -6);
            this.trackBarPlayer.Name = "trackBarPlayer";
            this.trackBarPlayer.Size = new System.Drawing.Size(1002, 45);
            this.trackBarPlayer.TabIndex = 20;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Controls.Add(this.trackBarVolume);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(992, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(97, 90);
            this.panel6.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(18, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 55);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.trackBarVolume.Enabled = false;
            this.trackBarVolume.Location = new System.Drawing.Point(-3, 48);
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(103, 45);
            this.trackBarVolume.TabIndex = 19;
            this.trackBarVolume.Value = 10;
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
            // panel15
            // 
            this.panel15.Controls.Add(this.buttonPlay);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(152, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(146, 51);
            this.panel15.TabIndex = 5;
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
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPlayer)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.panel15.ResumeLayout(false);
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
        private SQLiteCommand sqLiteCommand1;
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
        private FlowLayoutPanel flowLayoutPanelFavorites;
        private Label labelSongName;
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
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private PictureBox pictureBox1;
        private TrackBar trackBarVolume;
        private Panel panel9;
        private Panel panel12;
        private Panel panel10;
        private Panel panel11;
        private TrackBar trackBarPlayer;
        private Label labelName;
        private Label labelStart;
        private Label labelRandom;
        private Label labelRepeat;
        private Panel panel17;
        private Panel panel16;
        private Panel panel14;
        private Panel panel13;
        private Button buttonRepeat;
        private Button buttonPrev;
        private Button buttonPlay;
        private Button buttonNext;
        private Button buttonShuffle;
        private Label labelFinish;
        private Label labelNumOfSongs;
        private Panel panel15;
    }
}

