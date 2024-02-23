using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SimonSays
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();

            Form1.userScore.Add(Form1.pattern.Count() - 1);
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            lengthLabel.Text = $"{Form1.pattern.Count() - 1}";
            delayTimer.Enabled = true;

            Form1.userScore.Sort();
            Form1.userScore.Reverse();
            scoreLabel2.Text = $"{Form1.userScore[0]}";
            if (Form1.userScore.Count() > 1)
            {
                scoreLabel1.Text = $"{Form1.userScore[1]}";
            }
            if (Form1.userScore.Count() > 2)
            {
                scoreLabel3.Text = $"{Form1.userScore[2]}";
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }
        //play song
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            Form1.soundPlayers[6].Play();
            delayTimer.Enabled = false;
        }
    }
}
