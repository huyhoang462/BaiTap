using BattleShip.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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
        Timer box_timer;
        private DateTime lastShootTime = DateTime.MinValue;
        private bool isSpacePressed = false;
        Bitmap explosion = new Bitmap("Image/boom02.png");
        Ship ship = new Ship(0, 0, 0, 0);
        Image shipImage = Image.FromFile("Image/ship01.png");
        Image boxImage = Image.FromFile("Image/box.png");
        bool isStart = false;
        SoundPlayer soundPlayer;
        int score;
        int bulletNow = 1;
        DateTime lastBulletTime;
        private Bitmap backBuffer;
        public Graphics graphics ;
        public Graphics eGraphics;
        private int curFrameColumn;
        private int curFrameRow;
        List<Enemi> enemi_list = new List<Enemi>();
        List<Bullet> bullet_list = new List<Bullet>();
        List<Explosion> explosion_list = new List<Explosion>();
        List<Box> box_list = new List<Box>();
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
            box_timer = new Timer();
            box_timer.Interval = 17000;
            box_timer.Tick += box_timer_Tick;
            box_timer.Enabled = true;
            game_timer.Start();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
           soundPlayer = new SoundPlayer();
            soundPlayer.SoundLocation = "Sound/game_sound.wav";
            soundPlayer.PlayLooping();
            score = 0;
        }

        private void box_timer_Tick(object sender, EventArgs e)
        {
            /*throw new NotImplementedException();*/
            Random rd= new Random();
            Box box = new Box(rd.Next(50,this.Width-50), 0);
            box_list.Add(box);

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
            int c=rd.Next(1,11);
            int x = rd.Next(50, this.Width - 50);
            if (c <=4)
            {
                Enemi01 en1 = new Enemi01(x, 0);
                en1.eImage=Image.FromFile("Image/enemi01.png");
                enemi_list.Add(en1);
            }
            else if (c <=8)
            {
                if (x > this.Width - 75)
                    x = this.Width - 75;
                for (int i = 0; i < 4; i++)
                {
                    Enemi02 en2 = new Enemi02(x+i*10, 0-i*25);
                    en2.eImage = Image.FromFile("Image/enemi02.png");
                    enemi_list.Add(en2);
                }
            }
            else 
            {
                Enemi03 en3=new Enemi03(x, 0);
                en3.eImage= Image.FromFile("Image/enemi03.png");
                enemi_list.Add(en3); 
            }
           
            enemi_timer.Interval = rd.Next(2, 5) * 1000;
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
            score_lb.Text = score.ToString();
            EnemiCome();
            if ((DateTime.Now- lastBulletTime).TotalSeconds>=10)
                bulletNow = 1;
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
            Rectangle  shpRec=new Rectangle(ship.p.X-ship.wi/2+10, ship.p.Y-ship.he/2+10,ship.wi-20,ship.he-20);
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
                    Rectangle bulRec = new Rectangle(bullet_list[j].p.X - bullet_list[j].wi / 2, bullet_list[j].p.Y - bullet_list[j].he / 2-20, bullet_list[j].wi, bullet_list[j].he);
                    if (enRec.IntersectsWith(bulRec))
                    {
                        enemi_list[i].HP -= bullet_list[j].dame;
                        if (bullet_list[j].type != 4)
                        {
                            bullet_list.RemoveAt(j);
                            j--;
                        }
                        Explosion ex= new Explosion(enemi_list[i].p.X, enemi_list[i].p.Y, enemi_list[i].wi);
                        if (enemi_list[i].HP <= 0)
                        {
                            score += enemi_list[i].type * 10;

                            enemi_list.RemoveAt(i);
                            
                            i--;
                          
                        }
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
                    loose();
    
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
            for(int i = 0; i < box_list.Count; i++)
            {
                Rectangle boxrec = new Rectangle(box_list[i].x - 20, box_list[i].y - 20, 35, 35);
                box_list[i].y += 10;
                if (box_list.Count > 0)
                {
                    if (box_list[i].y > this.Height)
                    {
                        box_list.RemoveAt(i);
                        i--;
                    }
                    if (boxrec.IntersectsWith(shpRec))
                    {
                        bulletNow = box_list[i].type;
                        lastBulletTime=DateTime.Now;
                        box_list.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
        private void Form1_Shown(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!game_timer.Enabled)
                return;

            foreach (Enemi en in enemi_list)
            {
                e.Graphics.DrawImage(en.eImage, en.p.X - en.wi / 2, en.p.Y - en.he / 2, en.wi, en.he);
                
            }
            foreach (Bullet bullet in bullet_list)
            {
                e.Graphics.DrawImage(bullet.bImage, bullet.p.X - bullet.wi / 2, bullet.p.Y - bullet.he / 2, bullet.wi, bullet.he);
            }
            
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
            foreach(Box box in box_list)
            {
                e.Graphics.DrawImage(boxImage,box.x-20,box.y-20,40,40);
            }
           
            e.Graphics.DrawImage(shipImage, ship.p.X - ship.wi / 2, ship.p.Y - ship.he / 2, ship.wi, ship.he);
           
        }
        private void Shoot()
        {

            TimeSpan timeSinceLastShoot = DateTime.Now - lastShootTime;
            double shootPeriod = 400;
            if (bulletNow == 3)
                shootPeriod = 600;
            else if (bulletNow == 2)
                shootPeriod = 100;
            // Nếu đã đủ thời gian, thực hiện bắn
            if (timeSinceLastShoot.TotalMilliseconds >= shootPeriod)
            {
                if (bulletNow == 1)
                {
                    Bullet01 bl = new Bullet01(ship.p.X, ship.p.Y - ship.he / 2 + 20);
                    bl.bImage= Image.FromFile("Image/bullet01.png");
                    bullet_list.Add(bl);
                }
                else if(bulletNow == 2)
                {
                    Bullet02 bl = new Bullet02(ship.p.X, ship.p.Y - ship.he / 2 + 20);
                    bl.bImage = Image.FromFile("Image/bullet02.png");
                    bullet_list.Add(bl);
                }
               else if(bulletNow == 3)
                {
                    Bullet03 bl = new Bullet03(ship.p.X, ship.p.Y - ship.he / 2 + 20);
                    bl.bImage = Image.FromFile("Image/bullet03.png");
                    bullet_list.Add(bl);
                }
                else if (bulletNow == 4)
                {
                    Bullet04 bl = new Bullet04(ship.p.X, ship.p.Y - ship.he / 2 + 20);
                    bl.bImage = Image.FromFile("Image/bullet04.png");
                    bullet_list.Add(bl);
                }
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
            if (!game_timer.Enabled)
                return;
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
            if (!game_timer.Enabled)
                return;

            Keyboard.OnKeyUp(sender, e);
            if (e.KeyCode == Keys.Space)
            {
                isSpacePressed = false;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

       

        private void sound_lb_Click(object sender, EventArgs e)
        {
            if (isSoundOn)
            {
                isSoundOn = false;
                sound_lb.Image = Image.FromFile("Image/sound_off.png");
                soundPlayer.Stop() ;
            }
            else
            {
                isSoundOn = true;
                sound_lb.Image = Image.FromFile("Image/sound_on.png");
                soundPlayer.PlayLooping();
            }
           
        }

        private void ask_lb_Click(object sender, EventArgs e)
        {
            introduce_lb.Text = "Use the keys Up, Down, Left, Right to move the ship. Space to shoot." +
                "\nMistery box will update your sells for a while. Yellow: fast charge, Green: go through enemies, Rocket: huge damage." +
                "\nThere are some types of enemi with different apperance, HP and speed."  ;
            introduce_lb.Visible = true;
            close_Intro_lb.Visible = true;
            ask_lb.Visible = false;
            remuse_lb.Visible = false;
            sound_lb.Visible = false;
            pause_text.Visible = false;
        }
        private void close_Intro_lb_Click(object sender, EventArgs e)
        {
            close_Intro_lb.Visible = false;
            introduce_lb.Visible = false;
            ask_lb.Visible = true;
            remuse_lb.Visible = true;
            sound_lb.Visible = true;
            pause_text.Visible = true;

        }

        private void remuse_lb_Click(object sender, EventArgs e)
        {
            ask_lb.Visible = false;
            remuse_lb.Visible = false;
            sound_lb.Visible = false;
            pause_text.Visible = false;
            game_timer.Enabled = true;
            box_timer.Enabled = true;
            enemi_timer.Enabled = true;
            
        }

        private void pause_lb_Click(object sender, EventArgs e)
        {
            ask_lb.Visible = true;
            remuse_lb.Visible = true;
            sound_lb.Visible = true;
            pause_text.Visible = true;
            game_timer.Enabled = false;
            enemi_timer.Enabled = false;
            box_timer.Enabled = false;
            

        }
       
        private void loose()
        {
            your_score_lb.Text = score.ToString();
            start_lb.Visible = true;
            scoreRec_lb.Visible = true;
            your_score_lb.Visible = true;
            oop_lb.Visible=true;
            pause_lb.Enabled = false;
        }

        private void start_lb_Click(object sender, EventArgs e)
        {
            game_timer.Interval = 50;
            game_timer.Start();
            isStart = false;
            score = 0;
            start_lb.Visible = false;
            scoreRec_lb.Visible = false;
            your_score_lb.Visible = false;
            oop_lb.Visible =false;
            enemi_list.Clear();
            bullet_list.Clear();
            explosion_list.Clear();
            box_list.Clear();
            pause_lb.Enabled = true;
        }

       
    }
}
