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
    public partial class VideoUC : UserControl
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        int user_id = Login.user_id;
        int mov_id;
        int s_id;
        bool isMovie = false;
        bool isSeries = false;

        public static byte[] vid_data = null;
        public VideoUC()
        {
            InitializeComponent();
        }

        VideoDetails vid = new VideoDetails();

        //function to display all data of selected movie point 2
        private void movie_info()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from movie where mov_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Title.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mov_id = int.Parse(dr[0].ToString());
                vid.Title.Text = dr[1].ToString();
                vid.Desc.Text = dr[2].ToString();
                vid.rate.Text += dr[3].ToString();
                vid.dur.Text += dr[4].ToString();
                vid.lang.Text += dr[5].ToString();
                vid.rdate.Text += Convert.ToDateTime(dr[6]).ToShortDateString();
                //image
                byte[] img_data = (byte[])dr[7];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.pictureBox1.Image = bm;
                ms.Dispose();

                if (dr[8].ToString() == "premium")
                    vid.per_label.Visible = true;
                else if (dr[8].ToString() == "free")
                    vid.per_label.Visible = false;
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select gen_name from movie_genre where movieid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", mov_id);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vid.gen.Text += dr[0].ToString() + " ";
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select actorid from movie_acted_by where movieid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", mov_id);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select a_fname, a_lname, a_bdate, a_gender from actor where a_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader odr = cmd.ExecuteReader();
                if (odr.Read())
                {
                    vid.actorsBox.Text = vid.actorsBox.Text + "- " + odr[0].ToString() + " " + odr[1].ToString() + "\n  " + Convert.ToDateTime(odr[2].ToString()).ToShortDateString() + "\n  " + odr[3].ToString() + "\n  ";
                }
                odr.Close();
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select rev_rate, rev_comment from rev_movie where movieid = :m_id and userid = :u_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_id", mov_id);
            cmd.Parameters.Add("u_id", user_id);
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                vid.my_rate.Text = dr[0].ToString();
                vid.addrevbox.Text = dr[1].ToString();
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "getMovieRev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("m_id", mov_id);
            cmd.Parameters.Add("all_rev", OracleDbType.RefCursor, ParameterDirection.Output);
            dr = cmd.ExecuteReader();

            vid.revBox.Clear();
            while (dr.Read())
            {
                string rate_num;
                string rate_comment;

                if (dr[1] == DBNull.Value)
                    rate_num = "";
                else
                    rate_num = "(" + dr[1].ToString() + "/10) ";

                if (dr[2] == DBNull.Value)
                    rate_comment = "";
                else
                    rate_comment = dr[2].ToString() + " ";

                vid.revBox.Text += "- " + dr[0].ToString() + " : " + rate_num + rate_comment + Convert.ToDateTime(dr[3]).ToShortDateString() + "\n";
            }
            
            dr.Close();
        }

        //function to display all data of selected series
        private void episode_info()
        {
            string seriesTile = Title.Text;
            string[] seriesPart = seriesTile.Split('\n');
            int ep_id = -1;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from series where s_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", seriesPart[0]);
            OracleDataReader dr = cmd.ExecuteReader();

            string[] episodeData = seriesPart[1].Split(',');
            string episode_num = episodeData[0].Substring(5, 1);
            string episode_season = episodeData[1].Substring(9, 1);

            if (dr.Read())
            {
                s_id = int.Parse(dr[0].ToString());

                vid.Title.Text = dr[1].ToString() + "\nEpisode : " + episode_num + ",Season : " + episode_season;
                vid.Desc.Text = dr[2].ToString();
                vid.rate.Text += dr[3].ToString();
                vid.lang.Text += dr[4].ToString();
                if (dr[5].ToString() == "premium")
                    vid.per_label.Visible = true;
                else if (dr[5].ToString() == "free")
                    vid.per_label.Visible = false;  
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ep_len, ep_date, ep_img, ep_id from episode where seriesid = :id and ep_number = :num and ep_season = :season";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", s_id);
            cmd.Parameters.Add("num", int.Parse(episode_num));
            cmd.Parameters.Add("season", int.Parse(episode_season));
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                vid.dur.Text += dr[0].ToString();

                vid.rdate.Text += Convert.ToDateTime(dr[1]).ToShortDateString();
                //image
                byte[] img_data = (byte[])dr[2];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.pictureBox1.Image = bm;
                ms.Dispose();

                ep_id = int.Parse(dr[3].ToString());
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select gen_name from series_genre where seriesid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", s_id);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vid.gen.Text += dr[0].ToString() + " ";
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select actorid from series_acted_by where seriesid = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", s_id);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select a_fname, a_lname, a_bdate, a_gender from actor where a_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                OracleDataReader odr = cmd.ExecuteReader();
                if (odr.Read())
                {
                    vid.actorsBox.Text = vid.actorsBox.Text + "- " + odr[0].ToString() + " " + odr[1].ToString() + "\n  " + Convert.ToDateTime(odr[2].ToString()).ToShortDateString() + "\n  " + odr[3].ToString() + "\n  ";
                }
                odr.Close();
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select rev_rate, rev_comment from rev_episode where episodeid = :e_id and userid = :u_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("e_id", ep_id);
            cmd.Parameters.Add("u_id", user_id);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                vid.my_rate.Text = dr[0].ToString();
                vid.addrevbox.Text = dr[1].ToString();
            }

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "getEpisodeRev";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("e_id", mov_id);
            cmd.Parameters.Add("all_rev", OracleDbType.RefCursor, ParameterDirection.Output);
            dr = cmd.ExecuteReader();

            vid.revBox.Clear();
            while (dr.Read())
            {
                string rate_num;
                string rate_comment;

                if (dr[1] == DBNull.Value)
                    rate_num = "";
                else
                    rate_num = "(" + dr[1].ToString() + "/10) ";

                if (dr[2] == DBNull.Value)
                    rate_comment = "";
                else
                    rate_comment = dr[2].ToString() + " ";

                vid.revBox.Text += "- " + dr[0].ToString() + " : " + rate_num + rate_comment + Convert.ToDateTime(dr[3]).ToShortDateString() + "\n";
            }

            dr.Close();
            conn.Close();
        }

        //click on poster to view all data
        private void poster_MouseClick(object sender, MouseEventArgs e)
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
                if(dr.Read())
                {
                    isMovie = true;
                }

                if (isMovie)
                    movie_info();
                else
                {
                    episode_info();
                    //string seriesTile = Title.Text;
                    //string[] seriesPart = seriesTile.Split('\n');

                    //cmd = new OracleCommand();
                    //cmd.Connection = conn;
                    //cmd.CommandText = "select s_id from series where s_name = :name";
                    //cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.Add("name", seriesPart[0]);
                    //dr = cmd.ExecuteReader();
                    //if (dr.Read())
                    //{
                    //    isSeries = true;
                    //}
                    //if (isSeries)
                    //    episode_info();
                }
                dr.Close();  
                conn.Close();

                isMovie = false;
                isSeries = false;
            }
            catch (OracleException o)
            {
                MessageBox.Show(o.ToString(), "Oracle error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

            this.ParentForm.Controls.Add(vid);
            vid.Location = new System.Drawing.Point(300, 50);
            vid.BringToFront();
        }

        //function to add selected movie to fav
        private void add_fav_movie()
        {
            int movie_id = -1;
            
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_id from movie where mov_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Title.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                movie_id = int.Parse(dr[0].ToString());
            }
            dr.Close();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into adds_movie values (:userid, :movieid)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("userid", user_id);
            cmd.Parameters.Add("movid", movie_id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Movie has been added to you favourite list", "Fav list");

            addFav.Visible = false;
            removeFav.Visible = true;
        }

        //function to add selected episode to fav
        private void add_fav_episode()
        {
            int series_id = -1;
            int episode_id = -1;
            string seriesTile = Title.Text;
            string[] seriesPart = seriesTile.Split('\n');

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_id from series where s_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", seriesPart[0]);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                series_id = int.Parse(dr[0].ToString());
            }
            dr.Close();

            string[] episodeData = seriesPart[1].Split(',');
            string episode_num = episodeData[0].Substring(5, 1);
            string episode_season = episodeData[1].Substring(9, 1);

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ep_id from episode where seriesid = :id and ep_number = :num and ep_season = :season";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", series_id);
            cmd.Parameters.Add("num", episode_num);
            cmd.Parameters.Add("season", episode_season);
            dr = cmd.ExecuteReader();
            if (dr.Read())
                episode_id = int.Parse(dr[0].ToString());

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into adds_episode values (:userid, :episode)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("userid", user_id);
            cmd.Parameters.Add("episode", episode_id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Episode has been added to you favourite list", "Fav list");

            addFav.Visible = false;
            removeFav.Visible = true;
        }

        //add fav icon
        private void addFav_MouseClick(object sender, MouseEventArgs e)
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
                    isMovie = true;

                if (isMovie)
                    add_fav_movie();

                else
                {

                    string seriesTile = Title.Text;
                    string[] seriesPart = seriesTile.Split('\n');

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select s_id from series where s_name = :name";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("name", seriesPart[0]);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        isSeries = true;
                    dr.Close();

                    if (isSeries)
                        add_fav_episode();
                }
                conn.Close();

                isMovie = false;
                isSeries = false;
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

        //function to add selected movie to history
        public PlayVideo vidd;
        private void add_his_movie()
        {
            int movie_id = -1;
            bool hasSub = false;
            bool isfree = false;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_id, mov_type, mov_vid from movie where mov_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Title.Text);
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                movie_id = int.Parse(dr[0].ToString());
                if (dr[1].ToString() == "premium")
                {
                    OracleCommand com = new OracleCommand();
                    com.Connection = conn;
                    com.CommandText = "select * from subscribtion where userid=:id";
                    com.Parameters.Add("id", user_id);
                    OracleDataReader odr = com.ExecuteReader();
                    if (odr.Read())
                    {
                        hasSub = true;
                        vid_data = (byte[])dr[2];

                    }
                    odr.Close();
                }
                else
                {
                    isfree = true;
                    vid_data = (byte[])dr[2];
                }
            }
            dr.Close();

            if (hasSub || isfree)
            {
                int count = 1;
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select watch_time from watches_movie where userid = :u_id and movieid = :m_id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("u_id", user_id);
                cmd.Parameters.Add("m_id", movie_id);
                OracleDataReader d = cmd.ExecuteReader();
                if (d.Read())
                {
                    count = int.Parse(d[0].ToString()) + 1;

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "update watches_movie set watch_time = :counter where userid = :u_id and movieid = :m_id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("counter", count);
                    cmd.Parameters.Add("u_id", user_id);
                    cmd.Parameters.Add("m_id", movie_id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into watches_movie values (:userid, :movieid, :counter)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("userid", user_id);
                    cmd.Parameters.Add("movieid", movie_id);
                    cmd.Parameters.Add("counter", count);
                    cmd.ExecuteNonQuery();    
                }
                d.Close();

                vidd = new PlayVideo();
                this.Parent.Parent.Parent.Parent.Controls.Add(vidd);
                vidd.Dock = DockStyle.Fill;
                vidd.BringToFront();
            }
            else
                MessageBox.Show("Please subscribe to be able to watch all premium movies", "You can't watch this movie");
        }

        //function to add selected episode to history
        private void add_his_episode()
        {
            int series_id = -1;
            int episode_id = -1;
            bool hasSub = false;
            bool isfree = false;
            string seriesTile = Title.Text;
            string[] seriesPart = seriesTile.Split('\n');
            string[] episodeData = seriesPart[1].Split(',');
            string episode_num = episodeData[0].Substring(5, 1);
            string episode_season = episodeData[1].Substring(9, 1);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_id, s_type from series where s_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", seriesPart[0]);
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                series_id = int.Parse(dr[0].ToString());
                if (dr[1].ToString() == "premium")
                {
                    OracleCommand com = new OracleCommand();
                    com.Connection = conn;
                    com.CommandText = "select * from subscribtion where userid=:id";
                    com.Parameters.Add("id", user_id);
                    OracleDataReader odr = com.ExecuteReader();
                    if (odr.Read())
                    {
                        hasSub = true;

                    }
                    odr.Close();
                }
                else
                    isfree = true;
            }
            dr.Close();

            if (hasSub || isfree)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ep_id, ep_vid from episode where seriesid = :id and ep_number = :num and ep_season = :season";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", series_id);
                cmd.Parameters.Add("num", episode_num);
                cmd.Parameters.Add("season", episode_season);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    episode_id = int.Parse(dr[0].ToString());
                    vid_data = (byte[])dr[1];
                }
                dr.Close();

                int count = 1;

                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select watch_time from watches_episode where userid = :u_id and episodeid = :e_id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("u_id", user_id);
                cmd.Parameters.Add("e_id", episode_id);
                OracleDataReader d = cmd.ExecuteReader();
                if (d.Read())
                {
                    count = int.Parse(d[0].ToString()) + 1;
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "update watches_episode set watch_time = :counter where userid = :u_id and episodeid = :e_id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("counter", count);
                    cmd.Parameters.Add("u_id", user_id);
                    cmd.Parameters.Add("e_id", episode_id);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into watches_episode values (:userid, :episodeid, :counter)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("userid", user_id);
                    cmd.Parameters.Add("episodeid", episode_id);
                    cmd.Parameters.Add("counter", count);
                    cmd.ExecuteNonQuery();
                }
                d.Close();
                vidd = new PlayVideo();
                this.Parent.Parent.Parent.Parent.Controls.Add(vidd);
                vidd.Dock = DockStyle.Fill;
                vidd.BringToFront();
            }
            else
                MessageBox.Show("Please subscribe to be able to watch all premium episodes", "You can't watch this movie");
        }

        //play btn
        private void playBtn_MouseClick(object sender, MouseEventArgs e)
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
                isMovie = true;

            if (isMovie)
                add_his_movie();
            else
            {
                string seriesTile = Title.Text;
                string[] seriesPart = seriesTile.Split('\n');
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select s_id from series where s_name = :name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("name", seriesPart[0]);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    isSeries = true;

                dr.Close();


                if (isSeries)
                    add_his_episode();

            }

           conn.Close();

           isMovie = false;
           isSeries = true;
        }

        //function to remove selected movie from fav
        private void remove_fav_movie()
        {
            int movie_id = -1;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select mov_id from movie where mov_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", Title.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                movie_id = int.Parse(dr[0].ToString());
            }
            dr.Close();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "remove_fav_movie";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("user_id", user_id);
            cmd.Parameters.Add("mov_id", movie_id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Movie has been removed to you favourite list", "Fav list");
        }

        //function to remove selected episode from fav
        private void remove_fav_episode()
        {
            int series_id = -1;
            int episode_id = -1;
            string seriesTile = Title.Text;
            string[] seriesPart = seriesTile.Split('\n');
            string[] episodeData = seriesPart[1].Split(',');
            string episode_num = episodeData[0].Substring(5, 1);
            string episode_season = episodeData[1].Substring(9, 1);

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s_id from series where s_name = :name";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", seriesPart[0]);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                series_id = int.Parse(dr[0].ToString());
            }
            
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ep_id from episode where seriesid = :id and ep_number = :num and ep_season = :season";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", series_id);
            cmd.Parameters.Add("num", int.Parse(episode_num));
            cmd.Parameters.Add("season", int.Parse(episode_season));
            dr = cmd.ExecuteReader();
            if (dr.Read())
                episode_id = int.Parse(dr[0].ToString());

            dr.Close();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "remove_fav_episode";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("user_id", user_id);
            cmd.Parameters.Add("e_id", episode_id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Episode has been removed to you favourite list", "Fav list");
        }

        //remove fav btn
        private void removeFav_MouseClick(object sender, MouseEventArgs e)
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
                    isMovie = true;

                if (isMovie)
                    remove_fav_movie();

                else
                {
                    string seriesTile = Title.Text;
                    string[] seriesPart = seriesTile.Split('\n');
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select s_id from series where s_name = :name";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("name", seriesPart[0]);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                        isSeries = true;

                    dr.Close();

                    if (isSeries)
                        remove_fav_episode();
                }
                conn.Close();

                addFav.Visible = true;
                removeFav.Visible = false;

                isMovie = false;
                isSeries = false;
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
