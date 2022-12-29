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
        private Bitmap bitmap;
        private Random random = new Random();
        private int x = 0;
        private int y = 0;
        Rectangle rect = Screen.PrimaryScreen.Bounds;
        private void ScreenSaver_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Black;
            this.ShowInTaskbar = false;
            //获取屏幕的宽度，高度           
            screenWidth = rect.Width;
            screenHeight = rect.Height;
            string currPath = "C:\\Users\\User\\Pictures\\Acer\\Hello_world.bmp";
            bitmap = new Bitmap(currPath, true);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            x = random.Next(screenWidth);
            y = random.Next(screenHeight);
            if (x + bitmap.Width > screenWidth)
            {
                x = screenWidth - bitmap.Width;
            }
            if (y + bitmap.Height > screenHeight)
            {
                y = screenHeight - bitmap.Height;
            }
            this.Invalidate();
        }
        private void ScreenSaver_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, x, y, bitmap.Width, bitmap.Height);
        }

        private void ScreenSaver_MouseMove(object sender, MouseEventArgs e)
        {
            this.TopMost = false;
        }
    }
}
