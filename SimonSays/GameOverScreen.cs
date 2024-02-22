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
        List<Label> labels = new List<Label>();

        public GameOverScreen()
        {
            InitializeComponent();

            Form1.userScore.Add(Form1.pattern.Count() - 1);

            labels.Add(scoreLabel1);
            labels.Add(scoreLabel2);
            labels.Add(scoreLabel3);
        }

        private void GameOverScreen_Load(object sender, EventArgs e)
        {
            lengthLabel.Text = $"{Form1.pattern.Count() - 1}";
            delayTimer.Enabled = true;

            Form1.userScore.Sort();
            Form1.userScore.Reverse();
            scoreLabel1.Text = $"{Form1.userScore[0]}";
            if (Form1.userScore.Count() > 1)
            {
                scoreLabel2.Text = $"{Form1.userScore[1]}";
            }
            if (Form1.userScore.Count() > 2)
            {
                scoreLabel3.Text = $"{Form1.userScore[2]}";
            }



            //XmlReader reader = XmlReader.Create("Highscores.xml");

            //while (reader.Read())
            //{
            //    if (reader.NodeType == XmlNodeType.Text)
            //    {
            //        labels[highLabel].Text += reader.Value + "   ";
            //        highLabel++;
            //    }

            //}
            //reader.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            Form1.soundPlayers[6].Play();
            delayTimer.Enabled = false;
        }
    }
}
