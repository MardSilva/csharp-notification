using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Media;

namespace csharp_notification
{
    public partial class Notification : Form
    {
        public Notification()
        {
            InitializeComponent();
        }

        string[] ScreenResolution = { Screen.PrimaryScreen.Bounds.Width.ToString(), Screen.PrimaryScreen.Bounds.Height.ToString() };

        private void Form1_Load(object sender, EventArgs e)
        { 
            // Set location of notification
            this.SetDesktopLocation(Convert.ToInt32(ScreenResolution[0]) - this.Width, Convert.ToInt32(ScreenResolution[1]));

            animatetimer.Start();

            Sound();

            var StopThread = new Thread(Stop);
            StopThread.Start();
        }

        public void Stop()
        {
            Thread.Sleep(4500);

            Application.Exit();
        }

        public void Sound()
        {
            SoundPlayer notif = new SoundPlayer(Properties.Resources.notification);
            notif.Play();

        }

        public int go = 0;

        private void animatetimer_Tick(object sender, EventArgs e)
        {
            if(go < this.Height + 1)
            {
                this.SetDesktopLocation(Convert.ToInt32(ScreenResolution[0]) - this.Width, Convert.ToInt32(ScreenResolution[1]) - go);
            }

            go = go + 5;
        }
    }
}
