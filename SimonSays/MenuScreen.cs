using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonSays
{
    public partial class MenuScreen : UserControl
    {
        bool textGrow = true;
        int textGrowCounter;
        double cursorDistance;

        List<Font> fonts = new List<Font>();

        public MenuScreen()
        {
            InitializeComponent();

            fonts.Add(new Font("Arial", 4));
            fonts.Add(new Font("Arial", 5));
            fonts.Add(new Font("Arial", 6));
            fonts.Add(new Font("Arial", 7));
            fonts.Add(new Font("Arial", 8));
            fonts.Add(new Font("Arial", 9));
            fonts.Add(new Font("Arial", 10));
            fonts.Add(new Font("Arial", 11));
            fonts.Add(new Font("Arial", 12));
            fonts.Add(new Font("Arial", 13));
            fonts.Add(new Font("Arial", 14));
            fonts.Add(new Font("Arial", 15));
            fonts.Add(new Font("Arial", 16));

            if (Form1.lastSong == 4)
            {
                Form1.soundPlayers[5].Play();
                Form1.lastSong = 5;
                //first song
                delayTimer.Interval = 360;
            }
            else
            {
                Form1.soundPlayers[4].Play();
                Form1.lastSong = 4;
                //second song
                delayTimer.Interval = 296;
            }
        }

        //change screen
        private void newButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        //close program
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //make image spin
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Refresh();
        }

        //make text pulse
        private void textTimer_Tick(object sender, EventArgs e)
        {
            if (textGrowCounter >= fonts.Count())
            {
                textGrow = false;
            }
            else if (textGrowCounter <= 0)
            {
                textGrow = true;
            }

            if (textGrow == true)
            {
                titleLabel.Font = fonts[textGrowCounter];
                textGrowCounter++;
            }
            else
            {
                titleLabel.Font = fonts[textGrowCounter - 1];
                textGrowCounter--;
            }

            cursorDistance = Math.Sqrt(((Cursor.Position.X - 870) * (Cursor.Position.X - 870)) + ((Cursor.Position.Y - 455) * (Cursor.Position.Y - 455)));
            try
            {
                textTimer.Interval = Convert.ToInt32(cursorDistance / 5);
            }
            catch
            {
            }
        }
    }
}
