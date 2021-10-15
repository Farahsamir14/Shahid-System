using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace ShahidElMasry
{
    public partial class ProfileUC : UserControl
    {
        int user_id;
        DateTime end_date;

        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        public ProfileUC()
        {
            InitializeComponent();
            user_id = Login.user_id;

        }

        //display user info point 2
        //display end date if exist point 4
        private void ProfileUC_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 0, 0, 0);

            //select user info
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from s_user where user_id=:id";
                cmd.Parameters.Add("id", user_id);

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    uname.Text = dr[1].ToString();
                    password.Text = dr[2].ToString();
                    fname.Text = dr[3].ToString();
                    lname.Text = dr[4].ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dr[5].ToString());
                    if (dr[6].ToString() == "Female")
                        female.Checked = true;
                    else
                        male.Checked = true;
                    gender.Text = dr[6].ToString();
                    mail.Text = dr[7].ToString();
                    ccn.Text = dr[8].ToString();
                }

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from subscribtion where userid=:id";
                cmd.Parameters.Add("id", user_id);

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "end_subscribtion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("userid", user_id);
                    cmd.Parameters.Add("end", OracleDbType.Date, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();

                    end_date = Convert.ToDateTime(cmd.Parameters["end"].Value.ToString());
                    if (dr[0].ToString() == "1")
                        label11.Text += "weekly";
                    else if (dr[0].ToString() == "2")
                        label11.Text += "monthly";
                    else
                        label11.Text += "yearly";
                    label7.Text += end_date.ToString();
                    label10.Text += dr[1].ToString();
                }
                else
                {
                    label10.Visible = false;
                    label7.Visible = false;
                    label11.Visible = false;
                }
                dr.Close();
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.Message, "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            conn.Dispose();
            del.Enabled = true;
        }

        private void Edit_MouseClick(object sender, MouseEventArgs e)
        {
            male.Visible = true;
            female.Visible = true;
            gender.Visible = false;
            fname.Enabled = true;
            lname.Enabled = true;
            uname.Enabled = true;
            ccn.Enabled = true;
            password.Enabled = true;
            mail.Enabled = true;
            dateTimePicker1.Enabled = true;
            Save.Enabled = true;
            Edit.Enabled = false;
        }

        //update user info using command builder point 3
        private void Save_MouseClick(object sender, MouseEventArgs e)
        {
            
            //update user
            try
            {
                OracleDataAdapter num_users = new OracleDataAdapter("select count(*) from s_user", ordb);
                OracleDataAdapter adapter = Login.user_adpt;
                DataSet ds = Login.ds;
                OracleCommandBuilder cb = new OracleCommandBuilder(adapter);

                adapter.Fill(ds, "user_date");
                num_users.Fill(ds, "num");

                int index = -1;
                bool isFound = false;
                for(int i=0; i< int.Parse(ds.Tables["num"].Rows[0][0].ToString()); i++)
                {
                    if(user_id == int.Parse(ds.Tables["user_data"].Rows[i][0].ToString()))
                    {
                        index = i;
                        isFound = true;
                        break;
                    }
                }

                ds.Tables["user_data"].Rows[index][1] = uname.Text;
                ds.Tables["user_data"].Rows[index][2] = password.Text;
                ds.Tables["user_data"].Rows[index][3] = fname.Text;
                ds.Tables["user_data"].Rows[index][4] = lname.Text;
                ds.Tables["user_data"].Rows[index][5] = dateTimePicker1.Value;
                if (female.Checked)
                    ds.Tables["user_data"].Rows[index][6] = "Female";
                else
                    ds.Tables["user_data"].Rows[index][6] = "Male";
                ds.Tables["user_data"].Rows[index][7] = mail.Text;


                if (ccn.Text == "")
                    ds.Tables["user_data"].Rows[index][8] = DBNull.Value;
                else
                    ds.Tables["user_data"].Rows[index][8] = ccn.Text;

                adapter.Update(ds, "user_data");

                if (isFound)
                    MessageBox.Show("Changes saved", "Profile Modified");
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.Message, "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            male.Visible = false;
            female.Visible = false;
            gender.Visible = true;
            fname.Enabled = false;
            lname.Enabled = false;
            uname.Enabled = false;
            ccn.Enabled = false;
            password.Enabled = false;
            mail.Enabled = false;
            dateTimePicker1.Enabled = false;
            Save.Enabled = false;
            Edit.Enabled = true;
        }

        //delete user using  command  builder point 3
        private void del_MouseClick(object sender, MouseEventArgs e)
        {
            //delete user
            var option = MessageBox.Show("Are you sure you want to delete your account?", "Warning", MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes)
            {
                try
                {

                    OracleDataAdapter num_users = new OracleDataAdapter("select count(*) from s_user", ordb);
                    OracleDataAdapter adapter = Login.user_adpt;
                    DataSet ds = Login.ds;
                    OracleCommandBuilder cb = new OracleCommandBuilder(adapter);

                    adapter.Fill(ds, "user_date");
                    num_users.Fill(ds, "num");

                    DataRow r = null;
                    bool del = false;
                    for (int i = 0; i < int.Parse(ds.Tables["num"].Rows[0][0].ToString()); i++)
                    {
                        if (user_id == int.Parse(ds.Tables["user_data"].Rows[i][0].ToString()))
                        {
                            r = ds.Tables["user_data"].Rows[i];

                            r.Delete();
                            cb.GetDeleteCommand();
                            adapter.Update(ds, "user_data");
                            del = true;
                            break;
                        }
                    }

                    if (del)
                    {
                        MessageBox.Show("Account deleted.\nThe system will close", "Bye Bye");
                    }
                }
                catch (OracleException o)
                {
                    MessageBox.Show(o.Message, "Oracle error");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                
                conn.Dispose();

                Application.Exit();
            }
        }
    }
}
