namespace BattleShip
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.score_lb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sound_lb = new System.Windows.Forms.Label();
            this.ask_lb = new System.Windows.Forms.Label();
            this.remuse_lb = new System.Windows.Forms.Label();
            this.pause_text = new System.Windows.Forms.Label();
            this.pause_lb = new System.Windows.Forms.Label();
            this.khung = new System.Windows.Forms.Label();
            this.oop_lb = new System.Windows.Forms.Label();
            this.start_lb = new System.Windows.Forms.Label();
            this.scoreRec_lb = new System.Windows.Forms.Label();
            this.introduce_lb = new System.Windows.Forms.Label();
            this.close_Intro_lb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // score_lb
            // 
            this.score_lb.BackColor = System.Drawing.Color.Transparent;
            this.score_lb.Font = new System.Drawing.Font("Matura MT Script Capitals", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_lb.ForeColor = System.Drawing.Color.White;
            this.score_lb.Location = new System.Drawing.Point(105, 26);
            this.score_lb.Margin = new System.Windows.Forms.Padding(0);
            this.score_lb.Name = "score_lb";
            this.score_lb.Size = new System.Drawing.Size(72, 23);
            this.score_lb.TabIndex = 1;
            this.score_lb.Text = "0";
            this.score_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Matura MT Script Capitals", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "score:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sound_lb
            // 
            this.sound_lb.BackColor = System.Drawing.Color.Transparent;
            this.sound_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sound_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sound_lb.Image = ((System.Drawing.Image)(resources.GetObject("sound_lb.Image")));
            this.sound_lb.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.sound_lb.Location = new System.Drawing.Point(371, 420);
            this.sound_lb.Margin = new System.Windows.Forms.Padding(0);
            this.sound_lb.Name = "sound_lb";
            this.sound_lb.Size = new System.Drawing.Size(60, 56);
            this.sound_lb.TabIndex = 4;
            this.sound_lb.Visible = false;
            this.sound_lb.Click += new System.EventHandler(this.sound_lb_Click);
            // 
            // ask_lb
            // 
            this.ask_lb.BackColor = System.Drawing.Color.Transparent;
            this.ask_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ask_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ask_lb.Image = ((System.Drawing.Image)(resources.GetObject("ask_lb.Image")));
            this.ask_lb.Location = new System.Drawing.Point(158, 420);
            this.ask_lb.Name = "ask_lb";
            this.ask_lb.Size = new System.Drawing.Size(57, 56);
            this.ask_lb.TabIndex = 5;
            this.ask_lb.Visible = false;
            this.ask_lb.Click += new System.EventHandler(this.ask_lb_Click);
            // 
            // remuse_lb
            // 
            this.remuse_lb.BackColor = System.Drawing.Color.Transparent;
            this.remuse_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remuse_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remuse_lb.Image = ((System.Drawing.Image)(resources.GetObject("remuse_lb.Image")));
            this.remuse_lb.Location = new System.Drawing.Point(271, 392);
            this.remuse_lb.Name = "remuse_lb";
            this.remuse_lb.Size = new System.Drawing.Size(55, 50);
            this.remuse_lb.TabIndex = 6;
            this.remuse_lb.Visible = false;
            this.remuse_lb.Click += new System.EventHandler(this.remuse_lb_Click);
            // 
            // pause_text
            // 
            this.pause_text.BackColor = System.Drawing.Color.Transparent;
            this.pause_text.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pause_text.Font = new System.Drawing.Font("Elephant", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pause_text.Location = new System.Drawing.Point(207, 303);
            this.pause_text.Name = "pause_text";
            this.pause_text.Size = new System.Drawing.Size(186, 50);
            this.pause_text.TabIndex = 7;
            this.pause_text.Text = "Pause";
            this.pause_text.Visible = false;
            // 
            // pause_lb
            // 
            this.pause_lb.BackColor = System.Drawing.Color.Transparent;
            this.pause_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pause_lb.Image = ((System.Drawing.Image)(resources.GetObject("pause_lb.Image")));
            this.pause_lb.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.pause_lb.Location = new System.Drawing.Point(513, 9);
            this.pause_lb.Margin = new System.Windows.Forms.Padding(0);
            this.pause_lb.Name = "pause_lb";
            this.pause_lb.Size = new System.Drawing.Size(60, 57);
            this.pause_lb.TabIndex = 8;
            this.pause_lb.Click += new System.EventHandler(this.pause_lb_Click);
            // 
            // khung
            // 
            this.khung.BackColor = System.Drawing.Color.Transparent;
            this.khung.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.khung.Cursor = System.Windows.Forms.Cursors.Default;
            this.khung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.khung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.khung.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.khung.Location = new System.Drawing.Point(0, 0);
            this.khung.Margin = new System.Windows.Forms.Padding(0);
            this.khung.Name = "khung";
            this.khung.Size = new System.Drawing.Size(582, 786);
            this.khung.TabIndex = 9;
            this.khung.Visible = false;
            // 
            // oop_lb
            // 
            this.oop_lb.BackColor = System.Drawing.Color.Transparent;
            this.oop_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oop_lb.Font = new System.Drawing.Font("Elephant", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oop_lb.Location = new System.Drawing.Point(73, 213);
            this.oop_lb.Name = "oop_lb";
            this.oop_lb.Size = new System.Drawing.Size(462, 71);
            this.oop_lb.TabIndex = 10;
            this.oop_lb.Text = "OOP!!   AGAIN?";
            this.oop_lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.oop_lb.Visible = false;
            // 
            // start_lb
            // 
            this.start_lb.BackColor = System.Drawing.Color.Transparent;
            this.start_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start_lb.Image = ((System.Drawing.Image)(resources.GetObject("start_lb.Image")));
            this.start_lb.Location = new System.Drawing.Point(271, 303);
            this.start_lb.Name = "start_lb";
            this.start_lb.Size = new System.Drawing.Size(55, 50);
            this.start_lb.TabIndex = 11;
            this.start_lb.Visible = false;
            this.start_lb.Click += new System.EventHandler(this.start_lb_Click);
            // 
            // scoreRec_lb
            // 
            this.scoreRec_lb.BackColor = System.Drawing.Color.Transparent;
            this.scoreRec_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scoreRec_lb.Font = new System.Drawing.Font("Elephant", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreRec_lb.Location = new System.Drawing.Point(175, 372);
            this.scoreRec_lb.Name = "scoreRec_lb";
            this.scoreRec_lb.Size = new System.Drawing.Size(256, 46);
            this.scoreRec_lb.TabIndex = 12;
            this.scoreRec_lb.Text = "Your score: ";
            this.scoreRec_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scoreRec_lb.Visible = false;
            // 
            // introduce_lb
            // 
            this.introduce_lb.BackColor = System.Drawing.Color.Transparent;
            this.introduce_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.introduce_lb.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introduce_lb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.introduce_lb.Location = new System.Drawing.Point(96, 135);
            this.introduce_lb.Name = "introduce_lb";
            this.introduce_lb.Size = new System.Drawing.Size(439, 365);
            this.introduce_lb.TabIndex = 14;
            this.introduce_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.introduce_lb.Visible = false;
            // 
            // close_Intro_lb
            // 
            this.close_Intro_lb.BackColor = System.Drawing.Color.Transparent;
            this.close_Intro_lb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.close_Intro_lb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_Intro_lb.Font = new System.Drawing.Font("Elephant", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_Intro_lb.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.close_Intro_lb.Location = new System.Drawing.Point(208, 536);
            this.close_Intro_lb.Name = "close_Intro_lb";
            this.close_Intro_lb.Size = new System.Drawing.Size(165, 56);
            this.close_Intro_lb.TabIndex = 15;
            this.close_Intro_lb.Text = "close";
            this.close_Intro_lb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_Intro_lb.Visible = false;
            this.close_Intro_lb.Click += new System.EventHandler(this.close_Intro_lb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(582, 786);
            this.Controls.Add(this.close_Intro_lb);
            this.Controls.Add(this.introduce_lb);
            this.Controls.Add(this.scoreRec_lb);
            this.Controls.Add(this.start_lb);
            this.Controls.Add(this.oop_lb);
            this.Controls.Add(this.pause_text);
            this.Controls.Add(this.pause_lb);
            this.Controls.Add(this.remuse_lb);
            this.Controls.Add(this.ask_lb);
            this.Controls.Add(this.sound_lb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.score_lb);
            this.Controls.Add(this.khung);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label score_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sound_lb;
        private System.Windows.Forms.Label ask_lb;
        private System.Windows.Forms.Label remuse_lb;
        private System.Windows.Forms.Label pause_text;
        private System.Windows.Forms.Label pause_lb;
        private System.Windows.Forms.Label khung;
        private System.Windows.Forms.Label oop_lb;
        private System.Windows.Forms.Label start_lb;
        private System.Windows.Forms.Label scoreRec_lb;
        private System.Windows.Forms.Label introduce_lb;
        private System.Windows.Forms.Label close_Intro_lb;
    }
}

