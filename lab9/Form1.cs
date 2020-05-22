using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab9
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Pen p;
        SolidBrush fon;
        SolidBrush fig;
        int rad = 20;
        Random rand;
        List<IPoint> Arr = new List<IPoint>();
        int num = 1;
        int kof = 5;
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }
        void DrawCircle(int x, int y)
        {
            int xc, yc;
            xc = x - rad;
            yc = y - rad;
            gr.FillEllipse(fig, xc, yc, rad, rad);
            gr.DrawEllipse(p, xc, yc, rad, rad);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            p = new Pen(Color.Black);
            fon = new SolidBrush(Color.LightGray);
            fig = new SolidBrush(Color.Black);
            Arr = new List<IPoint>();
            num = 1;
            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);
            int x, y, vx, vy;
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                x = rand.Next(rad, pictureBox1.Width - rad);
                y = rand.Next(rad, pictureBox1.Height - rad);
                vx = rand.Next(1, 5);
                vy = rand.Next(1, 5);
                if (rand.Next(1, 2) == 1)
                {
                    vx = -vx;
                }
                if (rand.Next(1, 2) == 1)
                {
                    vy = -vy;
                }
                if (num == 1)
                {
                    Arr.Add(new IPoint(rad, x, y, vx, vy, pictureBox1.Width, pictureBox1.Height, num));
                    num++;
                    DrawCircle(x, y);
                }
                else
                {
                    if (Arr.Last().Chek(rad, x, y, Arr))
                    {
                        Arr.Add(new IPoint(rad, x, y, vx, vy, pictureBox1.Width, pictureBox1.Height, num));
                        num++;
                        DrawCircle(x, y);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            timer1.Interval = 50;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Task> task = new List<Task>();
            IPoint[] ArrK = new IPoint[Arr.Count];
            Arr.CopyTo(ArrK);
            foreach (var i in Arr)
            {
                task.Add(new Task(() => i.Update(ArrK)));
                task.Last().Start();
            }
            Task.WaitAll(task.ToArray());
            gr.FillRectangle(fon, 0, 0, pictureBox1.Width, pictureBox1.Height);
            foreach (var i in Arr)
            {
                i._svx = i._vx;
                i._svy = i._vy;
                i._sx = i._x;
                i._sy = i._y;
                DrawCircle(i._x, i._y);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            foreach (var i in Arr)
            {
                i.ChSpd(trackBar1.Value - kof);
                kof = trackBar1.Value;
            }
            timer1.Enabled = true;
        }
    }
}