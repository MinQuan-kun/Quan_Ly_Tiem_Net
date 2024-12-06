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
            infor = _infor;
            lblInfor.Text = infor;
        }
        private void Default()
        {
            btnDanhmuc.Enabled = false;
            btnChucnang.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            UpdateLoginState();
            Default();
            Menu.Visible = false;
            Account.Visible = false;
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
            subpanelChucnang.Visible = false;
            Menu.Visible = false;
        }

        private void hideSubMenu()
        {
            if (subpanelHethong.Visible)
                subpanelHethong.Visible = false;
            if (subpanelDanhmuc.Visible)
                subpanelDanhmuc.Visible = false;
            if(subpanelChucnang.Visible)
                subpanelChucnang.Visible = false;
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
            btnDangky.Enabled = !isLoggedIn;
            register.Enabled = !isLoggedIn;

            if (isLoggedIn)
            {
                // Lấy username từ chuỗi infor
                string username = infor.Split(':').Last().Trim();
                using (databaseDataContext db = new databaseDataContext())
                {
                    // Tìm người dùng trong cơ sở dữ liệu
                    User user = db.Users.SingleOrDefault(p => p.Username == username);
                    if (user != null)
                    {
                        if (user.Role == "Admin")
                        {
                            btnChucnang.Enabled = true;
                            btnDanhmuc.Enabled = true;
                        }
                        else if (user.Role == "Nhân viên")
                        {
                            btnChucnang.Enabled = true;
                            btnDanhmuc.Enabled = true;
                            btnTaikhoan.Enabled = false;
                            
                        }
                        else
                        {
                            // Khách hàng
                            btnChucnang.Enabled = true;
                            btnTaikhoan.Visible = false;
                            btnDanhmuc.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btnChucnang.Enabled = false;
                btnDanhmuc.Enabled = false;
            }
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
        private void btnChucnang_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelChucnang);
        }

        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                infor = "Bạn chưa đăng nhập!";
                UpdateLoginState(); 
                this.Hide();
                frmMain mainnew = new frmMain();
                mainnew.ShowDialog();
                this.Close();
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
            this.Hide();
            frmDangky frmDangky = new frmDangky();
            frmDangky.ShowDialog();
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
                loginForm.Owner = this;
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateLoginState();
                }
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnTaikhoan_Click(object sender, EventArgs e)
        {
            Account.Visible = true;
            Account.BringToFront();
        }

        private void btnDatmay_Click_1(object sender, EventArgs e)
        {

        }
    }
}