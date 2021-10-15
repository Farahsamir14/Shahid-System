namespace ShahidElMasry
{
    partial class Report
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
            this.movieBtn = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.mov_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mov_genre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.seriesBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.subsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movieBtn
            // 
            this.movieBtn.Location = new System.Drawing.Point(604, 50);
            this.movieBtn.Name = "movieBtn";
            this.movieBtn.Size = new System.Drawing.Size(75, 50);
            this.movieBtn.TabIndex = 0;
            this.movieBtn.Text = "Generate Movie";
            this.movieBtn.UseVisualStyleBackColor = true;
            this.movieBtn.Visible = false;
            this.movieBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(12, 126);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1017, 561);
            this.crystalReportViewer1.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(34, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(110, 21);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Movie Report";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(173, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 21);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Series";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(287, 12);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(104, 21);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Subscribtion";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // mov_type
            // 
            this.mov_type.FormattingEnabled = true;
            this.mov_type.Location = new System.Drawing.Point(115, 80);
            this.mov_type.Name = "mov_type";
            this.mov_type.Size = new System.Drawing.Size(121, 24);
            this.mov_type.TabIndex = 5;
            this.mov_type.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Movie Type";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Movie Genre";
            this.label2.Visible = false;
            // 
            // mov_genre
            // 
            this.mov_genre.FormattingEnabled = true;
            this.mov_genre.Location = new System.Drawing.Point(373, 76);
            this.mov_genre.Name = "mov_genre";
            this.mov_genre.Size = new System.Drawing.Size(121, 24);
            this.mov_genre.TabIndex = 7;
            this.mov_genre.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Series name";
            this.label3.Visible = false;
            // 
            // seriesBtn
            // 
            this.seriesBtn.Location = new System.Drawing.Point(604, 50);
            this.seriesBtn.Name = "seriesBtn";
            this.seriesBtn.Size = new System.Drawing.Size(75, 50);
            this.seriesBtn.TabIndex = 11;
            this.seriesBtn.Text = "Generate Series";
            this.seriesBtn.UseVisualStyleBackColor = true;
            this.seriesBtn.Visible = false;
            this.seriesBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "season number";
            this.label4.Visible = false;
            // 
            // subsBtn
            // 
            this.subsBtn.Location = new System.Drawing.Point(604, 50);
            this.subsBtn.Name = "subsBtn";
            this.subsBtn.Size = new System.Drawing.Size(98, 50);
            this.subsBtn.TabIndex = 14;
            this.subsBtn.Text = "Generate Subscribtion";
            this.subsBtn.UseVisualStyleBackColor = true;
            this.subsBtn.Visible = false;
            this.subsBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.subsBtn_MouseClick);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 699);
            this.Controls.Add(this.subsBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.seriesBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mov_genre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mov_type);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.movieBtn);
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Report_FormClosed);
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button movieBtn;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.ComboBox mov_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mov_genre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button seriesBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button subsBtn;
    }
}