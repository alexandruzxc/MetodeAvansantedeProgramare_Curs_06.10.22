using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12.X_and_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int n = 3;
        Button[,] buttons;
        bool isPlayerX = true;

        int player = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (buttons == null)
            {
                buttons = new Button[n, n];
                int size = pictureBox1.Width / 3;

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Button button = new Button();
                        button.Parent = pictureBox1;
                        button.Size = new Size(size, size);

                        button.Location = new Point(j * size, i * size);
                        button.Font = new Font("Arial", 30);
                        button.Click += gridButton_Click;

                        buttons[i, j] = button;

                    }
                }
            }
            else
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i, j].Enabled = true;
                        buttons[i, j].Text = "";
                    }
                }
            isPlayerX = true;
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if ( isPlayerX)
            {
                button.Text = "X";
                button.Enabled = false;
            }
            else
            {
                button.Text = "0";
                button.Enabled = false;
            }
            if (CheckGameWon())
            {
                int player;
                if (isPlayerX)
                    player = 1;
                else
                    player = 2;
                MessageBox.Show($"Player {player} has Won", "Game Over");
            }
            else if (CheckGameLost())
            {
                MessageBox.Show("Draw", "Game Over");
            }
            isPlayerX = !isPlayerX;

        }
        bool CheckGameLost()
        {
            for (int i = 0; i < n; i++)
            
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Enabled)
                        return false;
                }
                return true;           
        }

        bool CheckGameWon()
        {
            int sumaX = 0, sumaY = 0;
            for (int i = 0; i < n; i++)
            {
                // asta este pentru linii
                sumaX = 0; sumaY = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Text == "X")
                        sumaX++;
                    else if (buttons[i, j].Text == "0")
                        sumaY++;                           
                }
                if (sumaX == 3 || sumaY == 3)
                    return true;

                //asta este pentru coloane
                sumaX = 0; sumaY = 0;
                for (int j = 0; j < n; j++)
                {
                    if (buttons[j, i].Text == "X")
                        sumaX++;
                    else if (buttons[j, i].Text == "0")
                        sumaY++;
                }
                if (sumaX == 3 || sumaY == 3)
                    return true;
            }

            //diagonala principala
            sumaX = 0; sumaY = 0;
            for (int i = 0; i < n; i++)

            {
                if (buttons[i, i].Text == "X")
                    sumaX++;
                else if (buttons[i, i].Text == "0")
                    sumaY++;
            }
            if (sumaX == 3 || sumaY == 3)
                return true;

            //diagonala secundara
            sumaX = 0; sumaY = 0;
            for (int i = 0; i < n; i++)

            {
                if (buttons[i, n - 1 - i].Text == "X")
                    sumaX++;
                else if (buttons[i, n -1 - i].Text == "0")
                    sumaY++;
            }
            if (sumaX == 3 || sumaY == 3)
                return true;

            return false;           
        }

    }

}

