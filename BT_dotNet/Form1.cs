using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_dotNet
{
    public partial class Form1 : Form
    {
        Graphics graphic;
        public Form1()
        {
           
            InitializeComponent();
           
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            graphic = this.CreateGraphics();
            graphic.FillEllipse(new SolidBrush(Color.Aquamarine), 100, 100, 50, 50);
            graphic.FillEllipse(new HatchBrush(HatchStyle.ZigZag,Color.Red), 125, 125, 50, 50);
            graphic.FillEllipse(new LinearGradientBrush(new Rectangle(150,150,200,200),Color.Red,Color.Blue,LinearGradientMode.Horizontal), 150, 150, 50, 50);
            graphic.FillEllipse(new SolidBrush(Color.Azure), 175, 175, 50, 50);
        }
    }
}
