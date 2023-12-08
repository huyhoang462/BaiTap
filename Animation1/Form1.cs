using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation1
{
    public partial class Form1 : Form
    {

        // đã click from lần nào chưa
        int click = 0;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        List<Shape> ellipse = new List<Shape>();
        Timer timer = new Timer();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


            Graphics g = this.CreateGraphics();
            Random rd = new Random();
            Color fcl = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255));

            double he = rd.Next(30, 80);
            g.FillEllipse(new SolidBrush(fcl), (float)(e.X - he / 2), (float)(e.Y - he / 2), (float)he, (float)he);
            Shape shape = new Shape((double)e.X, (double)e.Y, he, fcl);


            /*shape.nav = rd.Next(-1,2);*/
            ellipse.Add(shape);

            if (click == 0)
            {

                timer.Interval = 10;
                timer.Tick += timer1_Tick;
                timer.Enabled = true;
                timer.Start();
            }

            click = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*foreach (var elp in ellipse)
            {
                elp.p.Y += 1;
            }*/
            Random rd = new Random();
            for (int i = 0; i < ellipse.Count; i++)
            {
                ballRun(ellipse[i]);
            }
            Refresh();

        }
        private void ballRun(Shape s)
        {
            if (s.p.Y +s.r+ Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed > (double)this.Height)
            {
                s.p.Y = this.Height - s.r;
                s.v.radious = -s.v.radious;
               /* s.p.X += Math.Cos(s.v.radious * Math.PI / 4) * s.v.speed;
                s.p.Y += Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed;*/
            }
            else if (s.p.Y - s.r/2 + Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed < 0)
            {
                s.p.Y = s.r/2;
                s.v.radious = -s.v.radious;
            }
            else if (s.p.X + s.r + Math.Cos(s.v.radious * Math.PI / 4) * s.v.speed > (double)this.Width)
            {
             
                s.p.Y += Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed;
                s.p.X = (double)this.Width - s.r;
                if (s.v.radious == 3 || s.v.radious == -1)
                    s.v.radious -= 2;
               else  if (s.v.radious == -3 || s.v.radious == 1)
                    s.v.radious += 2;
                s.p.X += Math.Cos(s.v.radious * Math.PI / 4) * s.v.speed;
                s.p.Y += Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed;
                

            }
            else if(s.p.X - s.r / 2 + Math.Cos(s.v.radious * Math.PI / 4) * s.v.speed <0)
            {
                s.p.X = s.r / 2;
                if (s.v.radious == -3 || s.v.radious == 1)
                    s.v.radious += 2;
               else if (s.v.radious == 3 || s.v.radious == -1)
                    s.v.radious -= 2;
              
            }    
            else
            {
                s.p.X += Math.Cos(s.v.radious * Math.PI / 4) * s.v.speed;
                s.p.Y += Math.Sin(s.v.radious * Math.PI / 4) * s.v.speed;
                label1.Text = s.v.radious.ToString();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var elp in ellipse)
            {
                e.Graphics.FillEllipse(new SolidBrush(elp.cl), (float)(elp.p.X - elp.r / 2), (float)(elp.p.Y - elp.r / 2), (float)elp.r, (float)elp.r);

            }

        }
    }
}
