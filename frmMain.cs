using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_anLaptrinhWinCK
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");
        }
        private void customizeDesign()
        {
            subpanelHethong.Visible = false;
            Subpanel2.Visible = false;
        }

        private void hideSubMenu()
        {
            if (subpanelHethong.Visible == true)
                subpanelHethong.Visible = false;
            if (Subpanel2.Visible == true)
                Subpanel2.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnHethong_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelHethong);

        }
        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(Subpanel2);
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            //

            hideSubMenu();
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            //

            hideSubMenu();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
