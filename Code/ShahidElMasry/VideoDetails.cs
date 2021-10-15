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
using System.IO;

namespace ShahidElMasry
{
    public partial class VideoDetails : UserControl
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public static int movie_id;
        public static int series_id;
        public static int episode_num;
        public static int episode_season;
        public static bool isMovie = false;
        public static bool isSeries = false;

        string seriesTile;
        string[] seriesPart;
        public VideoDetails()
        {
            InitializeComponent();
        }

        private void VideoDetails_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(200, 0, 0, 0);
        }

        private void close_MouseClick(object sender, MouseEventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        //function to add movie review
        private void add_movie_rev()
        {
            int mov_id = -1;
            string rate_num;
            string rate_comment;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_id from movie where mov_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Title.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mov_id = int.Parse(dr[0].ToString());
            }
            dr.Close();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from rev_movie where movieid = :m_id and userid = :u_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_id", mov_id);
            cmd.Parameters.Add("u_id", Login.user_id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
      
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "update_mov_rev";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("m_id", mov_id);
                    cmd.Parameters.Add("u_id", Login.user_id);
                    if (!String.IsNullOrEmpty(my_rate.Text))
                    {
                        cmd.Parameters.Add("r_rate", int.Parse(my_rate.Text));
                        rate_num = "(" + my_rate.Text + "/10) ";
                    }
                    else
                    {
                        cmd.Parameters.Add("r_rate", DBNull.Value);
                        rate_num = "";
                    }
                    if (!String.IsNullOrEmpty(addrevbox.Text))
                    {
                        cmd.Parameters.Add("r_comment", addrevbox.Text);
                        rate_comment = addrevbox.Text + " ";
                    }
                    else
                    {
                        cmd.Parameters.Add("r_comment", DBNull.Value);
                        rate_comment = "";
                    }
                    cmd.ExecuteNonQuery();
                    //if (r != -1)
                    //{
                        MessageBox.Show("Review updated", "Review");
                        //revBox.Text += "- " + Login.UserName + " : " + rate_num + rate_comment + DateTime.Now.ToShortDateString() + "\n";
                    //}
                }

            else
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into rev_movie (rev_rate, rev_comment, rev_date, userid, movieid) values (:r_rate, :r_comment, :r_date, :u_id, :m_id)";
                cmd.CommandType = CommandType.Text;
                cmd.BindByName = true;
                if (!String.IsNullOrEmpty(my_rate.Text))
                {
                    cmd.Parameters.Add("r_rate", int.Parse(my_rate.Text));
                    rate_num = "(" + my_rate.Text + "/10) ";
                }
                else
                {
                    cmd.Parameters.Add("r_rate", DBNull.Value);
                    rate_num = "";
                }
                if (!String.IsNullOrEmpty(addrevbox.Text))
                {
                    cmd.Parameters.Add("r_comment", addrevbox.Text);
                    rate_comment = addrevbox.Text + " ";
                }
                else
                {
                    cmd.Parameters.Add("r_comment", DBNull.Value);
                    rate_comment = "";
                }

                cmd.Parameters.Add(new OracleParameter("r_date", OracleDbType.Date)).Value = DateTime.Now;
                cmd.Parameters.Add("u_id", Login.user_id);
                cmd.Parameters.Add("m_id", mov_id);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Review added", "Review");
                    revBox.Text += "- " + Login.UserName + " : " + rate_num + rate_comment + DateTime.Now.ToShortDateString() + "\n";
                }
            }
            dr.Close();
        }

         //function to add episode review
        private void add_episode_rev()
        {
            int series_id = -1;
            int ep_id = -1;
            string rate_num;
            string rate_comment;

            string[] episode_part = seriesPart[1].Split(',');
            string e_num = episode_part[0].Substring(10, 1);
            string s_num = episode_part[1].Substring(9, 1);
            episode_num = int.Parse(e_num);
            episode_season = int.Parse(s_num);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_id from series where s_name = :se_name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("se_name", seriesPart[0]);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                series_id = int.Parse(dr[0].ToString());

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ep_id from episode where ep_number = :e_num and ep_season = :e_season and seriesid = :s_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("e_num", episode_num);
            cmd.Parameters.Add("e_season", episode_season);
            cmd.Parameters.Add("seriesid", series_id);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ep_id = int.Parse(dr[0].ToString());
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from rev_episode where episodeid = :e_id and userid = :u_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("e_id", ep_id);
            cmd.Parameters.Add("u_id", Login.user_id);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update_ep_rev";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("e_id", ep_id);
                cmd.Parameters.Add("u_id", Login.user_id);
                if (!String.IsNullOrEmpty(my_rate.Text))
                {
                    cmd.Parameters.Add("r_rate", int.Parse(my_rate.Text));
                    rate_num = "(" + my_rate.Text + "/10) ";
                }
                else
                {
                    cmd.Parameters.Add("r_rate", DBNull.Value);
                    rate_num = "";
                }
                if (!String.IsNullOrEmpty(addrevbox.Text))
                {
                    cmd.Parameters.Add("r_comment", addrevbox.Text);
                    rate_comment = addrevbox.Text + " ";
                }
                else
                {
                    cmd.Parameters.Add("r_comment", DBNull.Value);
                    rate_comment = "";
                }
                cmd.ExecuteNonQuery();
                //if (r != -1)
                //{
                    MessageBox.Show("Review added", "Review");
                    //revBox.Text += "- " + Login.UserName + " : " + rate_num + rate_comment + DateTime.Now.ToShortDateString() + "\n";
                //}
            }

            else
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into rev_episode (rev_rate, rev_comment, rev_date, userid, episodeid) values (:r_rate, :r_comment, :r_date, :u_id, :e_id)";
                cmd.CommandType = CommandType.Text;
                cmd.BindByName = true;
                if (!String.IsNullOrEmpty(my_rate.Text))
                {
                    cmd.Parameters.Add("r_rate", int.Parse(my_rate.Text));
                    rate_num = "(" + my_rate.Text + "/10) ";
                }
                else
                {
                    cmd.Parameters.Add("r_rate", DBNull.Value);
                    rate_num = "";
                }
                if (!String.IsNullOrEmpty(addrevbox.Text))
                {
                    cmd.Parameters.Add("r_comment", addrevbox.Text);
                    rate_comment = addrevbox.Text + " ";
                }
                else
                {
                    cmd.Parameters.Add("r_comment", DBNull.Value);
                    rate_comment = "";
                }

                cmd.Parameters.Add(new OracleParameter("r_date", OracleDbType.Date)).Value = DateTime.Now;
                cmd.Parameters.Add("u_id", Login.user_id);
                cmd.Parameters.Add("e_id", ep_id);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Review added", "Review");
                    revBox.Text += "- " + Login.UserName + " : " + rate_num + rate_comment + DateTime.Now.ToShortDateString() + "\n";
                }
            }

            dr.Close();
        }

        //add review btn
        private void AddRev_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select mov_id from movie where mov_name = :name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("name", Title.Text);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    isMovie = true;
                }

                if (isMovie)
                    add_movie_rev();
                else
                {
                    seriesTile = Title.Text;
                    seriesPart = seriesTile.Split('\n');

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select s_id from series where s_name = :name";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("name", seriesPart[0]);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        isSeries = true;
                    }
                    dr.Close();


                    if (isSeries)
                        add_episode_rev();
                }

                isMovie = false;
                isSeries = false;

                conn.Dispose();
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.Message, "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        VideoEdit vid = new VideoEdit();

        //function of select movie
        private void select_movie()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from movie where mov_name =:name";
            cmd.Parameters.Add("name", Title.Text);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                movie_id = int.Parse(dr[0].ToString());
                vid.title.Text = dr[1].ToString();
                vid.richTextBox1.Text = dr[2].ToString();
                vid.rate.Text = dr[3].ToString();
                vid.len.Text = dr[4].ToString();
                vid.lang.Text = dr[5].ToString();
                vid.dateTimePicker1.Value = Convert.ToDateTime(dr[6].ToString());
                byte[] img_data = (byte[])dr[7];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.poster.Image = bm;
                ms.Dispose();
                if (dr[8].ToString() == "premium")
                    vid.checkBox1.CheckState = CheckState.Checked;
                else
                    vid.checkBox1.CheckState = CheckState.Unchecked;
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select gen_name from movie_genre where movieid = :id";
            cmd.Parameters.Add("id", movie_id);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vid.genres_LBox.Items.Add(dr[0].ToString());
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select actorid from movie_acted_by where movieid = :id";
            cmd.Parameters.Add("id", movie_id);
            int[] actor_id = new int[10];
            int i = 0;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                actor_id[i++] = int.Parse(dr[0].ToString());
            }

            for (int j = 0; j < actor_id.Length; j++)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from actor where a_id = :id";
                cmd.Parameters.Add("id", actor_id[j]);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string info = dr[1].ToString() + " " + dr[2].ToString() + "," + Convert.ToDateTime(dr[3].ToString()).ToShortDateString() + "," + dr[4].ToString();
                    vid.all_LBox.Items.Add(info);
                }
            }

            dr.Close();

            this.Parent.Parent.Parent.Parent.Controls.Add(vid);
            vid.Dock = DockStyle.Fill;
            vid.BringToFront();
            vid.movieRB.Checked = true;
            vid.all_LBox.Enabled = false;
            vid.genres_LBox.Enabled = false;
            vid.add_actor.Visible = false;
            vid.add_ex_actor.Visible = false;
            vid.dateTimePicker2.Visible = false;
            vid.Add.Visible = false;
            vid.actorsCBox.Visible = false;
            vid.actors_LBox.Visible = false;
            vid.genre_CBox.Visible = false;
            vid.add_genre.Visible = false;
            vid.label7.Visible = false;
            vid.actor.Visible = false;
        }

        //function of select episode
        private void select_episode()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from series where s_name =:name";
            cmd.Parameters.Add("name", seriesPart[0]);

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                series_id = int.Parse(dr[0].ToString());
                vid.title.Text = dr[1].ToString();
                vid.richTextBox1.Text = dr[2].ToString();
                vid.rate.Text = dr[3].ToString();
                vid.lang.Text = dr[4].ToString();
                if (dr[5].ToString() == "premium")
                    vid.checkBox1.CheckState = CheckState.Checked;
                else
                    vid.checkBox1.CheckState = CheckState.Unchecked;
            }

            string[] episode_part = seriesPart[1].Split(',');
            string e_num = episode_part[0].Substring(10, 1);
            string s_num = episode_part[1].Substring(9, 1);
            episode_num = int.Parse(e_num);
            episode_season = int.Parse(s_num);

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ep_len, ep_date, ep_img from episode where seriesid = :id and ep_number = :enum and ep_season = :snum";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", series_id);
            cmd.Parameters.Add("enum", episode_num);
            cmd.Parameters.Add("snum", episode_season);
            dr = cmd.ExecuteReader();
            
            if(dr.Read())
            {
                vid.episode.Text = "Ep : " + e_num + ",Season : " + s_num;
                vid.len.Text = dr[0].ToString();
                vid.dateTimePicker1.Value = Convert.ToDateTime(dr[1].ToString());
                byte[] img_data = (byte[])dr[2];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.poster.Image = bm;
                ms.Dispose();
            }


            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select gen_name from series_genre where seriesid = :id";
            cmd.Parameters.Add("id", series_id);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vid.genres_LBox.Items.Add(dr[0].ToString());
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select actorid from series_acted_by where seriesid = :id";
            cmd.Parameters.Add("id", series_id);
            int[] actor_id = new int[10];
            int i = 0;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                actor_id[i++] = int.Parse(dr[0].ToString());
            }

            for (int j = 0; j < actor_id.Length; j++)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from actor where a_id = :id";
                cmd.Parameters.Add("id", actor_id[j]);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string info = dr[1].ToString() + " " + dr[2].ToString() + "," + Convert.ToDateTime(dr[3].ToString()).ToShortDateString() +"," + dr[4].ToString();
                    vid.all_LBox.Items.Add(info);
                }
            }

            dr.Close();

            this.Parent.Parent.Parent.Parent.Controls.Add(vid);
            vid.Dock = DockStyle.Fill;
            vid.BringToFront();
            vid.epRB.Checked = true;
            vid.all_LBox.Enabled = false;
            vid.genres_LBox.Enabled = false;
            vid.add_actor.Visible = false;
            vid.add_ex_actor.Visible = false;
            vid.dateTimePicker2.Visible = false;
            vid.Add.Visible = false;
            vid.actorsCBox.Visible = false;
            vid.actors_LBox.Visible = false;
            vid.genre_CBox.Visible = false;
            vid.add_genre.Visible = false;
            vid.label7.Visible = false;
            vid.actor.Visible = false;
            vid.label1.Visible = false;
            vid.seriesCBox.Visible = false;
        }

        //edit btn
        private void edit_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select mov_id from movie where mov_name = :name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("name", Title.Text);
                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    isMovie = true;
                }

                seriesTile = Title.Text;
                seriesPart = seriesTile.Split('\n');

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select s_id from series where s_name = :name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("name", seriesPart[0]);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    isSeries = true;
                }
                dr.Close();

                if (isMovie)
                    select_movie();
                if (isSeries)
                    select_episode();

                conn.Dispose();
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.Message, "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}
