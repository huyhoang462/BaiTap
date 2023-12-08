using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap_trenlop
{
    public partial class Form1 : Form
    {
        MainMenu mMenu;
        MenuItem mStudents;
        MenuItem miStudentsNhap;
        MenuItem miStudentsSearch;
        MenuItem mAbout;
        public Form1()
        {
            /*mMenu=new MainMenu();

            mStudents=new MenuItem();
            mStudents.Text = "Students";

            miStudentsSearch=new MenuItem();
            miStudentsSearch.Text = "Search";

            mAbout=new MenuItem();
            mAbout.Text = "About";

            miStudentsNhap=new MenuItem();
            miStudentsNhap.Text = "Nhap";

            miStudentsNhap.Click += new EventHandler(miStudentsNhap_Click);
            mStudents.MenuItems.Add(miStudentsNhap);
            mMenu.MenuItems.Add(mStudents);
            mStudents.MenuItems.Add(miStudentsSearch);
            mMenu.MenuItems.Add(mAbout);
            this.Menu = mMenu;*/

            miStudentsNhap = new MenuItem("Nhap", new EventHandler(miStudentsNhap_Click), Shortcut.CtrlN);
            miStudentsSearch = new MenuItem("Search",new EventHandler(miStudentsSearch_Click) , Shortcut.CtrlF);
            mStudents =new MenuItem("Students",new MenuItem[] {miStudentsNhap, miStudentsSearch});
            mAbout = new MenuItem("About");
            mMenu =new MainMenu(new MenuItem[] {mStudents,mAbout});
            this.Menu = mMenu;

            InitializeComponent();
        }
        void miStudentsNhap_Click(object sender, EventArgs e)
        {
            MessageBox.Show("new student");
        }
        void miStudentsSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Search student");
        }

    }
}
