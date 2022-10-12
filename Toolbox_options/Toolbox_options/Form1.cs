using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toolbox_options
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graphics;
        Bitmap bitmap;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello world");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Brush brush  = new SolidBrush(Color.Crimson);

           
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.DrawString("Hello world", new Font("Arial", 20), brush, pictureBox1.Width / 2 - 120, pictureBox1.Height / 2 - 10);
            pictureBox1.Image = bitmap;

        }
    }
}
