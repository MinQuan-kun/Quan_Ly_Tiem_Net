using Do_anLaptrinhWinCK;
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
        public static string infor = "Bạn chưa đăng nhập!";
        private bool isLoginFormOpen = false; // Cờ kiểm soát trạng thái đăng nhập

        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
            UpdateButtonStatus();
        }
        public frmMain(string _infor)
        {
            InitializeComponent();
            customizeDesign();
            infor = _infor;
            UpdateButtonStatus(); // Cập nhật trạng thái nút
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            lblInfor.Text = infor;
            UpdateButtonStatus(); // Đảm bảo trạng thái nút đúng khi form tải lên
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");
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

        private void showSubMenu(System.Windows.Forms.Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void UpdateButtonStatus()
        {
            // Cập nhật trạng thái nút dựa trên trạng thái đăng nhập
            if (infor == "Bạn chưa đăng nhập!")
            {
                btnDangnhap.Enabled = true;
                btnDangnhap.BackColor = Color.LightGreen; // Sáng nút
                btnDangxuat.Enabled = false;
                btnDangxuat.BackColor = Color.Gray; // Tối nút
            }
            else
            {
                btnDangnhap.Enabled = false;
                btnDangnhap.BackColor = Color.Gray; // Tối nút
                btnDangxuat.Enabled = true;
                btnDangxuat.BackColor = Color.LightCoral; // Sáng nút
            }
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
            if (!isLoginFormOpen)
            {
                isLoginFormOpen = true;
                frmLogin frm = new frmLogin();
                frm.Show();
                frm.MdiParent = this;
                frm.StartPosition = FormStartPosition.CenterParent;

                frm.FormClosed += (s, args) =>
                {
                    isLoginFormOpen = false;
                    lblInfor.Text = infor; // Cập nhật thông tin sau khi đăng nhập
                    UpdateButtonStatus(); // Cập nhật trạng thái các nút
                };
               
            }
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            infor = "Bạn chưa đăng nhập!";
            lblInfor.Text = infor;
            UpdateButtonStatus(); // Cập nhật trạng thái nút sau khi đăng xuất
            hideSubMenu();
        }
    }
}
