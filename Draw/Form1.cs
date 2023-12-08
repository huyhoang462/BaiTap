using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int chs = 0;
        PointF p=new PointF();
        List<Shape> shapes = new List<Shape>();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p.X=e.X;
            p.Y = e.Y;
            if (chs == 1)
            {
               

                Graphics g = this.CreateGraphics();
                Random rd = new Random();
                Color cl = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255));
                Pen pen = new Pen(cl);
                float x1 = p.X+rd.Next(-100,100),y1=p.Y+rd.Next(-100,100);
                float x2 = p.X + rd.Next(-100, 100), y2 = p.Y + rd.Next(-100, 100);
                while (x1 == x2 && y1 == y2)
                {
                    x2 = p.X + rd.Next(-100, 100);
                    y2 = p.Y + rd.Next(-100, 100);
                }
                float x3 = p.X * 3 - x1 - x2, y3 = p.Y * 3 - y1 - y2;
                PointF a=new PointF(x1,y1); 
                PointF b=new PointF(x2,y2); 
                PointF c=new PointF(x3,y3);
                PointF[] ar=new PointF[] {a,b,c};
                g.DrawPolygon(pen,ar);
                g.FillPolygon(new SolidBrush(cl), ar);
            }
            else if (chs == 2)
            {
                
                Graphics g = this.CreateGraphics();
                Random rd = new Random();
                Color cl = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255));
                Pen pen = new Pen(cl,rd.Next(10));
                float wi=rd.Next(200),he=rd.Next(200);
                g.DrawRectangle(pen, p.X-wi/2, p.Y-he/2, wi, he);
                g.FillRectangle(new SolidBrush(cl), p.X - wi / 2, p.Y - he / 2, wi, he);
              

            }
            else if( chs == 3)
            {
                Graphics g = this.CreateGraphics();
                Random rd = new Random();
                Color fcl = Color.FromArgb(rd.Next(255), rd.Next(255), rd.Next(255));               
                Pen pen = new Pen(fcl,rd.Next(10));
                float wi = rd.Next(200), he = rd.Next(200);
                g.DrawEllipse(pen, p.X - wi / 2, p.Y - he / 2, wi, he);
                g.FillEllipse( new SolidBrush(fcl), p.X - wi / 2, p.Y - he / 2, wi, he);
            } 
        }
        
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chs = 1;
        }
        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chs = 2;
            
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chs = 3;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
           
        }
    }
}
