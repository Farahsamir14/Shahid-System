namespace ShahidElMasry
{
    partial class PremiumUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PremiumUC));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Weekly = new System.Windows.Forms.Button();
            this.Monthly = new System.Windows.Forms.Button();
            this.Yearly = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Label();
            this.Proceed = new System.Windows.Forms.Label();
            this.CCN = new System.Windows.Forms.TextBox();
            this.CCNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Weekly
            // 
            this.Weekly.BackColor = System.Drawing.Color.Gold;
            this.Weekly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Weekly.FlatAppearance.BorderSize = 0;
            this.Weekly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Weekly.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Weekly.ForeColor = System.Drawing.Color.DarkRed;
            this.Weekly.Location = new System.Drawing.Point(3, 244);
            this.Weekly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Weekly.Name = "Weekly";
            this.Weekly.Size = new System.Drawing.Size(332, 71);
            this.Weekly.TabIndex = 1;
            this.Weekly.Text = "Weekly - 50 EPG";
            this.Weekly.UseVisualStyleBackColor = false;
            this.Weekly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Weekly_MouseClick);
            // 
            // Monthly
            // 
            this.Monthly.BackColor = System.Drawing.Color.Gold;
            this.Monthly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Monthly.FlatAppearance.BorderSize = 0;
            this.Monthly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Monthly.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Monthly.ForeColor = System.Drawing.Color.DarkRed;
            this.Monthly.Location = new System.Drawing.Point(3, 322);
            this.Monthly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Monthly.Name = "Monthly";
            this.Monthly.Size = new System.Drawing.Size(332, 71);
            this.Monthly.TabIndex = 2;
            this.Monthly.Text = "Monthly - 100 EPG";
            this.Monthly.UseVisualStyleBackColor = false;
            this.Monthly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Monthly_MouseClick);
            // 
            // Yearly
            // 
            this.Yearly.BackColor = System.Drawing.Color.Gold;
            this.Yearly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Yearly.FlatAppearance.BorderSize = 0;
            this.Yearly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yearly.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yearly.ForeColor = System.Drawing.Color.DarkRed;
            this.Yearly.Location = new System.Drawing.Point(3, 401);
            this.Yearly.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Yearly.Name = "Yearly";
            this.Yearly.Size = new System.Drawing.Size(332, 71);
            this.Yearly.TabIndex = 3;
            this.Yearly.Text = "Yearly - 600 EPG";
            this.Yearly.UseVisualStyleBackColor = false;
            this.Yearly.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Yearly_MouseClick);
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel.ForeColor = System.Drawing.Color.White;
            this.Cancel.Location = new System.Drawing.Point(14, 494);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(95, 31);
            this.Cancel.TabIndex = 4;
            this.Cancel.Text = "Cancel";
            this.Cancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Cancel_MouseClick);
            // 
            // Proceed
            // 
            this.Proceed.AutoSize = true;
            this.Proceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Proceed.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proceed.ForeColor = System.Drawing.Color.White;
            this.Proceed.Location = new System.Drawing.Point(223, 494);
            this.Proceed.Name = "Proceed";
            this.Proceed.Size = new System.Drawing.Size(108, 31);
            this.Proceed.TabIndex = 5;
            this.Proceed.Text = "Proceed";
            this.Proceed.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Proceed_MouseClick);
            // 
            // CCN
            // 
            this.CCN.BackColor = System.Drawing.Color.White;
            this.CCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CCN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCN.ForeColor = System.Drawing.Color.DarkRed;
            this.CCN.Location = new System.Drawing.Point(82, 192);
            this.CCN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CCN.Name = "CCN";
            this.CCN.Size = new System.Drawing.Size(252, 30);
            this.CCN.TabIndex = 11;
            // 
            // CCNLabel
            // 
            this.CCNLabel.AutoSize = true;
            this.CCNLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CCNLabel.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCNLabel.ForeColor = System.Drawing.Color.White;
            this.CCNLabel.Location = new System.Drawing.Point(1, 192);
            this.CCNLabel.Name = "CCNLabel";
            this.CCNLabel.Size = new System.Drawing.Size(90, 31);
            this.CCNLabel.TabIndex = 12;
            this.CCNLabel.Text = "CCN :";
            // 
            // PremiumUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.Controls.Add(this.CCNLabel);
            this.Controls.Add(this.CCN);
            this.Controls.Add(this.Proceed);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Yearly);
            this.Controls.Add(this.Monthly);
            this.Controls.Add(this.Weekly);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PremiumUC";
            this.Size = new System.Drawing.Size(341, 535);
            this.Load += new System.EventHandler(this.PremiumUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Weekly;
        private System.Windows.Forms.Button Monthly;
        private System.Windows.Forms.Button Yearly;
        private System.Windows.Forms.Label Cancel;
        private System.Windows.Forms.Label Proceed;
        private System.Windows.Forms.TextBox CCN;
        private System.Windows.Forms.Label CCNLabel;
    }
}
