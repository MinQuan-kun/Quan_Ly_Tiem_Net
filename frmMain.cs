using Do_anLaptrinhWinCK;
using Do_anLaptrinhWinCK.All_Computer;
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
        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
        }

        public frmMain(string _infor)
        {
            InitializeComponent();
            customizeDesign();
            infor = _infor; // Gán giá trị thông tin từ frmLogin
            lblInfor.Text = infor; // Hiển thị thông tin đăng nhập lên label trong frmMain
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            UpdateLoginState();
            Menu.Visible = false;
            btnMenu.PerformClick();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");
        }
        private void btnminisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnfullsize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(950, 600);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void customizeDesign()
        {
            subpanelHethong.Visible = false;
            subpanelDanhmuc.Visible = false;
            subpanelQuanly.Visible = false;
            Menu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (subpanelHethong.Visible)
                subpanelHethong.Visible = false;
            if (subpanelDanhmuc.Visible)
                subpanelDanhmuc.Visible = false;
            if(subpanelQuanly.Visible)
                subpanelQuanly.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private void UpdateLoginState()
        {
            lblInfor.Text = infor;
            bool isLoggedIn = infor != "Bạn chưa đăng nhập!";
            btnDangxuat.Enabled = isLoggedIn;
            Logout.Enabled = isLoggedIn;
            btnDangNhap.Enabled = !isLoggedIn;
            Login.Enabled = !isLoggedIn;
        }

        //Hiện thị subMenu
        private void btnHethong_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelHethong);
        }
        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelDanhmuc);
        }
        private void btnQuanly_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelQuanly);
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                infor = "Bạn chưa đăng nhập!";
                UpdateLoginState();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (infor != "Bạn chưa đăng nhập!")
            {
                e.Cancel = true; // Hủy hành động đóng form
                this.Hide(); // Ẩn form thay vì đóng
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

 

        private void btnDatmay_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Menu.Visible = true;
            Menu.BringToFront();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            // TODO: Thêm chức năng đăng ký
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            using (frmLogin loginForm = new frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    infor = frmLogin.UserInfo; // Nhận thông tin đăng nhập
                    UpdateLoginState(); // Cập nhật giao diện
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}