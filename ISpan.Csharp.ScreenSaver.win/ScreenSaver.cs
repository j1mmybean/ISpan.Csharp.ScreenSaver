using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISpan.Csharp.ScreenSaver.win
{
    public partial class ScreenSaver : Form
    {
        public ScreenSaver()
        {
            InitializeComponent();
        }
        private int screenWidth;
        private int screenHeight;
        private Random random = new Random();
        private int x_Speed = 5;
        private int y_Speed = 5;
        Rectangle rect = Screen.PrimaryScreen.Bounds;
        private void ScreenSaver_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.ShowInTaskbar = false;
            screenWidth = rect.Width;
            screenHeight = rect.Height;
            pictureBox.Left = random.Next(screenWidth - pictureBox.Width);
            pictureBox.Top = random.Next(screenHeight - pictureBox.Height);
            if (pictureBox.Left < 0)
            {
                pictureBox.Left = 0;
            }
            if (pictureBox.Top < 0)
            {
                pictureBox.Top = 0;
            }
        }
        int x = 0, y = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            Point position = Cursor.Position;
            if (Math.Abs(position.X - x) + Math.Abs(position.Y - y) > 1000)
                this.Close();
            position.X = x;
            position.Y = y;
            pictureBox.Left += x_Speed;
            pictureBox.Top += y_Speed;
            if (pictureBox.Left > screenWidth - pictureBox.Width || pictureBox.Left < 0)
            {
                x_Speed = -x_Speed;
            }
            if (pictureBox.Top > screenHeight - pictureBox.Height || pictureBox.Top < 0)
            {
                y_Speed = -y_Speed;
            }
        }
        //private async void ScreenSaver_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.TopMost = false;
        //    this.Close();
        //}
    }
}
