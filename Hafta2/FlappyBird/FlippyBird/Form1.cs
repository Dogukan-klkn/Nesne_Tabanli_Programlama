using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlippyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        

        

        private void gameTimer(object sender, EventArgs e)
        {
            pictureBox_Bird.Top += gravity;
            pictureBox_Bottom.Left -= pipeSpeed;
            pictureBox_Top.Left -= pipeSpeed;
            label1.Text = "SCORE:" + score;


            if (pictureBox_Bottom.Left < -150)
            {
                pictureBox_Bottom.Left = 700;
                score++;
            }

            if (pictureBox_Top.Left < -150)
            {
                pictureBox_Top.Left = 800;
                score++;
            }

            if(pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Bottom.Bounds) ||
                    pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Top.Bounds) ||
                    pictureBox_Bird.Bounds.IntersectsWith(pictureBox_Graund.Bounds) ||
                    pictureBox_Bird.Top < -25)
            {
                EndGame();
            }

            void EndGame()
            {
                timer_Game_Control.Stop();
                ShowGameOver(score);
                
            }

        }

        private void game_Down(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }


        }

        private void game_Up(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }

        }

        static void ShowGameOver(int score)


        {
            String message = $"GAME OVER\nScore: {score}";  
            MessageBox.Show(message,"Oyun Bitti", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
