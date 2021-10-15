namespace ShahidElMasry
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.premiumBtn = new System.Windows.Forms.PictureBox();
            this.HistoryBtn = new System.Windows.Forms.Button();
            this.FavBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.ProfileBtn = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.searchBtn = new System.Windows.Forms.PictureBox();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.GenreBox = new System.Windows.Forms.ComboBox();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.premiumBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(14, 55);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 484);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.premiumBtn);
            this.splitContainer1.Panel1.Controls.Add(this.HistoryBtn);
            this.splitContainer1.Panel1.Controls.Add(this.FavBtn);
            this.splitContainer1.Panel1.Controls.Add(this.HomeBtn);
            this.splitContainer1.Panel1.Controls.Add(this.ProfileBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(905, 484);
            this.splitContainer1.SplitterDistance = 70;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // premiumBtn
            // 
            this.premiumBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.premiumBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.premiumBtn.Image = ((System.Drawing.Image)(resources.GetObject("premiumBtn.Image")));
            this.premiumBtn.Location = new System.Drawing.Point(23, -6);
            this.premiumBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.premiumBtn.Name = "premiumBtn";
            this.premiumBtn.Size = new System.Drawing.Size(82, 80);
            this.premiumBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.premiumBtn.TabIndex = 4;
            this.premiumBtn.TabStop = false;
            this.premiumBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.premiumBtn_MouseClick);
            // 
            // HistoryBtn
            // 
            this.HistoryBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HistoryBtn.BackColor = System.Drawing.Color.Transparent;
            this.HistoryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HistoryBtn.FlatAppearance.BorderSize = 0;
            this.HistoryBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HistoryBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HistoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HistoryBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryBtn.ForeColor = System.Drawing.Color.White;
            this.HistoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("HistoryBtn.Image")));
            this.HistoryBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HistoryBtn.Location = new System.Drawing.Point(356, -3);
            this.HistoryBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HistoryBtn.Name = "HistoryBtn";
            this.HistoryBtn.Size = new System.Drawing.Size(83, 80);
            this.HistoryBtn.TabIndex = 3;
            this.HistoryBtn.Text = "History";
            this.HistoryBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HistoryBtn.UseVisualStyleBackColor = false;
            this.HistoryBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HistoryBtn_MouseClick);
            // 
            // FavBtn
            // 
            this.FavBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FavBtn.BackColor = System.Drawing.Color.Transparent;
            this.FavBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FavBtn.FlatAppearance.BorderSize = 0;
            this.FavBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FavBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FavBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FavBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FavBtn.ForeColor = System.Drawing.Color.White;
            this.FavBtn.Image = ((System.Drawing.Image)(resources.GetObject("FavBtn.Image")));
            this.FavBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FavBtn.Location = new System.Drawing.Point(195, -3);
            this.FavBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FavBtn.Name = "FavBtn";
            this.FavBtn.Size = new System.Drawing.Size(93, 80);
            this.FavBtn.TabIndex = 2;
            this.FavBtn.Text = "Favorites";
            this.FavBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.FavBtn.UseVisualStyleBackColor = false;
            this.FavBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FavBtn_MouseClick);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomeBtn.BackColor = System.Drawing.Color.Transparent;
            this.HomeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HomeBtn.FlatAppearance.BorderSize = 0;
            this.HomeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.HomeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.HomeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeBtn.ForeColor = System.Drawing.Color.White;
            this.HomeBtn.Image = ((System.Drawing.Image)(resources.GetObject("HomeBtn.Image")));
            this.HomeBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.HomeBtn.Location = new System.Drawing.Point(-120, -3);
            this.HomeBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(82, 80);
            this.HomeBtn.TabIndex = 1;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.HomeBtn.UseVisualStyleBackColor = false;
            this.HomeBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HomeBtn_MouseClick);
            // 
            // ProfileBtn
            // 
            this.ProfileBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProfileBtn.BackColor = System.Drawing.Color.Transparent;
            this.ProfileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProfileBtn.FlatAppearance.BorderSize = 0;
            this.ProfileBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ProfileBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ProfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProfileBtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProfileBtn.ForeColor = System.Drawing.Color.White;
            this.ProfileBtn.Image = ((System.Drawing.Image)(resources.GetObject("ProfileBtn.Image")));
            this.ProfileBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ProfileBtn.Location = new System.Drawing.Point(36, -3);
            this.ProfileBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ProfileBtn.Name = "ProfileBtn";
            this.ProfileBtn.Size = new System.Drawing.Size(83, 80);
            this.ProfileBtn.TabIndex = 0;
            this.ProfileBtn.Text = "Profile";
            this.ProfileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ProfileBtn.UseVisualStyleBackColor = false;
            this.ProfileBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProfileBtn_MouseClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.searchBtn);
            this.splitContainer2.Panel1.Controls.Add(this.searchTxt);
            this.splitContainer2.Panel1.Controls.Add(this.GenreBox);
            this.splitContainer2.Panel1.Controls.Add(this.typeBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer2.Size = new System.Drawing.Size(903, 407);
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchBtn.Image = ((System.Drawing.Image)(resources.GetObject("searchBtn.Image")));
            this.searchBtn.Location = new System.Drawing.Point(865, 10);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(35, 37);
            this.searchBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.searchBtn.TabIndex = 5;
            this.searchBtn.TabStop = false;
            this.searchBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.searchBtn_MouseClick);
            // 
            // searchTxt
            // 
            this.searchTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.searchTxt.BackColor = System.Drawing.Color.DarkRed;
            this.searchTxt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxt.ForeColor = System.Drawing.Color.White;
            this.searchTxt.Location = new System.Drawing.Point(604, 11);
            this.searchTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(255, 30);
            this.searchTxt.TabIndex = 4;
            // 
            // GenreBox
            // 
            this.GenreBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.GenreBox.BackColor = System.Drawing.Color.DarkRed;
            this.GenreBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenreBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenreBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenreBox.ForeColor = System.Drawing.Color.White;
            this.GenreBox.Items.AddRange(new object[] {
            "All",
            "free",
            "premium"});
            this.GenreBox.Location = new System.Drawing.Point(271, 10);
            this.GenreBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GenreBox.Name = "GenreBox";
            this.GenreBox.Size = new System.Drawing.Size(140, 31);
            this.GenreBox.TabIndex = 3;
            this.GenreBox.SelectedIndexChanged += new System.EventHandler(this.GenreBox_SelectedIndexChanged);
            // 
            // typeBox
            // 
            this.typeBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typeBox.BackColor = System.Drawing.Color.DarkRed;
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeBox.ForeColor = System.Drawing.Color.White;
            this.typeBox.Items.AddRange(new object[] {
            "All",
            "Movies",
            "Series"});
            this.typeBox.Location = new System.Drawing.Point(47, 10);
            this.typeBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(140, 31);
            this.typeBox.TabIndex = 2;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(903, 352);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(863, 2);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(63, 46);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit.TabIndex = 2;
            this.Exit.TabStop = false;
            this.Exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(933, 554);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Home";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.premiumBtn)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Exit;
        private System.Windows.Forms.Button ProfileBtn;
        private System.Windows.Forms.Button HistoryBtn;
        private System.Windows.Forms.Button FavBtn;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.PictureBox premiumBtn;
        private System.Windows.Forms.ComboBox GenreBox;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.PictureBox searchBtn;
        private System.Windows.Forms.TextBox searchTxt;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}