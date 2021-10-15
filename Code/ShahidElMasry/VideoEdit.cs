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
    public partial class VideoEdit : UserControl
    {
        string img_path;
        string vid_path;

        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;

        bool oldSeries = false;
        
        int old_id;
        public VideoEdit()
        {
            InitializeComponent();
        }

        private void VideoEdit_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void choosePic_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                img_path = dialog.FileName;
                poster.ImageLocation = img_path;
            }
        }

        //function to update movie point 3
        private void update_movie()
        {
            int mov_id = VideoDetails.movie_id;

            OracleCommand cmd;
            byte[] imgData = null;
            byte[] vidData = null;
            //lw el sora mt3mlhash edit hna5odhaa men el gdwal
            if (img_path == null)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select mov_img from movie where mov_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", mov_id);
                cmd.ExecuteNonQuery();

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imgData = (byte[])dr[0];
                }
                dr.Close();
            }
            //lw et3mlha edit hna5odha men el path
            else
            {
                FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                FileInfo fi = new FileInfo(img_path);
                imgData = br.ReadBytes((int)fi.Length);
                fs.Close();
                br.Close();
            }
            //lw el video mt3mlosh edit hn5do men el table
            if(vid_path == null)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select mov_vid from movie where mov_id = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", mov_id);
                cmd.ExecuteNonQuery();

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    vidData = (byte[])dr[0];
                }
                dr.Close();
            }
            //lw mt3mlosh edit hna5do men el path
            else
            {
                FileStream fsv = new FileStream(vid_path, FileMode.Open, FileAccess.Read);
                BinaryReader brv = new BinaryReader(fsv);
                FileInfo fiv = new FileInfo(vid_path);
                vidData = brv.ReadBytes((int)fiv.Length);
                fsv.Close();
                brv.Close();
            }

            //update_movie
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update movie set mov_name = :m_name, mov_desc = :m_desc, mov_rate = :m_rate, mov_len = :m_len, mov_lang = :m_lang, mov_date = :m_date, mov_img = :m_img, mov_type = :m_type, mov_vid = :m_vid where mov_id = :m_id";
            cmd.BindByName = true;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("m_name", title.Text);
            cmd.Parameters.Add("m_desc", richTextBox1.Text);
            cmd.Parameters.Add("m_rate", int.Parse(rate.Text));
            cmd.Parameters.Add("m_len", int.Parse(len.Text));
            cmd.Parameters.Add("m_lang", lang.SelectedItem);
            cmd.Parameters.Add(new OracleParameter("m_date", OracleDbType.Date)).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("m_img", (object)imgData);
            if (checkBox1.Checked)
                cmd.Parameters.Add("m_type", "premium");
            else
                cmd.Parameters.Add("m_type", "free");

            cmd.Parameters.Add(new OracleParameter("m_vid", OracleDbType.Blob)).Value = vidData;

            cmd.Parameters.Add("m_id", mov_id);

            cmd.ExecuteNonQuery();


            MessageBox.Show("Movie data Saved", "Movie");
        }

        //function to update episode series point 3
        private void update_ep_series()
        {
            int s_id = VideoDetails.series_id;
            int episode_num = VideoDetails.episode_num;
            int episode_season = VideoDetails.episode_season;

            OracleCommand cmd;
            byte[] imgData = null;
            byte[] vidData = null;

            if (img_path == null)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ep_img from episode where ep_number = :e_num and ep_season = :e_season and seriesid = :s_id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("e_num", episode_num);
                cmd.Parameters.Add("e_season", episode_season);
                cmd.Parameters.Add("id", s_id);
                cmd.ExecuteNonQuery();

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    imgData = (byte[])dr[0];
                }
                dr.Close();
            }
            else
            {
                FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                FileInfo fi = new FileInfo(img_path);
                imgData = br.ReadBytes((int)fi.Length);
                fs.Close();
                br.Close();
            }

            if(vid_path == null)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select ep_vid from episode where ep_number = :e_num and ep_season = :e_season and seriesid = :s_id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("e_num", episode_num);
                cmd.Parameters.Add("e_season", episode_season);
                cmd.Parameters.Add("id", s_id);
                cmd.ExecuteNonQuery();

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    vidData = (byte[])dr[0];
                }
                dr.Close();
            }

            //update_series
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update series set s_name = :se_name, s_desc = :se_desc, s_rate = :se_rate, s_lang = :se_lang, s_type = :se_type where s_id = :se_id";
            cmd.BindByName = true;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("se_name", title.Text);
            cmd.Parameters.Add("se_desc", richTextBox1.Text);
            cmd.Parameters.Add("se_rate", int.Parse(rate.Text));
            cmd.Parameters.Add("se_lang", lang.SelectedItem);
            
            if (checkBox1.Checked)
                cmd.Parameters.Add("se_type", "premium");
            else
                cmd.Parameters.Add("se_type", "free");

            cmd.Parameters.Add("se_id", s_id);

            cmd.ExecuteNonQuery();

            string data = episode.Text;
            string[] part = data.Split(',');
            string num = part[0].Substring(5, 1);
            string seas = part[1].Substring(9,1);
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update episode set ep_number = :num, ep_season = :season, ep_len = :len, ep_date = :edate, ep_img = :img, ep_vid = :vid where seriesid = :se_id and ep_number = :oldnum and ep_season = :oldseason";
            cmd.BindByName = true;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("num", int.Parse(num));
            cmd.Parameters.Add("season", int.Parse(seas));
            cmd.Parameters.Add("len", int.Parse(len.Text));
            cmd.Parameters.Add(new OracleParameter("edate", OracleDbType.Date)).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("img", (object)imgData);
            cmd.Parameters.Add(new OracleParameter("vid", OracleDbType.Blob)).Value = vidData;
            cmd.Parameters.Add("se_id", s_id);
            cmd.Parameters.Add("oldnum", episode_num);
            cmd.Parameters.Add("oldseason", episode_season);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Data Saved", "Update");
        }

        //save btn
        private void Save_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                
                bool isMovie = VideoDetails.isMovie;

                if(isMovie)
                    update_movie();

                bool isSeries = VideoDetails.isSeries;
                if (isSeries)
                    update_ep_series();

                VideoDetails.isSeries = false;
                VideoDetails.isMovie = false;
             
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
            this.Parent.Controls.Remove(this);
        }

        private void add_actor_MouseClick(object sender, MouseEventArgs e)
        {
            actors_LBox.Items.Add(actor.Text + "," + dateTimePicker2.Value.ToString());
            actor.Clear();
            actor.Text = "1st Name,2nd Name,F/M";
            actor.ForeColor = Color.Silver;
        }

        private void actor_MouseClick(object sender, MouseEventArgs e)
        {
            if (actor.Text == "1st Name,2nd Name,F/M")
            {
                actor.Text = "";
                actor.ForeColor = Color.Black;
            }
        }

        private void actor_Leave(object sender, EventArgs e)
        {
            if (actor.Text == "")
            {
                actor.Text = "1st Name,2nd Name,F/M";
                actor.ForeColor = Color.Silver;
            }
        }

        private void add_genre_MouseClick(object sender, MouseEventArgs e)
        {
            genres_LBox.Items.Add(genre_CBox.SelectedItem);
        }

        //function to add movie point 3, 4 and 6
        private void add_movie()
        {
            FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            FileInfo fi = new FileInfo(img_path);
            byte[] imgData = br.ReadBytes((int)fi.Length);
            fs.Close();
            br.Close();

            FileStream fsv = new FileStream(vid_path, FileMode.Open, FileAccess.Read);
            BinaryReader brv = new BinaryReader(fsv);
            FileInfo fiv = new FileInfo(vid_path);
            byte[] vidData = brv.ReadBytes((int)fiv.Length);
            fsv.Close();
            brv.Close();

            conn = new OracleConnection(ordb);
            conn.Open();

            //add movie
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into movie (mov_name, mov_desc, mov_rate, mov_len, mov_lang, mov_date, mov_img, mov_type, mov_vid) values (:m_name, :m_desc, :m_rate, :m_len, :m_lang, :m_date, :m_img, :m_type, :m_vid)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("m_name", title.Text);
            cmd.Parameters.Add("m_desc", richTextBox1.Text);
            cmd.Parameters.Add("m_rate", float.Parse(rate.Text));
            cmd.Parameters.Add("m_len", int.Parse(len.Text));
            cmd.Parameters.Add("m_lang", lang.SelectedItem);
            cmd.Parameters.Add(new OracleParameter("m_date", OracleDbType.Date)).Value = dateTimePicker1.Value;
            cmd.Parameters.Add("m_img", (object)imgData);
            if (checkBox1.Checked)
                cmd.Parameters.Add("m_type", "premium");
            else
                cmd.Parameters.Add("m_type", "free");

            cmd.Parameters.Add(new OracleParameter("m_vid", OracleDbType.Blob)).Value = vidData;
            cmd.ExecuteNonQuery();

            //get_movie_id
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_movie_id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("m_name", title.Text);
            cmd.Parameters.Add("m_id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();

            int movie_id = int.Parse(cmd.Parameters["m_id"].Value.ToString());

            //add movie genre/s using procedure
            for (int i = 0; i < genres_LBox.Items.Count; i++)
            {
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert_movie_genre";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("m_id", movie_id);
                cmd.Parameters.Add("g_name", genres_LBox.Items[i].ToString());

                cmd.ExecuteNonQuery();
            }

            //lw el actor mawgod
            if (all_LBox.Items.Count > 0)
            {
                for (int i = 0; i < all_LBox.Items.Count; i++)
                {
                    string all_info = all_LBox.Items[i].ToString();
                    string[] part = all_info.Split(' ');

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "get_actor_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("fname", part[0]);
                    cmd.Parameters.Add("sname", part[1]);
                    cmd.Parameters.Add("actor_id", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();

                    int old_actor_id = int.Parse(cmd.Parameters["actor_id"].Value.ToString());

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert_movie_acted_by";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("a_id", old_actor_id);
                    cmd.Parameters.Add("m_id", movie_id);

                    cmd.ExecuteNonQuery();
                }
            }
            //lw el actor gdeed
            if (actors_LBox.Items.Count > 0)
            {
                for (int i = 0; i < actors_LBox.Items.Count; i++)
                {
                    string all_info = actors_LBox.Items[i].ToString();
                    string[] part = all_info.Split(',');

                    //insert_actor
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert_actor";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("fname", part[0]);
                    cmd.Parameters.Add("lname", part[1]);
                    if (part[2] == "F")
                        cmd.Parameters.Add("gender", "Female");
                    else
                        cmd.Parameters.Add("gender", "Male");

                    cmd.Parameters.Add(new OracleParameter("bdate", OracleDbType.Date)).Value = Convert.ToDateTime(part[3]);

                    cmd.ExecuteNonQuery();

                    //get_actor_id
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "get_actor_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("fname", part[0]);
                    cmd.Parameters.Add("sname", part[1]);
                    cmd.Parameters.Add("actor_id", OracleDbType.Int32, ParameterDirection.Output);
                    cmd.ExecuteNonQuery();

                    int actor_id = int.Parse(cmd.Parameters["actor_id"].Value.ToString());

                    //insert_movie_acted_by
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert_movie_acted_by";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("a_id", actor_id);
                    cmd.Parameters.Add("m_id", movie_id);
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
            MessageBox.Show("Movie added", "Movie");
        }

        //function to add series point 3, 4 and 6
        private void add_episode()
        {
            FileStream fs = new FileStream(img_path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            FileInfo fi = new FileInfo(img_path);
            byte[] imgData = br.ReadBytes((int)fi.Length);
            fs.Close();
            br.Close();

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd;

            if (oldSeries == false)
            {
                //add series
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into series (s_name, s_desc, s_rate, s_lang, s_type) values (:sname, :sdesc, :srate, :slang, :stype)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("sname", title.Text);
                cmd.Parameters.Add("sdesc", richTextBox1.Text);
                cmd.Parameters.Add("srate", int.Parse(rate.Text));
                cmd.Parameters.Add("slang", lang.SelectedItem);
                if (checkBox1.Checked)
                    cmd.Parameters.Add("stype", "premium");
                else
                    cmd.Parameters.Add("stype", "free");

                cmd.ExecuteNonQuery();

                //get_series_id
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "get_series_id";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("series_name", title.Text);
                cmd.Parameters.Add("series_id", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();

                int series_id = int.Parse(cmd.Parameters["series_id"].Value.ToString());

                string episode_data = episode.Text;
                string[] ep_part = episode_data.Split(',');
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into episode (ep_number, ep_season, ep_len, ep_date, seriesid, ep_img, ep_vid) values (:num, :season, :len, :sdate, :id, :img, :vid)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("num", int.Parse(ep_part[0]));
                cmd.Parameters.Add("season", int.Parse(ep_part[1]));
                cmd.Parameters.Add("len", int.Parse(len.Text));
                cmd.Parameters.Add(new OracleParameter("sdate", OracleDbType.Date)).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("id", series_id);
                cmd.Parameters.Add("img", (object)imgData);

                cmd.Parameters.Add(new OracleParameter("vid", OracleDbType.Blob)).Value = File.ReadAllBytes(vid_path);

                cmd.ExecuteNonQuery();

                //add series genre/s using procedure
                for (int i = 0; i < genres_LBox.Items.Count; i++)
                {
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "insert_series_genre";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("series_id", series_id);
                    cmd.Parameters.Add("g_name", genres_LBox.Items[i].ToString());

                    cmd.ExecuteNonQuery();
                }

                //lw el actor mawgod
                if (all_LBox.Items.Count > 0)
                {
                    for (int i = 0; i < all_LBox.Items.Count; i++)
                    {
                        string all_info = all_LBox.Items[i].ToString();
                        string[] part = all_info.Split(' ');

                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "get_actor_id";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("fname", part[0]);
                        cmd.Parameters.Add("sname", part[1]);
                        cmd.Parameters.Add("actor_id", OracleDbType.Int32, ParameterDirection.Output);
                        cmd.ExecuteNonQuery();

                        int old_actor_id = int.Parse(cmd.Parameters["actor_id"].Value.ToString());

                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert_series_acted_by";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("a_id", old_actor_id);
                        cmd.Parameters.Add("m_id", series_id);

                        cmd.ExecuteNonQuery();
                    }
                }
                //lw el actor gdeed
                if (actors_LBox.Items.Count > 0)
                {
                    for (int i = 0; i < actors_LBox.Items.Count; i++)
                    {
                        string all_info = actors_LBox.Items[i].ToString();
                        string[] part = all_info.Split(',');

                        //insert_actor
                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert_actor";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("fname", part[0]);
                        cmd.Parameters.Add("lname", part[1]);
                        if (part[2] == "F")
                            cmd.Parameters.Add("gender", "Female");
                        else
                            cmd.Parameters.Add("gender", "Male");

                        cmd.Parameters.Add(new OracleParameter("bdate", OracleDbType.Date)).Value = Convert.ToDateTime(part[3]);

                        cmd.ExecuteNonQuery();

                        //get_actor_id
                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "get_actor_id";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("fname", part[0]);
                        cmd.Parameters.Add("sname", part[1]);
                        cmd.Parameters.Add("actor_id", OracleDbType.Int32, ParameterDirection.Output);
                        cmd.ExecuteNonQuery();

                        int actor_id = int.Parse(cmd.Parameters["actor_id"].Value.ToString());

                        //insert_series_acted_by
                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "insert_series_acted_by";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("a_id", actor_id);
                        cmd.Parameters.Add("m_id", series_id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                string episode_data = episode.Text;
                string[] ep_part = episode_data.Split(',');
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into episode (ep_number, ep_season, ep_len, ep_date, seriesid, ep_img, ep_vid) values (:num, :season, :len, :sdate, :id, :img, :vid)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("num", int.Parse(ep_part[0]));
                cmd.Parameters.Add("season", int.Parse(ep_part[1]));
                cmd.Parameters.Add("len", int.Parse(len.Text));
                cmd.Parameters.Add(new OracleParameter("sdate", OracleDbType.Date)).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("id", old_id);
                cmd.Parameters.Add("img", (object)imgData);
                cmd.Parameters.Add(new OracleParameter("vid", OracleDbType.Blob)).Value = File.ReadAllBytes(vid_path);

                cmd.ExecuteNonQuery();
            }
            conn.Close();
            MessageBox.Show("Episode added", "Episode");
        }

        //add btn
        private void Add_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (genres_LBox.Items.Count == 0)
                    MessageBox.Show("You must choose genre", "cannot add");
                if (actors_LBox.Items.Count == 0 && all_LBox.Items.Count == 0)
                    MessageBox.Show("you must add actor either already exist or new one");
                if (genres_LBox.Items.Count != 0 && (actors_LBox.Items.Count != 0 || all_LBox.Items.Count != 0))
                {
                    if (movieRB.Checked)
                        add_movie();
                    else if (epRB.Checked)
                        add_episode();

                    this.Parent.Controls.Remove(this);
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
        }

        //function to delete movie point 6
        private void delete_movie()
        {
            int mov_id = VideoDetails.movie_id;
            //delete movie
            OracleCommand cmd = new OracleCommand();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete_movie";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("m_id", mov_id);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Movie deleted", "Movie");
        }

        //function delete episode point 6
        private void delete_episode()
        {
            int s_id = VideoDetails.series_id;
            int episode_num = VideoDetails.episode_num;
            int episode_season = VideoDetails.episode_season;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select count(*) from episode where seriesid = :id";
            cmd.Parameters.Add("id", s_id);

            OracleDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                //lw dyh a5ir episode fel series el series hytmsee7
                if(int.Parse(dr[0].ToString()) == 1)
                {
                    var option = MessageBox.Show("This is the last episode in the series\n Note that if you delete it the series will be deleted as well\nAre you sure you want to delete episode?", "Warning", MessageBoxButtons.YesNo);

                    if (option == DialogResult.Yes)
                    {
                        //delete last episode and series
                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "delete_series";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("e_num", episode_num);
                        cmd.Parameters.Add("e_season", episode_season);
                        cmd.Parameters.Add("se_id", s_id);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Episode and series deleted", "Series");
                    }
                }
                else
                {
                    //delete episode
                    cmd = new OracleCommand();
                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "delete_episode";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("ep_num", episode_num);
                    cmd.Parameters.Add("ep_season", episode_season);
                    cmd.Parameters.Add("s_id", s_id);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Episode deleted", "Episode");
                }
            }
            dr.Close();
        }

        private void delete_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                bool isMovie = VideoDetails.isMovie;
                if (isMovie)
                {
                    var option = MessageBox.Show("Are you sure you want to delete movie?", "Warning", MessageBoxButtons.YesNo);
                    if (option == DialogResult.Yes)
                        delete_movie();
                }

                bool isSeries = VideoDetails.isSeries;
                if (isSeries)
                {
                    var option = MessageBox.Show("Are you sure you want to delete episode?", "Warning", MessageBoxButtons.YesNo);
                    if (option == DialogResult.Yes)
                        delete_episode();
                }
                VideoDetails.isMovie = false;
                VideoDetails.isSeries = false;
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
            this.Parent.Controls.Remove(this);
        }

        private void add_ex_actor_MouseClick(object sender, MouseEventArgs e)
        {
            all_LBox.Items.Add(actorsCBox.SelectedItem);
        }

        //display all series in seriesCBox point 5
        private void epRB_CheckedChanged(object sender, EventArgs e)
        {
            if (epRB.Checked)
            {
                seriesCBox.Visible = true;
                label1.Visible = true;
                label13.Visible = true;
                episode.Visible = true;

                //display all series in the series table in seriesCBox
                OracleConnection conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "get_series_names";
                c.CommandType = CommandType.StoredProcedure;
                c.Parameters.Add("all_series", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader d = c.ExecuteReader();

                while (d.Read())
                {
                    seriesCBox.Items.Add(d[0]);
                }
                d.Close();
                conn.Close();

            }
        }

        private void movieRB_CheckedChanged(object sender, EventArgs e)
        {
            if (movieRB.Checked)
            {
                seriesCBox.Visible = false;
                label1.Visible = false;
                label13.Visible = false;
                episode.Visible = false;
            }
        }

        //lw 3mal select series name hy3mel add lel episode bel series id el mawgod
        //select series info point 2
        private void seriesCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seriesCBox.SelectedIndex != 0)
            {
                conn = new OracleConnection(ordb);
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from series where s_name = :name";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("name", seriesCBox.SelectedItem.ToString());

                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    old_id = int.Parse(dr[0].ToString());
                    title.Text = dr[1].ToString();
                    richTextBox1.Text = dr[2].ToString();
                    rate.Text = dr[3].ToString();
                    lang.Text = dr[4].ToString();
                    if (dr[5].ToString() == "free")
                        checkBox1.Checked = false;
                    else
                        checkBox1.Checked = true;

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select gen_name from series_genre where seriesid = :id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                    OracleDataReader odr = cmd.ExecuteReader();
                    while (odr.Read())
                    {
                        genres_LBox.Items.Add(odr[0].ToString());
                    }

                    cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select actorid from series_acted_by where seriesid = :id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("id", int.Parse(dr[0].ToString()));
                    odr = cmd.ExecuteReader();
                    while (odr.Read())
                    {
                        cmd = new OracleCommand();
                        cmd.Connection = conn;
                        cmd.CommandText = "select a_fname, a_lname, a_gender, a_bdate from actor where a_id = :id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add("id", int.Parse(odr[0].ToString()));
                        OracleDataReader d = cmd.ExecuteReader();
                        while (d.Read())
                        {
                            all_LBox.Items.Add(d[0].ToString() + " " + d[1].ToString() + ", " + d[2].ToString() + ", " + d[3].ToString());
                        }
                        d.Close();
                    }
                    odr.Close();

                }
                dr.Close();
                conn.Close();

                oldSeries = true;

                title.Enabled = false;
                richTextBox1.Enabled = false;
                lang.Enabled = false;
                rate.Enabled = false;
                checkBox1.Enabled = false;
                genres_LBox.Enabled = false;
                all_LBox.Enabled = false;
                genre_CBox.Visible = false;
                add_genre.Visible = false;
                actors_LBox.Visible = false;
                actorsCBox.Visible = false;
                actor.Visible = false;
                add_actor.Visible = false;
                label7.Visible = false;
                add_ex_actor.Visible = false;
                dateTimePicker2.Visible = false;
            }
            else
            {
                title.Clear();
                richTextBox1.Clear();
                rate.Clear();
                checkBox1.Checked = false;
                genres_LBox.Items.Clear();
                all_LBox.Items.Clear();

                oldSeries = false;

                title.Enabled = true;
                richTextBox1.Enabled = true;
                lang.Enabled = true;
                rate.Enabled = true;
                checkBox1.Enabled = true;
                genres_LBox.Enabled = true;
                all_LBox.Enabled = true;
                genre_CBox.Visible = true;
                add_genre.Visible = true;
                actors_LBox.Visible = true;
                actorsCBox.Visible = true;
                actor.Visible = true;
                add_actor.Visible = true;
                label7.Visible = true;
                add_ex_actor.Visible = true;
                dateTimePicker2.Visible = true;
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (episode.Text == "episode num,season num")
            {
                episode.Text = "";
                episode.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (episode.Text == "")
            {
                episode.Text = "episode num,season num";
                episode.ForeColor = Color.Silver;
            }
        }

        private void vidBtn_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All Files(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                vid_path = dialog.FileName;
            }
        }

    }
}
