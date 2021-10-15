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
    public partial class Admin : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        bool movieFound = false;
        bool seriesFound = false;
        public Admin()
        {
            InitializeComponent();
        }

        private void Exit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        //function of display movies using adapter and dataset point 2
        private void display_movie()
        {
            OracleDataAdapter number_adapter;
            OracleDataAdapter movie_adapter, movie_genre_adapter, actors_adapter, a_id_adapter;
            DataSet movie_details_ds, numbers_ds;

            //get number of movies
            number_adapter = new OracleDataAdapter("select count(*) from movie", ordb);
            numbers_ds = new DataSet();
            number_adapter.Fill(numbers_ds, "num_movie");

            //get data of all movies
            movie_adapter = new OracleDataAdapter("select * from movie", ordb);
            movie_details_ds = new DataSet();
            movie_adapter.Fill(movie_details_ds, "movie");

            for (int i = 0; i < int.Parse(numbers_ds.Tables["num_movie"].Rows[0][0].ToString()); i++)
            {

                VideoDetails vid = new VideoDetails();

                vid.Title.Text = movie_details_ds.Tables["movie"].Rows[i][1].ToString();
                vid.Desc.Text = movie_details_ds.Tables["movie"].Rows[i][2].ToString();
                vid.rate.Text += movie_details_ds.Tables["movie"].Rows[i][3].ToString();
                vid.dur.Text += movie_details_ds.Tables["movie"].Rows[i][4].ToString();
                vid.lang.Text += movie_details_ds.Tables["movie"].Rows[i][5].ToString();
                vid.rdate.Text += Convert.ToDateTime(movie_details_ds.Tables["movie"].Rows[i][6]).ToShortDateString();
                //image
                byte[] img_data = (byte[])movie_details_ds.Tables["movie"].Rows[i][7];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.pictureBox1.Image = bm;
                ms.Dispose();

                if (movie_details_ds.Tables["movie"].Rows[i][8].ToString() == "premium")
                    vid.per_label.Visible = true;
                else if (movie_details_ds.Tables["movie"].Rows[i][8].ToString() == "free")
                    vid.per_label.Visible = false;

                //get number of genres of movie i
                number_adapter = new OracleDataAdapter("select count(*) from movie_genre where movieid = :id", ordb);
                number_adapter.SelectCommand.Parameters.Add("id", int.Parse(movie_details_ds.Tables["movie"].Rows[i][0].ToString()));
                number_adapter.Fill(numbers_ds, "num_gen");

                //get genres of movie i
                movie_genre_adapter = new OracleDataAdapter("select * from movie_genre where movieid = :id", ordb);
                movie_genre_adapter.SelectCommand.Parameters.Add("id", int.Parse(movie_details_ds.Tables["movie"].Rows[i][0].ToString()));
                movie_genre_adapter.Fill(movie_details_ds, "movie_genre");
                for (int j = 0; j < int.Parse(numbers_ds.Tables["num_gen"].Rows[0][0].ToString()); j++)
                {
                    vid.gen.Text = vid.gen.Text + movie_details_ds.Tables["movie_genre"].Rows[j][1] + " ";
                }

                //get number of actors of movie i
                number_adapter = new OracleDataAdapter("select count(*) from movie_acted_by where movieid = :id", ordb);
                number_adapter.SelectCommand.Parameters.Add("id", int.Parse(movie_details_ds.Tables["movie"].Rows[i][0].ToString()));
                number_adapter.Fill(numbers_ds, "num_actor");

                //get actors ids of movie i
                a_id_adapter = new OracleDataAdapter("select actorid from movie_acted_by where movieid = :id", ordb);
                a_id_adapter.SelectCommand.Parameters.Add("id", int.Parse(movie_details_ds.Tables["movie"].Rows[i][0].ToString()));
                a_id_adapter.Fill(movie_details_ds, "actor_id");

                //get data of actors of movie i
                for (int j = 0; j < int.Parse(numbers_ds.Tables["num_actor"].Rows[0][0].ToString()); j++)
                {
                    actors_adapter = new OracleDataAdapter("select * from actor where a_id = :id", ordb);
                    actors_adapter.SelectCommand.Parameters.Add("id", int.Parse(movie_details_ds.Tables["actor_id"].Rows[j][0].ToString()));
                    actors_adapter.Fill(movie_details_ds, "movie_actor");
                    vid.actorsBox.Text = vid.actorsBox.Text + "- " + movie_details_ds.Tables["movie_actor"].Rows[j][1] + " " + movie_details_ds.Tables["movie_actor"].Rows[j][2] + "\n  " + Convert.ToDateTime(movie_details_ds.Tables["movie_actor"].Rows[j][3]).ToShortDateString() + "\n  " + movie_details_ds.Tables["movie_actor"].Rows[j][4] + "\n  ";
                }

                numbers_ds.Tables.Remove("num_gen");
                movie_details_ds.Tables.Remove("movie_genre");
                numbers_ds.Tables.Remove("num_actor");
                movie_details_ds.Tables.Remove("actor_id");
                movie_details_ds.Tables.Remove("movie_actor");

                flowLayoutPanel1.Controls.Add(vid);
                vid.addrevbox.Visible = false;
                vid.AddRev.Visible = false;
                vid.revBox.Visible = false;
                vid.label9.Visible = false;
                vid.close.Visible = false;
                vid.label6.Visible = false;
                vid.label7.Visible = false;
                vid.my_rate.Visible = false;
                vid.edit.Visible = true;
            }
        }

        //function of display series using adapter and dataset point 2
        private void display_episode()
        {
            OracleDataAdapter series_adapter, episode_adapter, genre_adapter, actor_id_adapter, actors_adapter;
            OracleDataAdapter num_series_adapter, num_ep_adapter, num_genre_adapter, num_actor_adapter;
            DataSet s_ep_ds;

            s_ep_ds = new DataSet();

            //get all series
            num_series_adapter = new OracleDataAdapter("select count(*) from series", ordb);
            num_series_adapter.Fill(s_ep_ds, "num_all_series");

            //get data of all series
            series_adapter = new OracleDataAdapter("select * from series", ordb);
            series_adapter.Fill(s_ep_ds, "series");

            int series_id;
            for (int i = 0; i < int.Parse(s_ep_ds.Tables["num_all_series"].Rows[0][0].ToString()); i++)
            {
                series_id = int.Parse(s_ep_ds.Tables["series"].Rows[i][0].ToString());

                //get number of episodes of series i
                num_ep_adapter = new OracleDataAdapter("select count(*) from episode where seriesid = :id", ordb);
                num_ep_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_ep_adapter.Fill(s_ep_ds, "num_episode");

                //get data of episodes of series i
                episode_adapter = new OracleDataAdapter("select ep_number, ep_season, ep_len, ep_date, ep_img from episode where seriesid = :id", ordb);
                episode_adapter.SelectCommand.Parameters.Add("id", series_id);
                episode_adapter.Fill(s_ep_ds, "episode");

                //get number of genres of series i
                num_genre_adapter = new OracleDataAdapter("select count(*) from series_genre where seriesid = :id", ordb);
                num_genre_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_genre_adapter.Fill(s_ep_ds, "num_genres");

                //get genres names of series i
                genre_adapter = new OracleDataAdapter("select gen_name from series_genre where seriesid = :id", ordb);
                genre_adapter.SelectCommand.Parameters.Add("id", series_id);
                genre_adapter.Fill(s_ep_ds, "genres");

                //get number of actors of series i
                num_actor_adapter = new OracleDataAdapter("select count(*) from series_acted_by where seriesid = :id", ordb);
                num_actor_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_actor_adapter.Fill(s_ep_ds, "num_actors");

                //get id of actors of series i
                actor_id_adapter = new OracleDataAdapter("select actorid from series_acted_by where seriesid = :id", ordb);
                actor_id_adapter.SelectCommand.Parameters.Add("id", series_id);
                actor_id_adapter.Fill(s_ep_ds, "actor_id");

                for(int j = 0; j < int.Parse(s_ep_ds.Tables["num_episode"].Rows[0][0].ToString()); j++)
                {
                    VideoDetails vid = new VideoDetails();

                    vid.Title.Text = s_ep_ds.Tables["series"].Rows[i][1].ToString() + "\nEpisode : " + s_ep_ds.Tables["episode"].Rows[j][0].ToString() + ",Season : " + s_ep_ds.Tables["episode"].Rows[j][1].ToString();
                    vid.Desc.Text = s_ep_ds.Tables["series"].Rows[i][2].ToString();
                    vid.rate.Text += s_ep_ds.Tables["series"].Rows[i][3].ToString();
                    vid.dur.Text += s_ep_ds.Tables["episode"].Rows[j][2].ToString();
                    vid.lang.Text += s_ep_ds.Tables["series"].Rows[i][4].ToString();
                    vid.rdate.Text += Convert.ToDateTime(s_ep_ds.Tables["episode"].Rows[j][3]).ToShortDateString();
                    //image
                    byte[] img_data = (byte[])s_ep_ds.Tables["episode"].Rows[j][4];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.pictureBox1.Image = bm;
                    ms.Dispose();

                    if (s_ep_ds.Tables["series"].Rows[i][5].ToString() == "premium")
                        vid.per_label.Visible = true;
                    else if (s_ep_ds.Tables["series"].Rows[i][5].ToString() == "free")
                        vid.per_label.Visible = false;

                    for (int k = 0; k < int.Parse(s_ep_ds.Tables["num_genres"].Rows[0][0].ToString()); k++)
                    {
                        vid.gen.Text = vid.gen.Text + s_ep_ds.Tables["genres"].Rows[k][0] + " ";
                    }

                    for (int k = 0; k < int.Parse(s_ep_ds.Tables["num_actors"].Rows[0][0].ToString()); k++)
                    {
                        //get data of actors of series i
                        actors_adapter = new OracleDataAdapter("select * from actor where a_id = :id", ordb);
                        actors_adapter.SelectCommand.Parameters.Add("id", int.Parse(s_ep_ds.Tables["actor_id"].Rows[k][0].ToString()));
                        actors_adapter.Fill(s_ep_ds, "actor");
                        vid.actorsBox.Text = vid.actorsBox.Text + "- " + s_ep_ds.Tables["actor"].Rows[k][1] + " " + s_ep_ds.Tables["actor"].Rows[k][2] + "\n  " + Convert.ToDateTime(s_ep_ds.Tables["actor"].Rows[j][3]).ToShortDateString() + "\n  " + s_ep_ds.Tables["actor"].Rows[j][4] + "\n  ";
                    }
                    flowLayoutPanel1.Controls.Add(vid);
                    vid.addrevbox.Visible = false;
                    vid.AddRev.Visible = false;
                    vid.revBox.Visible = false;
                    vid.label9.Visible = false;
                    vid.close.Visible = false;
                    vid.label6.Visible = false;
                    vid.label7.Visible = false;
                    vid.my_rate.Visible = false;
                    vid.edit.Visible = true;
                }

                s_ep_ds.Tables.Remove("num_episode");
                s_ep_ds.Tables.Remove("episode");
                s_ep_ds.Tables.Remove("num_genres");
                s_ep_ds.Tables.Remove("genres");
                s_ep_ds.Tables.Remove("num_actors");
                s_ep_ds.Tables.Remove("actor_id");
                s_ep_ds.Tables.Remove("actor");
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);

            try
            {
                display_movie();
                display_episode();
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

        //add icon
        private void AddBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("VideoEdit");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("VideoEdit");

            VideoEdit vid = new VideoEdit();

            //display all actors in the actor table in actorsCBox
            OracleConnection conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "get_actors";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("all_actors", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader d = c.ExecuteReader();

            while (d.Read())
            {
                vid.actorsCBox.Items.Add(d[0] + " " + d[1]);
            }
            d.Close();
            conn.Close();
            
            splitContainer1.Panel2.Controls.Add(vid);
            vid.Dock = DockStyle.Fill;
            vid.BringToFront();
            vid.delete.Visible = false;
            vid.Save.Visible = false;
            vid.Add.Visible = true;
            VideoDetails.isSeries = false;
            VideoDetails.isMovie = false;
        }

        //home icon
        public void HomeBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("VideoEdit");
            if(contain)
                splitContainer1.Panel2.Controls.RemoveByKey("VideoEdit");
            flowLayoutPanel1.Controls.Clear();
            try
            {
                display_movie();
                display_episode();

                VideoDetails.isSeries = false;
                VideoDetails.isMovie = false;
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

        //function of search movie using adapter and dataset point 1
        private void search_movie()
        {
            //get number of rows of searched movie
            OracleDataAdapter search_film = new OracleDataAdapter("select count(*) from movie where mov_name like '%' || :title  || '%' ", ordb);
            search_film.SelectCommand.Parameters.Add("title", searchBox.Text);
            DataSet selected_movie_ds = new DataSet();
            search_film.Fill(selected_movie_ds, "num_movie");

            //get data of searched movie
            OracleDataAdapter selected_movie = new OracleDataAdapter("select * from movie where mov_name like '%' || :title  || '%' ", ordb);
            selected_movie.SelectCommand.Parameters.Add("title", searchBox.Text);
            selected_movie.Fill(selected_movie_ds, "movie");

            for (int i = 0; i < int.Parse(selected_movie_ds.Tables["num_movie"].Rows[0][0].ToString()); i++)
            {
                VideoDetails vid = new VideoDetails();

                vid.Title.Text = selected_movie_ds.Tables["movie"].Rows[i][1].ToString();
                vid.Desc.Text = selected_movie_ds.Tables["movie"].Rows[i][2].ToString();
                vid.rate.Text += selected_movie_ds.Tables["movie"].Rows[i][3].ToString();
                vid.dur.Text += selected_movie_ds.Tables["movie"].Rows[i][4].ToString();
                vid.lang.Text += selected_movie_ds.Tables["movie"].Rows[i][5].ToString();
                vid.rdate.Text += Convert.ToDateTime(selected_movie_ds.Tables["movie"].Rows[i][6]).ToShortDateString();
                //image
                byte[] img_data = (byte[])selected_movie_ds.Tables["movie"].Rows[i][7];
                MemoryStream ms = new MemoryStream();
                ms.Write(img_data, 0, img_data.Length);
                Bitmap bm = new Bitmap(ms, false);
                vid.pictureBox1.Image = bm;
                ms.Dispose();

                if (selected_movie_ds.Tables["movie"].Rows[i][8].ToString() == "premium")
                    vid.per_label.Visible = true;
                else if (selected_movie_ds.Tables["movie"].Rows[i][8].ToString() == "free")
                    vid.per_label.Visible = false;

                //get number of genres of movie i
                OracleDataAdapter selected_number_genre = new OracleDataAdapter("select count(*) from movie_genre where movieid = :id", ordb);
                selected_number_genre.SelectCommand.Parameters.Add("id", int.Parse(selected_movie_ds.Tables["movie"].Rows[i][0].ToString()));
                selected_number_genre.Fill(selected_movie_ds, "num_gen");

                //get genres of movie i
                OracleDataAdapter selected_genre = new OracleDataAdapter("select * from movie_genre where movieid = :id", ordb);
                selected_genre.SelectCommand.Parameters.Add("id", int.Parse(selected_movie_ds.Tables["movie"].Rows[i][0].ToString()));
                selected_genre.Fill(selected_movie_ds, "movie_genre");
                
                for (int j = 0; j < int.Parse(selected_movie_ds.Tables["num_gen"].Rows[0][0].ToString()); j++)
                {
                    vid.gen.Text = vid.gen.Text + selected_movie_ds.Tables["movie_genre"].Rows[j][1] + " ";
                }

                //get number of actors of movie i
                OracleDataAdapter selected_number_actors = new OracleDataAdapter("select count(*) from movie_acted_by where movieid = :id", ordb);
                selected_number_actors.SelectCommand.Parameters.Add("id", int.Parse(selected_movie_ds.Tables["movie"].Rows[i][0].ToString()));
                selected_number_actors.Fill(selected_movie_ds, "num_actor");

                //get actors ids of movie id
                OracleDataAdapter selected_actor_id = new OracleDataAdapter("select actorid from movie_acted_by where movieid = :id", ordb);
                selected_actor_id.SelectCommand.Parameters.Add("id", int.Parse(selected_movie_ds.Tables["movie"].Rows[i][0].ToString()));
                selected_actor_id.Fill(selected_movie_ds, "actor_id");

                OracleDataAdapter selected_actors;
                for (int j = 0; j < int.Parse(selected_movie_ds.Tables["num_actor"].Rows[0][0].ToString()); j++)
                {
                    //get actors of movie i
                    selected_actors = new OracleDataAdapter("select * from actor where a_id = :id", ordb);
                    selected_actors.SelectCommand.Parameters.Add("id", int.Parse(selected_movie_ds.Tables["actor_id"].Rows[j][0].ToString()));
                    selected_actors.Fill(selected_movie_ds, "movie_actor");
                    vid.actorsBox.Text = vid.actorsBox.Text + "- " + selected_movie_ds.Tables["movie_actor"].Rows[j][1] + " " + selected_movie_ds.Tables["movie_actor"].Rows[j][2] + "\n  " + Convert.ToDateTime(selected_movie_ds.Tables["movie_actor"].Rows[j][3]).ToShortDateString() + "\n  " + selected_movie_ds.Tables["movie_actor"].Rows[j][4] + "\n  ";
                }
                selected_movie_ds.Tables.Remove("num_gen");
                selected_movie_ds.Tables.Remove("movie_genre");
                selected_movie_ds.Tables.Remove("num_actor");
                selected_movie_ds.Tables.Remove("actor_id");
                selected_movie_ds.Tables.Remove("movie_actor");

                flowLayoutPanel1.Controls.Add(vid);
                vid.addrevbox.Visible = false;
                vid.AddRev.Visible = false;
                vid.revBox.Visible = false;
                vid.label9.Visible = false;
                vid.close.Visible = false;
                vid.label6.Visible = false;
                vid.label7.Visible = false;
                vid.my_rate.Visible = false;
                vid.edit.Visible = true;

                movieFound = true;
            }
        }

        //function of search series using adapter and dataset point 1
        private void search_episode()
        {
            OracleDataAdapter series_adapter, episode_adapter, genre_adapter, actor_id_adapter, actors_adapter;
            OracleDataAdapter num_series_adapter, num_ep_adapter, num_genre_adapter, num_actor_adapter;
            DataSet s_ep_ds = new DataSet();

            //get number searched series
            num_series_adapter = new OracleDataAdapter("select count(*) from series where s_name like '%' || :title  || '%' ",ordb);
            num_series_adapter.SelectCommand.Parameters.Add("title", searchBox.Text);
            num_series_adapter.Fill(s_ep_ds, "num_all_series");

            //get data of all series
            series_adapter = new OracleDataAdapter("select * from series where s_name like '%' || :title  || '%' ", ordb);
            series_adapter.SelectCommand.Parameters.Add("title", searchBox.Text);
            series_adapter.Fill(s_ep_ds, "series");

            int series_id;
            for (int i = 0; i < int.Parse(s_ep_ds.Tables["num_all_series"].Rows[0][0].ToString()); i++)
            {
                series_id = int.Parse(s_ep_ds.Tables["series"].Rows[i][0].ToString());

                //get number of episodes of series i
                num_ep_adapter = new OracleDataAdapter("select count(*) from episode where seriesid = :id", ordb);
                num_ep_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_ep_adapter.Fill(s_ep_ds, "num_episode");

                //get data of episodes of series i
                episode_adapter = new OracleDataAdapter("select ep_number, ep_season, ep_len, ep_date, ep_img from episode where seriesid = :id", ordb);
                episode_adapter.SelectCommand.Parameters.Add("id", series_id);
                episode_adapter.Fill(s_ep_ds, "episode");

                //get number of genres of series i
                num_genre_adapter = new OracleDataAdapter("select count(*) from series_genre where seriesid = :id", ordb);
                num_genre_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_genre_adapter.Fill(s_ep_ds, "num_genres");

                //get genres names of series i
                genre_adapter = new OracleDataAdapter("select gen_name from series_genre where seriesid = :id", ordb);
                genre_adapter.SelectCommand.Parameters.Add("id", series_id);
                genre_adapter.Fill(s_ep_ds, "genres");

                //get number of actors of series i
                num_actor_adapter = new OracleDataAdapter("select count(*) from series_acted_by where seriesid = :id", ordb);
                num_actor_adapter.SelectCommand.Parameters.Add("id", series_id);
                num_actor_adapter.Fill(s_ep_ds, "num_actors");

                //get id of actors of series i
                actor_id_adapter = new OracleDataAdapter("select actorid from series_acted_by where seriesid = :id", ordb);
                actor_id_adapter.SelectCommand.Parameters.Add("id", series_id);
                actor_id_adapter.Fill(s_ep_ds, "actor_id");

                for (int j = 0; j < int.Parse(s_ep_ds.Tables["num_episode"].Rows[0][0].ToString()); j++)
                {
                    VideoDetails vid = new VideoDetails();

                    vid.Title.Text = s_ep_ds.Tables["series"].Rows[i][1].ToString() + "\nEpisode : " + s_ep_ds.Tables["episode"].Rows[j][0].ToString() + " Season\n : " + s_ep_ds.Tables["episode"].Rows[j][1].ToString();
                    vid.Desc.Text = s_ep_ds.Tables["series"].Rows[i][2].ToString();
                    vid.rate.Text += s_ep_ds.Tables["series"].Rows[i][3].ToString();
                    vid.dur.Text += s_ep_ds.Tables["episode"].Rows[j][2].ToString();
                    vid.lang.Text += s_ep_ds.Tables["series"].Rows[i][4].ToString();
                    vid.rdate.Text += Convert.ToDateTime(s_ep_ds.Tables["episode"].Rows[j][3]).ToShortDateString();
                    //image
                    byte[] img_data = (byte[])s_ep_ds.Tables["episode"].Rows[j][4];
                    MemoryStream ms = new MemoryStream();
                    ms.Write(img_data, 0, img_data.Length);
                    Bitmap bm = new Bitmap(ms, false);
                    vid.pictureBox1.Image = bm;
                    ms.Dispose();

                    if (s_ep_ds.Tables["series"].Rows[i][5].ToString() == "premium")
                        vid.per_label.Visible = true;
                    else if (s_ep_ds.Tables["series"].Rows[i][5].ToString() == "free")
                        vid.per_label.Visible = false;

                    for (int k = 0; k < int.Parse(s_ep_ds.Tables["num_genres"].Rows[0][0].ToString()); k++)
                    {
                        vid.gen.Text = vid.gen.Text + s_ep_ds.Tables["genres"].Rows[k][0] + " ";
                    }

                    for (int k = 0; k < int.Parse(s_ep_ds.Tables["num_actors"].Rows[0][0].ToString()); k++)
                    {
                        //get data of actors of series i
                        actors_adapter = new OracleDataAdapter("select * from actor where a_id = :id", ordb);
                        actors_adapter.SelectCommand.Parameters.Add("id", int.Parse(s_ep_ds.Tables["actor_id"].Rows[k][0].ToString()));
                        actors_adapter.Fill(s_ep_ds, "actor");
                        vid.actorsBox.Text = vid.actorsBox.Text + "- " + s_ep_ds.Tables["actor"].Rows[k][1] + " " + s_ep_ds.Tables["actor"].Rows[k][2] + "\n  " + Convert.ToDateTime(s_ep_ds.Tables["actor"].Rows[j][3]).ToShortDateString() + "\n  " + s_ep_ds.Tables["actor"].Rows[j][4] + "\n  ";
                    }
                    flowLayoutPanel1.Controls.Add(vid);
                    vid.addrevbox.Visible = false;
                    vid.AddRev.Visible = false;
                    vid.revBox.Visible = false;
                    vid.label9.Visible = false;
                    vid.close.Visible = false;
                    vid.label6.Visible = false;
                    vid.label7.Visible = false;
                    vid.my_rate.Visible = false;
                    vid.edit.Visible = true;
                }
                s_ep_ds.Tables.Remove("episode");
                s_ep_ds.Tables.Remove("num_genres");
                s_ep_ds.Tables.Remove("genres");
                s_ep_ds.Tables.Remove("num_actors");
                s_ep_ds.Tables.Remove("actor_id");
                s_ep_ds.Tables.Remove("actor");

                seriesFound = true;
            }
        }

        //search Btn
        private void searchBtn_MouseClick(object sender, MouseEventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("VideoEdit");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("VideoEdit");
            flowLayoutPanel1.Controls.Clear();

            try
            {
                if (typeBox.SelectedIndex == 0)
                {
                    search_movie();
                    search_episode();

                    if (movieFound == false && seriesFound == false)
                        MessageBox.Show("No results found");
                }
                else if (typeBox.SelectedIndex == 1)
                {
                    search_movie();
                    if(movieFound == false)
                        MessageBox.Show("No movie/s found");
                }
                else
                {
                    search_episode();
                    if (seriesFound == false)
                        MessageBox.Show("No series found");
                }
                movieFound = false;
                seriesFound = false;
                
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

        //choose to display all, movies,series
        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool contain = splitContainer1.Panel2.Controls.ContainsKey("VideoEdit");
            if (contain)
                splitContainer1.Panel2.Controls.RemoveByKey("VideoEdit");
            flowLayoutPanel1.Controls.Clear();

            if (typeBox.SelectedIndex == 0)
            {
                display_movie();
                display_episode();
            }
            else if (typeBox.SelectedIndex == 1)
                display_movie();
            else
                display_episode();
        }

        private void splitContainer1_Panel2_ControlRemoved(object sender, ControlEventArgs e)
        {
            HomeBtn_MouseClick(sender, new MouseEventArgs(System.Windows.Forms.MouseButtons.Left,1,0,0,0));
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            Report R = new Report();
            R.Show();
            this.Hide();
        }
    }
}
