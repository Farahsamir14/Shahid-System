using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ShahidElMasry
{
    public partial class Login : Form
    {
        public static int user_id;
        public static string UserName;

        public static OracleDataAdapter user_adpt;
        public static DataSet ds;
        OracleCommandBuilder c;

        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void username_MouseClick(object sender, MouseEventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.ForeColor = Color.Black;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
                username.ForeColor = Color.Silver;
            }
        }

        private void password_MouseClick(object sender, MouseEventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.ForeColor = Color.Black;
                password.PasswordChar = '\u2022';
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.ForeColor = Color.Silver;
                password.PasswordChar = '\0';
            }
        }

        private void fName_MouseClick(object sender, MouseEventArgs e)
        {
            if (fName.Text == "First Name")
            {
                fName.Text = "";
                fName.ForeColor = Color.Black;
            }
        }

        private void fName_Leave(object sender, EventArgs e)
        {
            if (fName.Text == "")
            {
                fName.Text = "First Name";
                fName.ForeColor = Color.Silver;
            }
        }

        private void lName_MouseClick(object sender, MouseEventArgs e)
        {
            if (lName.Text == "Last Name")
            {
                lName.Text = "";
                lName.ForeColor = Color.Black;
            }
        }

        private void lName_Leave(object sender, EventArgs e)
        {
            if (lName.Text == "")
            {
                lName.Text = "Last Name";
                lName.ForeColor = Color.Silver;
            }
        }

        private void Email_MouseClick(object sender, MouseEventArgs e)
        {
            if (Email.Text == "E-Mail")
            {
                Email.Text = "";
                Email.ForeColor = Color.Black;
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Text = "E-Mail";
                Email.ForeColor = Color.Silver;
            }
        }

        private void CCN_MouseClick(object sender, MouseEventArgs e)
        {
            if (CCN.Text == "Credit Card Number (Optional)")
            {
                CCN.Text = "";
                CCN.ForeColor = Color.Black;
            }
        }

        private void CCN_Leave(object sender, EventArgs e)
        {
            if (CCN.Text == "")
            {
                CCN.Text = "Credit Card Number (Optional)";
                CCN.ForeColor = Color.Silver;
            }
        }

        private void Exit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void ChooseLog_MouseClick(object sender, MouseEventArgs e)
        {
            fName.Visible = false;
            lName.Visible = false;
            Email.Visible = false;
            male.Visible = false;
            female.Visible = false;
            label1.Visible = false;
            dateTimePicker1.Visible = false;
            CCN.Visible = false;
        }

        private void ChooseReg_MouseClick(object sender, MouseEventArgs e)
        {
            fName.Visible = true;
            lName.Visible = true;
            Email.Visible = true;
            male.Visible = true;
            female.Visible = true;
            label1.Visible = true;
            dateTimePicker1.Visible = true;
            CCN.Visible = true;
        }

        //Register/Login btn
        //register using insert by data builder
        //login select by bind var
        private void EnterBtn_MouseClick(object sender, MouseEventArgs e)
        {
            user_adpt = new OracleDataAdapter("select * from s_user", ordb);
            ds = new DataSet();
            user_adpt.Fill(ds, "user_data");

            //Register (insert user using oracle builder) point 3
            if (fName.Visible == true)
            {
                try
                {
                    if (username.Text == "" || username.Text == "Username" || password.Text == "" || password.Text == "Password" || fName.Text == "" || fName.Text == "First Name" || lName.Text == "" || lName.Text == "Last Name" || Email.Text == "" || Email.Text == "E-Mail" || (female.Checked == false && male.Checked == false))
                        throw new Exception("Field value cannot be empty");

                    c = new OracleCommandBuilder(user_adpt);

                    DataRow r1 = ds.Tables["user_data"].NewRow();

                    r1["username"] = username.Text;
                    r1["password"] = password.Text;
                    r1["u_fname"] = fName.Text;
                    r1["u_lname"] = lName.Text;
                    r1["u_bdate"] = dateTimePicker1.Value;
                    if (female.Checked)
                        r1["u_gender"] = "Female";
                    else
                        r1["u_gender"] = "Male";

                    r1["email"] = Email.Text;
                    if (CCN.Text == "" || CCN.Text == "Credit Card Number (Optional)")
                        r1["credit_card"] = DBNull.Value;
                    else
                        r1["credit_card"] = int.Parse(CCN.Text);

                    ds.Tables["user_data"].Rows.Add(r1);
                    user_adpt.Update(ds, "user_data");

                    MessageBox.Show("You Registered Successfully\nPlease Login", "Welcome to Shahid");
                }
                catch (OracleException o)
                {
                    MessageBox.Show(o.Message, "Oracle error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot Register");
                }

            }
            //Login (select username and password using bind var and command parameters) point 2
            else
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;

                string user_name = "zero", passW = "zero";
                try
                {
                    cmd.CommandText = "select user_id, username, password from s_user where username = :username and password = :password";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("username", username.Text);
                    cmd.Parameters.Add("password", password.Text);

                    OracleDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        user_id = int.Parse(dr[0].ToString());
                        UserName = dr[1].ToString();
                        user_name = dr[1].ToString();
                        passW = dr[2].ToString();
                    }
                    dr.Close();

                    if ((username.Text == "alyaa" || username.Text == "farah" || username.Text == "fares" || username.Text == "karim" || username.Text == "lama") && password.Text == "0")
                    {
                        var form2 = new Admin();
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                        this.Hide();
                    }
                    else if (username.Text == user_name && password.Text == passW)
                    {
                        var form2 = new Home();
                        form2.Closed += (s, args) => this.Close();
                        form2.Show();
                        this.Hide();
                    }
                    else if (username.Text == "" || password.Text == "" || username.Text == "Username" || password.Text == "Password")
                        throw new Exception("Filed value cannot be empty");
                    else
                    {
                        throw new Exception("The username or password you entered is incorrect\n");
                    }
                }
                catch (OracleException o)
                {
                    MessageBox.Show(o.Message, "Oracle error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cannot Login");
                }

            }
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
    }
}
