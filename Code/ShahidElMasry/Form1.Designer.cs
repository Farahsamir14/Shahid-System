namespace ShahidElMasry
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.female = new System.Windows.Forms.RadioButton();
            this.male = new System.Windows.Forms.RadioButton();
            this.CCN = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.TextBox();
            this.fName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.EnterBtn = new System.Windows.Forms.PictureBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.ChooseReg = new System.Windows.Forms.Button();
            this.ChooseLog = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnterBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.female);
            this.panel1.Controls.Add(this.male);
            this.panel1.Controls.Add(this.CCN);
            this.panel1.Controls.Add(this.Email);
            this.panel1.Controls.Add(this.lName);
            this.panel1.Controls.Add(this.fName);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.EnterBtn);
            this.panel1.Controls.Add(this.password);
            this.panel1.Controls.Add(this.username);
            this.panel1.Controls.Add(this.ChooseReg);
            this.panel1.Controls.Add(this.ChooseLog);
            this.panel1.Location = new System.Drawing.Point(528, 76);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 463);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(54, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "Birthdate";
            // 
            // female
            // 
            this.female.AutoSize = true;
            this.female.BackColor = System.Drawing.Color.Transparent;
            this.female.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.female.ForeColor = System.Drawing.Color.Silver;
            this.female.Location = new System.Drawing.Point(176, 322);
            this.female.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(89, 26);
            this.female.TabIndex = 12;
            this.female.TabStop = true;
            this.female.Text = "Female";
            this.female.UseVisualStyleBackColor = false;
            // 
            // male
            // 
            this.male.AutoSize = true;
            this.male.BackColor = System.Drawing.Color.Transparent;
            this.male.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.male.ForeColor = System.Drawing.Color.Silver;
            this.male.Location = new System.Drawing.Point(87, 322);
            this.male.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(72, 26);
            this.male.TabIndex = 11;
            this.male.TabStop = true;
            this.male.Text = "Male";
            this.male.UseVisualStyleBackColor = false;
            // 
            // CCN
            // 
            this.CCN.BackColor = System.Drawing.Color.White;
            this.CCN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CCN.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCN.ForeColor = System.Drawing.Color.Silver;
            this.CCN.Location = new System.Drawing.Point(3, 391);
            this.CCN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CCN.Name = "CCN";
            this.CCN.Size = new System.Drawing.Size(252, 30);
            this.CCN.TabIndex = 10;
            this.CCN.Text = "Credit Card Number (Optional)";
            this.CCN.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CCN_MouseClick);
            this.CCN.Leave += new System.EventHandler(this.CCN_Leave);
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.White;
            this.Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.ForeColor = System.Drawing.Color.Silver;
            this.Email.Location = new System.Drawing.Point(58, 231);
            this.Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(245, 30);
            this.Email.TabIndex = 9;
            this.Email.Text = "E-Mail";
            this.Email.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Email_MouseClick);
            this.Email.Leave += new System.EventHandler(this.Email_Leave);
            // 
            // lName
            // 
            this.lName.BackColor = System.Drawing.Color.White;
            this.lName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.ForeColor = System.Drawing.Color.Silver;
            this.lName.Location = new System.Drawing.Point(184, 95);
            this.lName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(119, 30);
            this.lName.TabIndex = 8;
            this.lName.Text = "Last Name";
            this.lName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lName_MouseClick);
            this.lName.Leave += new System.EventHandler(this.lName_Leave);
            // 
            // fName
            // 
            this.fName.BackColor = System.Drawing.Color.White;
            this.fName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fName.ForeColor = System.Drawing.Color.Silver;
            this.fName.Location = new System.Drawing.Point(58, 95);
            this.fName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fName.Name = "fName";
            this.fName.Size = new System.Drawing.Size(119, 30);
            this.fName.TabIndex = 7;
            this.fName.Text = "First Name";
            this.fName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fName_MouseClick);
            this.fName.Leave += new System.EventHandler(this.fName_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 279);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 26);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // EnterBtn
            // 
            this.EnterBtn.BackColor = System.Drawing.Color.Transparent;
            this.EnterBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EnterBtn.BackgroundImage")));
            this.EnterBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnterBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EnterBtn.Location = new System.Drawing.Point(262, 354);
            this.EnterBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.EnterBtn.Name = "EnterBtn";
            this.EnterBtn.Size = new System.Drawing.Size(99, 105);
            this.EnterBtn.TabIndex = 4;
            this.EnterBtn.TabStop = false;
            this.EnterBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EnterBtn_MouseClick);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Silver;
            this.password.Location = new System.Drawing.Point(58, 186);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(245, 30);
            this.password.TabIndex = 3;
            this.password.Text = "Password";
            this.password.MouseClick += new System.Windows.Forms.MouseEventHandler(this.password_MouseClick);
            this.password.Leave += new System.EventHandler(this.password_Leave);
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.White;
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Silver;
            this.username.Location = new System.Drawing.Point(58, 140);
            this.username.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(245, 30);
            this.username.TabIndex = 2;
            this.username.Text = "Username";
            this.username.MouseClick += new System.Windows.Forms.MouseEventHandler(this.username_MouseClick);
            this.username.Leave += new System.EventHandler(this.username_Leave);
            // 
            // ChooseReg
            // 
            this.ChooseReg.BackColor = System.Drawing.Color.Black;
            this.ChooseReg.FlatAppearance.BorderSize = 0;
            this.ChooseReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseReg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseReg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ChooseReg.Location = new System.Drawing.Point(188, 4);
            this.ChooseReg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChooseReg.Name = "ChooseReg";
            this.ChooseReg.Size = new System.Drawing.Size(174, 54);
            this.ChooseReg.TabIndex = 1;
            this.ChooseReg.Text = "Register";
            this.ChooseReg.UseVisualStyleBackColor = false;
            this.ChooseReg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseReg_MouseClick);
            // 
            // ChooseLog
            // 
            this.ChooseLog.BackColor = System.Drawing.Color.Black;
            this.ChooseLog.FlatAppearance.BorderSize = 0;
            this.ChooseLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseLog.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseLog.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ChooseLog.Location = new System.Drawing.Point(3, 4);
            this.ChooseLog.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChooseLog.Name = "ChooseLog";
            this.ChooseLog.Size = new System.Drawing.Size(174, 54);
            this.ChooseLog.TabIndex = 0;
            this.ChooseLog.Text = "Login";
            this.ChooseLog.UseVisualStyleBackColor = false;
            this.ChooseLog.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ChooseLog_MouseClick);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Transparent;
            this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(839, 1);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(87, 71);
            this.Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit.TabIndex = 2;
            this.Exit.TabStop = false;
            this.Exit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Exit_MouseClick);
            // 
            // Login
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
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnterBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ChooseReg;
        private System.Windows.Forms.Button ChooseLog;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.PictureBox EnterBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox lName;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.RadioButton female;
        private System.Windows.Forms.RadioButton male;
        private System.Windows.Forms.TextBox CCN;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Exit;
    }
}

