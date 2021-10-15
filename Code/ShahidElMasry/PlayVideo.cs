using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ShahidElMasry
{
    public partial class PlayVideo : UserControl
    {
        public PlayVideo()
        {
            InitializeComponent();
        }

        private void PlayVideo_Load(object sender, EventArgs e)
        {
            byte[] vid_data = VideoUC.vid_data;

            string name = vid_data.ToString();
            var path = System.IO.Path.Combine(Application.StartupPath, name);
            System.IO.File.WriteAllBytes(path, vid_data);
            axWindowsMediaPlayer1.URL = path;
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            axWindowsMediaPlayer1.close();
            this.Parent.Controls.Remove(this);
        }
    }
}
