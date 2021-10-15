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
using System.IO;

namespace ShahidElMasry
{
    public partial class Home : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        DateTime end_date;
        int user_id;
        bool seriesFound = false;
        bool movieFound = false;
        VideoUC vid;
        public Home()
        {
            InitializeComponent();
            user_id = Login.user_id;
        }

        //function to display movies point 1
        private void display_movie()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_name, mov_rate, mov_len, mov_img, mov_type, mov_id from movie";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr  = cmd.ExecuteReader();
            while (dr.Read())
            {
                vid = new VideoUC();

                vid.Title.Text = dr[0].ToString();
                vid.Rate.Text = dr[1].ToString() + "/10";
                vid.Duration.Text = dr[2].ToString() + " min";
                //image
                byte[] img_data = (byte[])dr[3];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.poster.Image = bm;
                ms.Dispose();

                if (dr[4].ToString() == "premium")
                    vid.PremLabel.Visible = true;
                else
                    vid.PremLabel.Visible = false;

                int movie_id = int.Parse(dr[5].ToString());

                //bnshoof table el fav 3shan el movie el mawgod nghyar el button bta3o
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "select * from adds_movie";
                c.CommandType = CommandType.Text;
                OracleDataReader odr = c.ExecuteReader();

                while (odr.Read())
                {
                    int u = int.Parse(odr[0].ToString());
                    int m = int.Parse(odr[1].ToString());
                    if (int.Parse(odr[0].ToString()) == user_id && int.Parse(odr[1].ToString()) == movie_id)
                    {
                        vid.addFav.Visible = false;
                        vid.removeFav.Visible = true;
                    }
                    else
                    {
                        vid.addFav.Visible = true;
                        vid.removeFav.Visible = false;
                    }

                }
                odr.Close();
                flowLayoutPanel1.Controls.Add(vid);
            }
            dr.Close();
        }

        //function to display episodes point 1
        private void display_episode()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_name, s_rate, s_type, s_id from series";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr  = cmd.ExecuteReader();

            while (dr.Read())
            {
                int s_id = int.Parse(dr[3].ToString());

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ep_number, ep_season, ep_len, ep_img, ep_id from episode where seriesid = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", s_id);

                OracleDataReader odr = cmd.ExecuteReader();
                while (odr.Read())
                {
                    vid = new VideoUC();


                    vid.Rate.Text = dr[1].ToString() + "/10";
                    if (dr[2].ToString() == "premium")
                        vid.PremLabel.Visible = true;
                    else
                        vid.PremLabel.Visible = false;

                    

                    vid.Title.Text = dr[0].ToString() + "\nEp : " + odr[0].ToString() + ",Season : " + odr[1].ToString();
                    vid.Duration.Text = odr[2].ToString() + " min";
                    byte[] img_data = (byte[])odr[3];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();

                    //bnshoof table el fav 3shan el episode el mawgod nghyar el button bta3o
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "select * from adds_episode";
                    c.CommandType = CommandType.Text;
                    OracleDataReader d = c.ExecuteReader();

                    while (d.Read())
                    {
                        if (int.Parse(d[0].ToString()) == user_id && int.Parse(d[1].ToString()) == int.Parse(odr[4].ToString()))
                        {
                            vid.addFav.Visible = false;
                            vid.removeFav.Visible = true;
                        }
                        else
                        {
                            vid.addFav.Visible = true;
                            vid.removeFav.Visible = false;
                        }
                    }
                    d.Close();
                    flowLayoutPanel1.Controls.Add(vid);
                }
                odr.Close();
            }
            dr.Close();
        }

        //select subsc of user if exist point 4
        //delete subsc if ended point 3
        private void Home_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);

            try
            {
                //check if subscribtion is ended or not if ended the subscribtion will be removed.
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand com = new OracleCommand();
                com.Connection = conn;
                com.CommandText = "select * from subscribtion where userid=:id";
                com.Parameters.Add("id", user_id);
                OracleDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {

                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "end_subscribtion";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("userid", user_id);
                    cmd.Parameters.Add("end", OracleDbType.Date, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();

                    end_date = Convert.ToDateTime(cmd.Parameters["end"].Value.ToString());
                }
                dr.Close();

                if(end_date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    MessageBox.Show("Your subscribtion has ended today", "Subscribtion");

                    com = new OracleCommand();
                    com.Connection = conn;
                    com.CommandText = "delete from subscribtion where userid = :id";
                    com.CommandType = CommandType.Text;
                    com.Parameters.Add("id", user_id);
                    com.ExecuteNonQuery();
                }

                //diplay movie and episode
                display_movie();
                display_episode();
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
        }

        private void Exit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void premiumBtn_MouseClick(object sender, MouseEventArgs e)
        {
            PremiumUC pre = new PremiumUC();
            panel1.Controls.Add(pre);
            pre.Location = new System.Drawing.Point(500, 120);
            pre.BringToFront();
        }

        //function of history of watched movies point 2
        private void history_movies()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movieid, watch_time from watches_movie where userid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", user_id);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                vid = new VideoUC();

                int mov = int.Parse(dr[0].ToString());
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "select mov_name, mov_rate, mov_len, mov_img, mov_type from movie where mov_id = :id";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader odr = c.ExecuteReader();

                vid.watchT.Visible = true;
                vid.watchT.Text = vid.watchT.Text + "\n" + dr[1].ToString();

                if(odr.Read())
                {
                    vid.Title.Text = odr[0].ToString();
                    vid.Rate.Text = odr[1].ToString() + "/10";
                    vid.Duration.Text = odr[2].ToString() + " min";
                    byte[] img_data = (byte[])odr[3];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();

                    if (odr[4].ToString() == "premium")
                        vid.PremLabel.Visible = true;
                    else
                        vid.PremLabel.Visible = false;

                    vid.addFav.Visible = false;
                    vid.removeFav.Visible = false;
                    flowLayoutPanel1.Controls.Add(vid);
                }
                odr.Close();
            }

            dr.Close();
        }

        //function of history of watched episodes point 2
        private void history_episodes()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select episodeid, watch_time from watches_episode where userid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", user_id);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                vid = new VideoUC();

                vid.watchT.Visible = true;
                vid.watchT.Text = vid.watchT.Text + "\n" + dr[1].ToString();
                int series = -1;
                string ep_num = null;
                string ep_season = null;

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select seriesid, ep_number, ep_season, ep_len, ep_img from episode where ep_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader d = cmd.ExecuteReader();

                if(d.Read())
                {
                    series = int.Parse(d[0].ToString());
                    ep_num = d[1].ToString();
                    ep_season = d[2].ToString();
                    vid.Duration.Text = d[3].ToString() + " min";
                    byte[] img_data = (byte[])d[4];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();
                }
                d.Close();

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select s_name, s_rate, s_type from series where s_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", series);
                OracleDataReader odr = cmd.ExecuteReader();
                    
                if(odr.Read())
                {
                    vid.Title.Text = odr[0].ToString() + "\nEp : " + ep_num + ",Season : " + ep_season;
                    vid.Rate.Text = odr[1].ToString() + "/10";
                    if (odr[2].ToString() == "premium")
                        vid.PremLabel.Visible = true;
                    else
                        vid.PremLabel.Visible = false;
                }
                odr.Close();

                vid.addFav.Visible = false;
                vid.removeFav.Visible = false;
                flowLayoutPanel1.Controls.Add(vid);
            }

            dr.Close();
        }

        //history icon
        private void HistoryBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            contain = splitContainer1.Panel2.Controls.ContainsKey("PlayVideo");
            if (contain)
                MessageBox.Show("You Must Close The Video First");
            else
            {
                flowLayoutPanel1.Controls.Clear();

                try
                {
                    conn = new OracleConnection(ordb);
                    conn.Open();

                    history_movies();
                    history_episodes();

                    conn.Close();
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
            }
        }

        //function of fav of movies point 2
        private void fav_movies()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movieid from adds_movie where userid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", user_id);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                vid = new VideoUC();

                int mov = int.Parse(dr[0].ToString());
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "select mov_name, mov_rate, mov_len, mov_img, mov_type from movie where mov_id = :id";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader odr = c.ExecuteReader();

                if (odr.Read())
                {
                    vid.Title.Text = odr[0].ToString();
                    vid.Rate.Text = odr[1].ToString() + "/10";
                    vid.Duration.Text = odr[2].ToString() + " min";
                    byte[] img_data = (byte[])odr[3];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();

                    if (odr[4].ToString() == "premium")
                        vid.PremLabel.Visible = true;
                    else
                        vid.PremLabel.Visible = false;

                    vid.addFav.Visible = false;
                    vid.removeFav.Visible = true;
                    flowLayoutPanel1.Controls.Add(vid);
                }
                odr.Close();
            }

            dr.Close();
        }

        //function of fav of episodes point 2
        private void fav_episodes()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select episodeid from adds_episode where userid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", user_id);
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                vid = new VideoUC();

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select seriesid, ep_number, ep_season, ep_len, ep_img from episode where ep_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader d = cmd.ExecuteReader();

                if (d.Read())
                {
                    int series = int.Parse(d[0].ToString());
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "select s_name, s_rate, s_type from series where s_id = :id";
                    c.CommandType = CommandType.Text;
                    c.Parameters.Add("id", series);
                    OracleDataReader odr = c.ExecuteReader();

                    if (odr.Read())
                    {
                        vid.Title.Text = odr[0].ToString() + "\nEp : " + d[1].ToString() + ",Season : " + d[2].ToString();
                        vid.Rate.Text = odr[1].ToString() + "/10";
                        if (odr[2].ToString() == "premium")
                            vid.PremLabel.Visible = true;
                        else
                            vid.PremLabel.Visible = false;
                    }
                    odr.Close();

                    vid.Duration.Text = d[3].ToString() + " min";
                    byte[] img_data = (byte[])d[4];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();
                }
                d.Close();

                vid.addFav.Visible = false;
                vid.removeFav.Visible = true;
                flowLayoutPanel1.Controls.Add(vid);
            }

            dr.Close();
        }

        //fav icon
        private void FavBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            contain = splitContainer1.Panel2.Controls.ContainsKey("PlayVideo");
            if (contain)
                MessageBox.Show("You Must Close The Video First");
            else
            {
                flowLayoutPanel1.Controls.Clear();

                try
                {
                    conn = new OracleConnection(ordb);
                    conn.Open();

                    fav_movies();
                    fav_episodes();

                    conn.Close();
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
            }
        }

        private void ProfileBtn_MouseClick(object sender, MouseEventArgs e)
        {
            
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            contain = splitContainer1.Panel2.Controls.ContainsKey("PlayVideo");
            if (contain)
                MessageBox.Show("You Must Close The Video First");
            else
            {
                ProfileUC prof = new ProfileUC();
                splitContainer1.Panel2.Controls.Add(prof);
                prof.BringToFront();
                prof.Dock = DockStyle.Fill;
                prof.Location = new System.Drawing.Point(300, 50);
            }
        }

        //home btn
        private void HomeBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            contain = splitContainer1.Panel2.Controls.ContainsKey("PlayVideo");
            if (contain)
                MessageBox.Show("You Must Close The Video First");
            else
            {
                flowLayoutPanel1.Controls.Clear();

                try
                {
                    conn = new OracleConnection(ordb);
                    conn.Open();

                    display_movie();
                    display_episode();

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

        //display all,movie,series
        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            flowLayoutPanel1.Controls.Clear();

            conn = new OracleConnection(ordb);
            conn.Open();

            if (typeBox.SelectedIndex == 0)
            {
                if(GenreBox.SelectedIndex == 1)
                {
                    display_movie_type("free");
                    display_episode_type("free");
                }
                else if(GenreBox.SelectedIndex == 2)
                {
                    display_movie_type("premium");
                    display_episode_type("premium");
                }
                else
                {
                    display_movie();
                    display_episode();
                }
            }
            else if (typeBox.SelectedIndex == 1)
            {
                if (GenreBox.SelectedIndex == 1)
                {
                    display_movie_type("free");
                }
                else if (GenreBox.SelectedIndex == 2)
                {
                    display_movie_type("premium");
                }
                else
                {
                    display_movie();
                }
            }
            else
            {
                if (GenreBox.SelectedIndex == 1)
                {
                    display_episode_type("free");
                }
                else if (GenreBox.SelectedIndex == 2)
                {
                    display_episode_type("premium");
                }
                else
                {
                    display_episode();
                }
            }

            conn.Close();

        }

        //function to display movies according to movie type point 2
        
        private void display_movie_type(string type)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_name, mov_rate, mov_len, mov_img, mov_type, mov_id from movie";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (type == dr[4].ToString())
                {
                    vid = new VideoUC();

                    vid.Title.Text = dr[0].ToString();
                    vid.Rate.Text = dr[1].ToString() + "/10";
                    vid.Duration.Text = dr[2].ToString() + " min";
                    byte[] img_data = (byte[])dr[3];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.poster.Image = bm;
                    ms.Dispose();

                    if (dr[4].ToString() == "premium")
                        vid.PremLabel.Visible = true;
                    else
                        vid.PremLabel.Visible = false;

                    int movie_id = int.Parse(dr[5].ToString());

                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "select * from adds_movie";
                    c.CommandType = CommandType.Text;
                    OracleDataReader odr = c.ExecuteReader();

                    while (odr.Read())
                    {
                        if (int.Parse(odr[0].ToString()) == user_id && int.Parse(odr[1].ToString()) == movie_id)
                        {
                            vid.addFav.Visible = false;
                            vid.removeFav.Visible = true;
                        }
                        else
                        {
                            vid.addFav.Visible = true;
                            vid.removeFav.Visible = false;
                        }

                    }
                    odr.Close();
                    flowLayoutPanel1.Controls.Add(vid);
                }
            }
            dr.Close();
        }

        //function to display episodes according to series type pooint 2
        private void display_episode_type(string type)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_name, s_rate, s_type, s_id from series";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (type == dr[2].ToString())
                {
                    int s_id = int.Parse(dr[3].ToString());

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select ep_number, ep_season, ep_len, ep_img, ep_id from episode where seriesid = :id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("id", s_id);

                    OracleDataReader odr = cmd.ExecuteReader();
                    while (odr.Read())
                    {

                        vid = new VideoUC();


                        vid.Rate.Text = dr[1].ToString() + "/10";
                        if (dr[2].ToString() == "premium")
                            vid.PremLabel.Visible = true;
                        else
                            vid.PremLabel.Visible = false;

                        vid.Title.Text = dr[0].ToString() + "\nEp : " + odr[0].ToString() + ",Season : " + odr[1].ToString();
                        vid.Duration.Text = odr[2].ToString() + " min";
                        byte[] img_data = (byte[])odr[3];
                        MemoryStream ms = new MemoryStream();
                        ms.Write(img_data, 0, img_data.Length);
                        Bitmap bm = new Bitmap(ms, false);
                        vid.poster.Image = bm;
                        ms.Dispose();

                        OracleCommand c = new OracleCommand();
                        c.Connection = conn;
                        c.CommandText = "select * from adds_episode";
                        c.CommandType = CommandType.Text;
                        OracleDataReader d = c.ExecuteReader();

                        while (d.Read())
                        {
                            if (int.Parse(d[0].ToString()) == user_id && int.Parse(d[1].ToString()) == int.Parse(odr[4].ToString()))
                            {
                                vid.addFav.Visible = false;
                                vid.removeFav.Visible = true;
                            }
                            else
                            {
                                vid.addFav.Visible = true;
                                vid.removeFav.Visible = false;
                            }
                        }
                        d.Close();
                        flowLayoutPanel1.Controls.Add(vid);
                    }
                    odr.Close();
                }
            }
            dr.Close();
        }

        //display movies and episodes according to their type
        private void GenreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            flowLayoutPanel1.Controls.Clear();

            conn = new OracleConnection(ordb);
            conn.Open();

            if (GenreBox.SelectedIndex == 0)
            {
                if(typeBox.SelectedIndex == 1)
                    display_movie();
                else if (typeBox.SelectedIndex == 2)
                    display_episode();
                else
                {
                    display_movie();
                    display_episode();
                }
            }
            else if (GenreBox.SelectedIndex == 1)
            {
                if (typeBox.SelectedIndex == 1)
                    display_movie_type("free");
                else if (typeBox.SelectedIndex == 2)
                    display_episode_type("free");
                else
                {
                    display_movie();
                    display_episode();
                }
            }
            else
            {
                if (typeBox.SelectedIndex == 1)
                    display_movie_type("premium");
                else if (typeBox.SelectedIndex == 2)
                    display_episode_type("premium");
                else
                {
                    display_movie();
                    display_episode();
                }
            }


            conn.Close();
        }

        //function to search by movie name point 5
        private void search_movie()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "search_movies";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("search", searchTxt.Text);
            cmd.Parameters.Add("all_movies", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader d = cmd.ExecuteReader();

            while (d.Read())
            {
                vid = new VideoUC();

                vid.Title.Text = d[1].ToString();
                vid.Rate.Text = d[2].ToString() + "/10";
                vid.Duration.Text = d[3].ToString() + " min";

                byte[] img_data = (byte[])d[4];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.poster.Image = bm;
                ms.Dispose();

                if (d[5].ToString() == "premium")
                    vid.PremLabel.Visible = true;
                else
                    vid.PremLabel.Visible = false;

                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "select * from adds_movie";
                c.CommandType = CommandType.Text;

                OracleDataReader dr = c.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr[0].ToString()) == user_id && int.Parse(dr[1].ToString()) == int.Parse(d[0].ToString()))
                    {
                        vid.addFav.Visible = false;
                        vid.removeFav.Visible = true;
                    }
                    else
                    {
                        vid.addFav.Visible = true;
                        vid.removeFav.Visible = false;
                    }
                }
                dr.Close();
                flowLayoutPanel1.Controls.Add(vid);

                movieFound = true;
            }
            d.Close();
        }

        //function to search by series name point 5
        private void search_series()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "search_series";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("search", searchTxt.Text);
            cmd.Parameters.Add("all_series", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader d = cmd.ExecuteReader();

            while (d.Read())
            {
                vid = new VideoUC();

                vid.Title.Text = d[0].ToString() + "\nEp : " + d[4].ToString() + ",Season : " + d[5].ToString();
                vid.Rate.Text = d[1].ToString() + "/10";
                if (d[2].ToString() == "premium")
                    vid.PremLabel.Visible = true;
                else
                    vid.PremLabel.Visible = false;

                vid.Duration.Text = d[6].ToString() + " min";
                byte[] img_data = (byte[])d[7];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.poster.Image = bm;
                ms.Dispose();

                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "select * from adds_episode";
                c.CommandType = CommandType.Text;
                OracleDataReader dr = c.ExecuteReader();

                while (dr.Read())
                {
                    if (int.Parse(dr[0].ToString()) == user_id && int.Parse(dr[1].ToString()) == int.Parse(d[3].ToString()))
                    {
                        vid.addFav.Visible = false;
                        vid.removeFav.Visible = true;
                    }
                    else
                    {
                        vid.addFav.Visible = true;
                        vid.removeFav.Visible = false;
                    }
                }
                dr.Close();
                flowLayoutPanel1.Controls.Add(vid);

                seriesFound = true;
            }
            d.Close();
        }

        //search btn
        private void searchBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("ProfileUC");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("ProfileUC");
            flowLayoutPanel1.Controls.Clear();

            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                if (typeBox.SelectedIndex == 1)
                {
                    search_movie();

                    if (movieFound == false)
                        MessageBox.Show("No movie/s found");
                    
                }
                else if (typeBox.SelectedIndex == 2)
                {
                    search_series();
                    if (seriesFound == false)
                        MessageBox.Show("No series found");
                }
                else
                {
                    search_movie();
                    search_series();
                    if (movieFound == false && seriesFound == false)
                        MessageBox.Show("No results found");
                }

                movieFound = false;
                seriesFound = false;

                conn.Close();
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.Message, "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
