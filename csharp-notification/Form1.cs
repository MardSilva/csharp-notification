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
            this.SetDesktopLocation(Convert.ToInt32(ScreenResolution[0]) - this.Width, Convert.ToInt32(ScreenResolution[1]) - this.Height);

            Sound();

            var GoAwayThread = new Thread(GoAway);
            GoAwayThread.Start();
        }

        public void GoAway()
        {
            Thread.Sleep(10000);
            Application.Exit();
        }

        public void Sound()
        {
            SoundPlayer notif = new SoundPlayer(Properties.Resources.notification);
            notif.Play();

        }
    }
}
