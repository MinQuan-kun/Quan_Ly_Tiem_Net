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
            lblInfor.Text = infor;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");
            if (infor != "Bạn chưa đăng nhập!")
            {
               
                
            }
            else
            {
                
            }    
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
        private void btnHethong_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelHethong);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(Subpanel2);
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                // Đặt lại thông tin đăng nhập
                infor = "Bạn chưa đăng nhập!";
                lblInfor.Text = infor;

                // Ẩn frmMain và hiển thị lại frmLogin
                frmLogin frm = new frmLogin();
                frm.Show(); // Hiển thị lại frmLogin
                this.Hide(); // Ẩn frmMain

                // Đảm bảo frmMain sẽ đóng khi người dùng thoát frmLogin
                frm.FormClosed += (s, args) => this.Close(); // Đóng frmMain khi frmLogin đóng lại
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra nếu form chưa đăng xuất, thì ẩn form thay vì đóng
            if (infor != "Bạn chưa đăng nhập!")
            {
                e.Cancel = true; // Hủy hành động đóng form
                this.Hide(); // Ẩn form thay vì đóng
            }
            else
            {
                // Nếu chưa đăng nhập, cho phép đóng form (thực hiện hành động mặc định)
                e.Cancel = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isFirstClick = true;  // Biến kiểm tra lần nhấn đầu tiên

        private void btnminisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnfullsize_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                // Phóng to form lên màn hình đầy đủ
                this.WindowState = FormWindowState.Maximized;
                isFirstClick = false;  // Cập nhật trạng thái sau khi phóng to
            }
            else
            {
                this.WindowState = FormWindowState.Normal;  // Đưa form về trạng thái bình thường
                this.Size = new Size(950, 600);  // Thiết lập kích thước mới là 950x600
                isFirstClick = true;  // Cập nhật trạng thái trở lại lần nhấn đầu tiên            }
            }
        }
    }
}
