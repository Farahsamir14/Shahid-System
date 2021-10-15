using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace ShahidElMasry
{
    public partial class Report : Form
    {
        Movie CR1;
        Series CR2;
        subscribtion CR3;
  
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            CR1.SetParameterValue(0, mov_genre.SelectedItem);
            CR1.SetParameterValue(1, mov_type.SelectedItem);

            crystalReportViewer1.ReportSource = CR1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                subsBtn.Visible = false;
                movieBtn.Visible = true;
                seriesBtn.Visible = false;
             
                mov_genre.Visible = true;
                mov_type.Visible = true;
                mov_genre.Items.Clear();
                mov_type.Items.Clear();
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;

                CR1 = new Movie();

                foreach (ParameterDiscreteValue v in CR1.Parameter_movie_genre_parameter.DefaultValues)
                    mov_genre.Items.Add(v.Value);

                foreach (ParameterDiscreteValue v1 in CR1.Parameter_movie_type_parameter.DefaultValues)
                    mov_type.Items.Add(v1.Value);

            }
            
        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseClick_1(object sender, MouseEventArgs e)
        {
            CR2.SetParameterValue(0, mov_type.SelectedItem);
            CR2.SetParameterValue(1, mov_genre.SelectedItem);

            crystalReportViewer1.ReportSource = CR2;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                subsBtn.Visible = false;
                movieBtn.Visible = false;
                seriesBtn.Visible = true;
            
                mov_genre.Visible = true;
                mov_type.Visible = true;
                mov_genre.Items.Clear();
                mov_type.Items.Clear();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = true;
                label4.Visible = true;

                CR2 = new Series();

                foreach (ParameterDiscreteValue v in CR2.Parameter_seriesName_parameter.DefaultValues)
                    mov_type.Items.Add(v.Value);

                foreach (ParameterDiscreteValue v in CR2.Parameter_seasonNum_Parameter.DefaultValues)
                    mov_genre.Items.Add(v.Value);
                
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                subsBtn.Visible = true;
                movieBtn.Visible = false;
                seriesBtn.Visible = false;
                mov_genre.Visible = false;
                mov_type.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;

                CR3 = new subscribtion();
            }
        }

        private void subsBtn_MouseClick(object sender, MouseEventArgs e)
        {
            crystalReportViewer1.ReportSource = CR3;
        }

    }
}
