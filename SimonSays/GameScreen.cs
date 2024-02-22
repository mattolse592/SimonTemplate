using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        public static int guess;

        Random ranGen = new Random();

        List<Button> buttons = new List<Button>();
        List<Color> buttonColors = new List<Color>();

        int timerStep;
        int buttonClicked;
        int computerStep;

        public GameScreen()
        {
            InitializeComponent();
            buttons.Add(greenButton);
            buttons.Add(redButton);
            buttons.Add(yellowButton);
            buttons.Add(blueButton);

            buttonColors.Add(Color.ForestGreen);
            buttonColors.Add(Color.DarkRed);
            buttonColors.Add(Color.Goldenrod);
            buttonColors.Add(Color.DarkBlue);
            buttonColors.Add(Color.LawnGreen);
            buttonColors.Add(Color.Red);
            buttonColors.Add(Color.Yellow);
            buttonColors.Add(Color.Blue);
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            Form1.pattern.Clear();

            Refresh();
            Thread.Sleep(1000);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            Form1.pattern.Add(ranGen.Next(0, 4));

            buttons.ForEach(b => b.Enabled = false);

            computerTimer.Enabled = true;
            guess = 0;
        }
        #region Player Button Clicks
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] != 0)
            {
                GameOver();
            }
            else
            {
                buttonClicked = 0;
                delayTimer.Enabled = true;
                guess++;
            }
        }
        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] != 1)
            {
                GameOver();
            }
            else
            {
                buttonClicked = 1;
                delayTimer.Enabled = true;
                guess++;
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] != 2)
            {
                GameOver();
            }
            else
            {
                buttonClicked = 2;
                delayTimer.Enabled = true;
                guess++;
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.pattern[guess] != 3)
            {
                GameOver();
            }
            else
            {
                buttonClicked = 3;
                delayTimer.Enabled = true;
                guess++;
            }
        }
        #endregion
        public void GameOver()
        {
            SoundPlayer gameOver = new SoundPlayer(Properties.Resources.mistake);
            gameOver.Play();

            buttons.ForEach(b => b.BackColor = Color.Gray);
            Refresh();
            Thread.Sleep(2000);

            Form1.ChangeScreen(this, new GameOverScreen());
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            switch (timerStep)
            {
                case 1:
                    Form1.soundPlayers[buttonClicked].Play();
                    buttons[buttonClicked].BackColor = buttonColors[buttonClicked + 4];

                    buttons.ForEach(b => b.Enabled = false);

                    buttons[buttonClicked].Refresh();
                    break;
                case 35:
                    buttons[buttonClicked].BackColor = buttonColors[buttonClicked];
                    buttons[buttonClicked].Refresh();
                    break;
                case 40:
                    delayTimer.Enabled = false;
                    timerStep = 0;

                    buttons.ForEach(b => b.Enabled = true);

                    if (guess == Form1.pattern.Count())
                    {
                        ComputerTurn();
                    }

                    break;
            }
            timerStep++;
        }

        private void computerTimer_Tick(object sender, EventArgs e)
        {
            buttonClicked = Form1.pattern[computerStep];

            switch (timerStep)
            {
                case 1:
                    Form1.soundPlayers[buttonClicked].Play();

                    buttons[buttonClicked].BackColor = buttonColors[buttonClicked + 4];
                    buttons[buttonClicked].Refresh();
                    break;
                case 45:
                    buttons[buttonClicked].BackColor = buttonColors[buttonClicked];
                    buttons[buttonClicked].Refresh();
                    break;
                case 47:
                    if (computerStep < Form1.pattern.Count() - 1)
                    {
                        computerStep++;
                    }
                    else
                    {
                        computerTimer.Enabled = false;
                        computerStep = 0;

                        buttons.ForEach(b => b.Enabled = true);
                    }
                    
                    timerStep = 0;
                    break;
            }
            timerStep++;

        }
    }
}
