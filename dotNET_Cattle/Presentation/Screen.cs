using dotNET_Cattle.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotNET_Cattle
{
    public partial class Screen : Form
    {
        List<Cow> cows = new List<Cow>();
        List<Sheep> sheeps =new List<Sheep>();
        List<Goat> goats = new List<Goat>();

        public Screen()
        {
            InitializeComponent();
        }

        private void butFinish_Click(object sender, EventArgs e)
        {
            try
            {
                int nC = int.Parse(cowInput.Text);
                int nS = int.Parse(sheepInput.Text);
                int nG = int.Parse(goatInput.Text);
                for(int i = 0;i < nC; i++)
                {
                    cows.Add(new Cow());
                }
                for(int i = 0; i < nS; i++) { 
                    sheeps.Add(new Sheep());
                }
                for (int i = 0; i<nG ; i++) { 
                    goats.Add(new Goat());
                }
                sumInput.Text = (nC + nG + nS).ToString();
                butBark.Enabled = true;
                butBorn.Enabled = true;
                butMilk.Enabled = true;
                MessageBox.Show("hello "+cows.Count+" "+sheeps.Count+" "+goats.Count);
            }
            catch
            {
                MessageBox.Show("Số lượng nhập không phù hợp!", "Thông báo");
            }
        }

        private void butBorn_Click(object sender, EventArgs e)
        {
            int numCow = cows.Count,numSheep=sheeps.Count,numGoat=goats.Count;
            int numCowBorn = 0,numSheepBorn=0,numGoatBorn=0;
            for(int i = 0; i < numCow; i++)
            {
                int baies = cows[i].born();
                numCowBorn += baies;
                for(int j = 0; j < baies; j++)
                {
                    cows.Add(new Cow());
                }

            }
            for (int i = 0; i < numSheep; i++)
            {
                int baies = sheeps[i].born();
                numSheepBorn += baies;
                for (int j = 0; j < baies; j++)
                {
                    sheeps.Add(new Sheep());
                }

            }
            for (int i = 0; i < numGoat; i++)
            {
                int baies = goats[i].born();
                numGoatBorn += baies;
                for (int j = 0; j < baies; j++)
                {
                    goats.Add(new Goat());
                }

            }
            cowBorn.Text=numCowBorn.ToString();
            sheepBorn.Text=numSheepBorn.ToString();
            goatBorn.Text=numSheepBorn.ToString();
            sumBorn.Text=(int.Parse(cowBorn.Text)+int.Parse(sheepBorn.Text)+int.Parse(goatBorn.Text)).ToString();

            cowSum.Text=cows.Count.ToString();
            sheepSum.Text=sheeps.Count.ToString();
            goatSum.Text=goats.Count.ToString();
            sumCattle.Text = (int.Parse(cowSum.Text) + int.Parse(sheepSum.Text) + int.Parse(goatSum.Text)).ToString();

        }

        private void butMilk_Click(object sender, EventArgs e)
        {
            int cM = 0, sM = 0, gM = 0;
            for(int i = 0;i<cows.Count;i++)
            {
                int Milk = cows[i].giveMilk();
                cM += Milk;
            }
            for (int i = 0; i < sheeps.Count; i++)
            {
                int Milk = sheeps[i].giveMilk();
                sM += Milk;
            }
            for (int i = 0; i < goats.Count; i++)
            {
                int Milk = goats[i].giveMilk();
                gM += Milk;
            }
            cowGiveMilk.Text=cM.ToString();
            sheepGiveMilk.Text=sM.ToString();
            goatGiveMilk.Text=gM.ToString();
            sumGiveMilk.Text = (int.Parse(cowGiveMilk.Text) + int.Parse(sheepGiveMilk.Text) + int.Parse(goatGiveMilk.Text)).ToString();

            cowMilk.Text = cows[0].getMilk().ToString();
            sheepMilk.Text = sheeps[0].getMilk().ToString();
            goatMilk.Text = goats[0].getMilk().ToString();
            sumMilk.Text = (int.Parse(cowMilk.Text) + int.Parse(sheepMilk.Text) + int.Parse(goatMilk.Text)).ToString();
        }

        private void butBark_Click(object sender, EventArgs e)
        {
            lbSound.Text = "";
            for(int i = 0;i<cows.Count;i++)
            {
                lbSound.Text += cows[i].bark()+" ";
            }
            lbSound.Text += "\n";
            for (int i = 0; i < sheeps.Count; i++)
            {
                lbSound.Text += sheeps[i].bark();
            }
            lbSound.Text += "\n";
            for (int i = 0; i < goats.Count; i++)
            {
                lbSound.Text += goats[i].bark();
            }
        }

        private void Screen_Load(object sender, EventArgs e)
        {

        }
    }
}
