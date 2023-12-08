using BattleShip.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Form1 : Form
    {
        Timer game_timer;
        Timer enemi_timer;
        Timer explosion_timer;
        private DateTime lastShootTime = DateTime.MinValue;
        private bool isSpacePressed = false;
        Bitmap explosion = new Bitmap("Image/boom02.png");
        Ship ship = new Ship(0, 0, 0, 0);
        Image shipImage = Image.FromFile("Image/ship01.png");
        Image enemiImage = Image.FromFile("Image/enemi02.png");
        Image bulletImage = Image.FromFile("Image/bullet02.png");
        bool isStart = false;

        private Bitmap backBuffer;
        public Graphics graphics ;
        public Graphics eGraphics;
        private int curFrameColumn;
        private int curFrameRow;
        List<Enemi> enemi_list = new List<Enemi>();
        List<Bullet> bullet_list = new List<Bullet>();
        List<Explosion> explosion_list = new List<Explosion>();

        bool isSoundOn = true;
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            eGraphics = this.CreateGraphics();
            DoubleBuffered = true;
            game_timer = new Timer();
            game_timer.Enabled = true;
            game_timer.Interval = 50;
            game_timer.Tick += new EventHandler(game_timer_Tick);
            enemi_timer = new Timer();
            enemi_timer.Enabled = true;
            enemi_timer.Interval = 3000;
            enemi_timer.Tick += new EventHandler(enemi_timer_Tick);
            game_timer.Start();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }
        private void mExplosion(Explosion ex)
        {
            Graphics g = Graphics.FromImage(backBuffer);
            g.Clear(Color.Empty);
            curFrameColumn = ex.indexE % 5;
            curFrameRow = ex.indexE / 5;
            if(!ex.isShip)
            g.DrawImage(explosion,new Rectangle(ex.x-ship.wi/2-25,ex.y-ship.he/2-25,ship.wi+50,ship.he+50), new Rectangle(curFrameColumn * 130, curFrameRow * 130, 130, 130), GraphicsUnit.Pixel);
            else
                g.DrawImage(explosion, new Rectangle(ex.x - 85, ex.y - 85, 200, 200), new Rectangle(curFrameColumn * 130, curFrameRow * 130, 130, 130), GraphicsUnit.Pixel);
            g.Dispose();
            ex.indexE++;

        }
        private void enemi_timer_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            
            Enemi en = new Enemi(rd.Next(50, this.Width - 50), 0, 30,30);
            enemi_list.Add(en);
            enemi_timer.Interval = rd.Next(1, 4) * 1000;
        }

        private void game_timer_Tick(object sender, EventArgs e)
        {
            shipRun();
            if (!isStart)
            {
                ship.setShip(this.Width / 2, this.Height - 100, shipImage.Width / 6, shipImage.Height / 6);
                graphics.DrawImage(shipImage, ship.p.X - ship.wi / 2, ship.p.Y - ship.he / 2, ship.wi, ship.he);
                isStart = true;
            }
            EnemiCome();
            Refresh();
        }
        private void shipRun()
        {
            double velocity = /*(speed: pixels per seconds)*/ 150 * /*(timer tick time in seconds)*/ 0.05;

            if (Keyboard.IsKeyDown(Keys.Up))
            {
                if (ship.p.Y - ship.he / 2 > 0)

                    ship.p.Y -= (int)velocity;
            }
            if (Keyboard.IsKeyDown(Keys.Down))
            {
                if (ship.p.Y + ship.he / 2 + 50 <= this.Height)
                    ship.p.Y += (int)velocity;
            }
            if (Keyboard.IsKeyDown(Keys.Left))
            {
                if (ship.p.X - ship.wi / 2 - 5 > 0)
                    ship.p.X -= (int)velocity;
            }
            if (Keyboard.IsKeyDown(Keys.Right))
            {
                if (ship.p.X + ship.wi / 2 + 20 <= this.Width)
                    ship.p.X += (int)velocity;
            }

        }

        private void EnemiCome()
        {
            Rectangle  shpRec=new Rectangle(ship.p.X-ship.wi/2, ship.p.Y-ship.he/2,ship.wi,ship.he);
            for (int i = 0; i < enemi_list.Count; i++)
            {
                Rectangle enRec = new Rectangle(enemi_list[i].p.X - enemi_list[i].wi / 2, enemi_list[i].p.Y - enemi_list[i].he / 2, enemi_list[i].wi, enemi_list[i].he);
                enemi_list[i].p.Y += enemi_list[i].speed;
                if (enemi_list[i].p.Y > this.Height+20)
                {
                    enemi_list.RemoveAt(i);
                    i--;

                }

                for(int j = 0; j < bullet_list.Count; j++)
                {
                    Rectangle bulRec = new Rectangle(bullet_list[j].p.X - bullet_list[j].wi / 2, bullet_list[j].p.Y - bullet_list[j].he / 2, bullet_list[j].wi, bullet_list[j].he);
                    if (enRec.IntersectsWith(bulRec))
                    {
                        bullet_list.RemoveAt(j);
                        j--;
                        Explosion ex= new Explosion(enemi_list[i].p.X, enemi_list[i].p.Y, enemi_list[i].wi);
                        enemi_list.RemoveAt(i);
                        i--;
                        explosion_list.Add(ex);
                    }
                }
                if (enRec.IntersectsWith(shpRec))
                {
                    enemi_list.RemoveAt(i);
                    i--;
                    Explosion ex=new Explosion(ship.p.X,ship.p.Y,ship.wi);
                    ex.isShip = true;
                    explosion_list.Add(ex);
                    ship.setShip(0, 0, 0, 0);
                    game_timer.Interval = 300;
    
                }
            }

            for(int i=0;i<bullet_list.Count;i++)
            {
                bullet_list[i].p.Y-= bullet_list[i].speed;
                if (bullet_list[i].p.Y<-20)
                {

                    bullet_list.RemoveAt(i);
                    i--;
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Enemi en in enemi_list)
            {
                e.Graphics.DrawImage(enemiImage, en.p.X - en.wi / 2, en.p.Y - en.he / 2, en.wi, en.he);
                /* if(en.p.Y>this.Width)
                     enemi_list.Remove(en);*/
            }
            foreach (Bullet bullet in bullet_list)
            {
                e.Graphics.DrawImage(bulletImage, bullet.p.X - bullet.wi / 2, bullet.p.Y - bullet.he / 2, bullet.wi, bullet.he);
            }
            /*foreach(Explosion ex in explosion_list)
            {
                
                    mExplosion(ex);
                    e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
               
            }*/
            for(int i=0;i<explosion_list.Count;i++)
            {
                if (explosion_list[i].indexE <= 25)
                {
                    mExplosion(explosion_list[i]);
                    e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
                }
                else
                {
                    explosion_list.RemoveAt(i);
                    i--;
                }
            }
            
           
            e.Graphics.DrawImage(shipImage, ship.p.X - ship.wi / 2, ship.p.Y - ship.he / 2, ship.wi, ship.he);
           
        }
        private void Shoot()
        {

            TimeSpan timeSinceLastShoot = DateTime.Now - lastShootTime;

            // Nếu đã đủ thời gian, thực hiện bắn
            if (timeSinceLastShoot.TotalMilliseconds >= 300)
            {
                Bullet bl = new Bullet(ship.p.X, ship.p.Y - ship.he / 2 + 20,20, 50);
                bullet_list.Add(bl);
                // Cập nhật thời điểm lần bắn cuối cùng
                lastShootTime = DateTime.Now;
            }

            // Nếu nút Space vẫn được giữ, lặp lại hàm Shoot
            if (isSpacePressed)
            {
                Shoot();
            }

        }
        public static class Keyboard
        {
            private static readonly HashSet<Keys> keys = new HashSet<Keys>();

            public static void OnKeyDown(object sender, KeyEventArgs e)
            {
                if (keys.Contains(e.KeyCode) == false)
                {
                    keys.Add(e.KeyCode);
                }
            }

            public static void OnKeyUp(object sender, KeyEventArgs e)
            {
                if (keys.Contains(e.KeyCode))
                {
                    keys.Remove(e.KeyCode);
                }
            }

            public static bool IsKeyDown(Keys key)
            {
                return keys.Contains(key);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.OnKeyDown(sender, e);

            if (e.KeyCode == Keys.Space)
            {
                if (isSpacePressed == false)
                {
                    Shoot();
                }

                isSpacePressed = true;
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            Keyboard.OnKeyUp(sender, e);
            if (e.KeyCode == Keys.Space)
            {
                isSpacePressed = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void sound_but_Click(object sender, EventArgs e)
        {
           /* if (isSoundOn)
            {
                               
            } */
        }
    }
}
