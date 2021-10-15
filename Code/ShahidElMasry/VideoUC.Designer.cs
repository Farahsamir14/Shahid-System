namespace ShahidElMasry
{
    partial class VideoUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoUC));
            this.poster = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.Label();
            this.Rate = new System.Windows.Forms.Label();
            this.addFav = new System.Windows.Forms.PictureBox();
            this.PremLabel = new System.Windows.Forms.Label();
            this.playBtn = new System.Windows.Forms.PictureBox();
            this.removeFav = new System.Windows.Forms.PictureBox();
            this.watchT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.poster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addFav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeFav)).BeginInit();
            this.SuspendLayout();
            // 
            // poster
            // 
            this.poster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.poster.Image = ((System.Drawing.Image)(resources.GetObject("poster.Image")));
            this.poster.Location = new System.Drawing.Point(3, 4);
            this.poster.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.poster.Name = "poster";
            this.poster.Size = new System.Drawing.Size(318, 309);
            this.poster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.poster.TabIndex = 0;
            this.poster.TabStop = false;
            this.poster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.poster_MouseClick);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Gold;
            this.Title.Location = new System.Drawing.Point(3, 316);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(106, 23);
            this.Title.TabIndex = 1;
            this.Title.Text = "Avengers : ";
            // 
            // Duration
            // 
            this.Duration.AutoSize = true;
            this.Duration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Duration.ForeColor = System.Drawing.Color.Gold;
            this.Duration.Location = new System.Drawing.Point(3, 364);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(45, 23);
            this.Duration.TabIndex = 2;
            this.Duration.Text = " min";
            // 
            // Rate
            // 
            this.Rate.AutoSize = true;
            this.Rate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rate.ForeColor = System.Drawing.Color.Gold;
            this.Rate.Location = new System.Drawing.Point(3, 387);
            this.Rate.Name = "Rate";
            this.Rate.Size = new System.Drawing.Size(36, 23);
            this.Rate.TabIndex = 3;
            this.Rate.Text = "/10";
            // 
            // addFav
            // 
            this.addFav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFav.Image = ((System.Drawing.Image)(resources.GetObject("addFav.Image")));
            this.addFav.Location = new System.Drawing.Point(268, 329);
            this.addFav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addFav.Name = "addFav";
            this.addFav.Size = new System.Drawing.Size(45, 47);
            this.addFav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addFav.TabIndex = 4;
            this.addFav.TabStop = false;
            this.addFav.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addFav_MouseClick);
            // 
            // PremLabel
            // 
            this.PremLabel.AutoSize = true;
            this.PremLabel.BackColor = System.Drawing.Color.Gold;
            this.PremLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PremLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.PremLabel.Location = new System.Drawing.Point(8, 10);
            this.PremLabel.Name = "PremLabel";
            this.PremLabel.Size = new System.Drawing.Size(85, 23);
            this.PremLabel.TabIndex = 5;
            this.PremLabel.Text = "Premium";
            // 
            // playBtn
            // 
            this.playBtn.BackColor = System.Drawing.Color.Black;
            this.playBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playBtn.Image = ((System.Drawing.Image)(resources.GetObject("playBtn.Image")));
            this.playBtn.Location = new System.Drawing.Point(249, 10);
            this.playBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(64, 55);
            this.playBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playBtn.TabIndex = 6;
            this.playBtn.TabStop = false;
            this.playBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playBtn_MouseClick);
            // 
            // removeFav
            // 
            this.removeFav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFav.Image = ((System.Drawing.Image)(resources.GetObject("removeFav.Image")));
            this.removeFav.Location = new System.Drawing.Point(268, 329);
            this.removeFav.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.removeFav.Name = "removeFav";
            this.removeFav.Size = new System.Drawing.Size(45, 47);
            this.removeFav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.removeFav.TabIndex = 7;
            this.removeFav.TabStop = false;
            this.removeFav.Visible = false;
            this.removeFav.MouseClick += new System.Windows.Forms.MouseEventHandler(this.removeFav_MouseClick);
            // 
            // watchT
            // 
            this.watchT.AutoSize = true;
            this.watchT.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.watchT.ForeColor = System.Drawing.Color.Gold;
            this.watchT.Location = new System.Drawing.Point(197, 316);
            this.watchT.Name = "watchT";
            this.watchT.Size = new System.Drawing.Size(132, 23);
            this.watchT.TabIndex = 8;
            this.watchT.Text = "Watch Times :";
            this.watchT.Visible = false;
            // 
            // VideoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.watchT);
            this.Controls.Add(this.removeFav);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.PremLabel);
            this.Controls.Add(this.addFav);
            this.Controls.Add(this.Rate);
            this.Controls.Add(this.Duration);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.poster);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VideoUC";
            this.Size = new System.Drawing.Size(323, 413);
            ((System.ComponentModel.ISupportInitialize)(this.poster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addFav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeFav)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox playBtn;
        public System.Windows.Forms.PictureBox addFav;
        public System.Windows.Forms.PictureBox removeFav;
        public System.Windows.Forms.PictureBox poster;
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.Label Duration;
        public System.Windows.Forms.Label Rate;
        public System.Windows.Forms.Label PremLabel;
        public System.Windows.Forms.Label watchT;
    }
}
