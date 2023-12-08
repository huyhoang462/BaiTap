using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
   
    public partial class Form1 : Form
    {
        //Bitmap dùng cho ảnh sprite
        private Image image;
        // Back buffer
        
        private Timer timer;
        public Graphics graphics;
        // Số thự tự của frame (16 frame ảnh)
        private int index;
        // dòng hiện tại của frame
        private int curFrameColumn;
        // cột hiện tại của frame
        private int curFrameRow;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            graphics = this.CreateGraphics();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        
            
            // Lấy ảnh sprite
            image=Image.FromFile("expl.png");
            index = 0;
            // Khởi tạo một đồng hồ
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }
        private void Render()
        {
            // Lấy đối tượng graphics để vẽ lên back buffer
            Graphics g = CreateGraphics();
            g.Clear(Color.Empty);
            // Xác dịnh số dòng, cột của một frame trên ảnh sprite
            curFrameColumn = index % 3;
            curFrameRow = index / 3;
            // Vẽ lên buffer
            g.DrawImage(image,new Rectangle( 120,120,50,50), new Rectangle(curFrameColumn * 185, curFrameRow * 185, 185, 185),GraphicsUnit.Pixel);
            g.Dispose();
            // Tăng thứ tự frame để lấy frame tiếp theo
            
            if (index > 25)
                index = 0;
            else
                index++;
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Render();

            // Vẽ lên màn hình
           
        }
    }
}
