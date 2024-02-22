using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Drawing.Drawing2D;

namespace SimonSays
{
    public partial class Form1 : Form
    {
        public static List<int> pattern = new List<int>();
        public static int lastSong = 4;
        public static List<int> userScore = new List<int>();


        public static List<SoundPlayer> soundPlayers = new List<SoundPlayer>();

        public Form1()
        {
            InitializeComponent();

            soundPlayers.Add(new SoundPlayer(Properties.Resources.green));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.red));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.yellow));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.blue));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.menuSong1));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.menuSong2));
            soundPlayers.Add(new SoundPlayer(Properties.Resources.gameOverSong));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChangeScreen(this, new MenuScreen());
        }
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f;

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }
            next.Location = new Point((f.Width - next.Width) / 2, (f.Height - next.Height) / 2);
            f.Controls.Add(next);
        }
    }
}
