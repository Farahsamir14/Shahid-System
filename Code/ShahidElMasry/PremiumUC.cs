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
    public partial class PremiumUC : UserControl
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        int user_id;
        bool isFound = false;
        bool hasSub = false;
        public PremiumUC()
        {
            InitializeComponent();
            user_id = Login.user_id;
        }

        private void Cancel_MouseClick(object sender, MouseEventArgs e)
        {
            conn.Dispose();
            this.Parent.Controls.Remove(this);

        }

        private void Weekly_MouseClick(object sender, MouseEventArgs e)
        {
            Weekly.BackColor = Color.White;
            Monthly.BackColor = Color.Gold;
            Yearly.BackColor = Color.Gold;
        }

        private void Monthly_MouseClick(object sender, MouseEventArgs e)
        {
            Weekly.BackColor = Color.Gold;
            Monthly.BackColor = Color.White;
            Yearly.BackColor = Color.Gold;
        }

        private void Yearly_MouseClick(object sender, MouseEventArgs e)
        {
            Weekly.BackColor = Color.Gold;
            Monthly.BackColor = Color.Gold;
            Yearly.BackColor = Color.White;
        }

        //display credit card if exist and subsc if exist point 2
        private void PremiumUC_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 0, 0, 0);

            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select credit_card from s_user where user_id = :userid and credit_card is not null";
            c.Parameters.Add("userid", user_id);

            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                CCN.Text = dr[0].ToString();
                isFound = true;
            }

            c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select sub_type from subscribtion where userid = :id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", user_id);
            dr = c.ExecuteReader();
            if (dr.Read())
            {
                if (int.Parse(dr[0].ToString()) == 1)
                    Weekly.BackColor = Color.White;
                else if (int.Parse(dr[0].ToString()) == 2)
                    Monthly.BackColor = Color.White;
                else
                    Yearly.BackColor = Color.White;
                hasSub = true;
            }

            dr.Close();
            conn.Dispose();
        }

        //update credit card point 6
        //lw 3ando subsc w 3ayz y3mlo update point 3
        //lw m3ndosh hyt3mlo insert point 3
        private void Proceed_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int type = 0;

                if (Weekly.BackColor == Color.White)
                    type = 1;
                else if (Monthly.BackColor == Color.White)
                    type = 2;
                else if (Yearly.BackColor == Color.White)
                    type = 3;
                else
                    throw new Exception("Choose type of subscribtion");

                if (String.IsNullOrEmpty(CCN.Text))
                    throw new Exception("Enter your CCN");

                conn = new OracleConnection(ordb);
                conn.Open();

                if (isFound == false)
                {
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    //update_ccn
                    c.CommandText = "update_ccn";
                    c.CommandType = CommandType.StoredProcedure;
                    c.Parameters.Add("ccn", int.Parse(CCN.Text));
                    c.Parameters.Add("userid", user_id);
                    c.ExecuteNonQuery();

                    MessageBox.Show("CCN is added to your info", "Profile info Updated");
                    isFound = true;
                }

                if(hasSub == true && isFound == true)
                {
                    var option = MessageBox.Show("Are you sure you want to update your subscribtion?\nNote that the remaining days of your subscribtion won't count and the new subscribtion will start from today", "Warning", MessageBoxButtons.YesNo);
                    if (option == DialogResult.Yes)
                    {
                        OracleCommand cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "update subscribtion set sub_type = :s_type, start_date = :curr_date where userid = :id";
                        cmd.Parameters.Add("s_type", type);
                        cmd.Parameters.Add(new OracleParameter("curr_date", OracleDbType.Date)).Value = DateTime.Now;
                        cmd.Parameters.Add("id", user_id);
                        int r = cmd.ExecuteNonQuery();
                        if (r != -1)
                        {
                            MessageBox.Show("Enjoy your new subscribtion", "Subscribtion updated successfully");
                        }
                    }
                }
                else if(hasSub == false && isFound == true)
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into subscribtion (sub_type, userid, start_date) values (:s_type, :id, :curr_date)";
                    cmd.Parameters.Add("s_type", type);
                    cmd.Parameters.Add("id", user_id);
                    cmd.Parameters.Add(new OracleParameter("curr_date", OracleDbType.Date)).Value = DateTime.Now;

                    int r = cmd.ExecuteNonQuery();
                    if (r != -1)
                    {
                        MessageBox.Show("You can now watch all movies and series\nEnjoy", "Subscribtion done successfully");
                        this.Parent.Controls.Remove(this);
                    }
                }
               
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.ToString(), "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            conn.Dispose();
            
        }
    }
}
