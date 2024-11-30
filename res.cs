using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_anLaptrinhWinCK
{
    public partial class frmDangky : Form
    {
        public frmDangky()
        {
            InitializeComponent();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = string.Empty;
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            txtEmail.Text = string.Empty;
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "" || txtUser.Text == "" || txtPass.Text == "" || txtConfimpass.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo");
                return;
            }    
            if(txtPass.Text != txtConfimpass.Text)
            {
                MessageBox.Show("Vui lòng điền chính xác mật khẩu", "Thông báo");
                txtPass.Focus();
                return;
            }    
            // Tạo mã otp
            string taikhoan = txtUser.Text;
            string matkhau = txtPass.Text;
            string email = txtEmail.Text;
            Random rd = new Random();
            string otp = rd.Next(1000, 9999).ToString();
            bool Checkotp = false;

            //Mã hóa mật khẩu 
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(matkhau + otp);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            // Tạo và thêm dữ liệu đăng ký vào database
            databaseDataContext db = new databaseDataContext();
            User user = new User();
            user.Username = taikhoan;
            user.Password = hashBytes;
            user.Email = txtEmail.Text;
            user.OTP = otp;
            user.OTPDatesend = DateTime.Now;
            user.OTPDatecreate = DateTime.Now;
            user.Role = "Người dùng";
            user.Active = "Đang hoạt động";
            user.DataActive = null;
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
            MessageBox.Show("Tạo tài khoản thành công", "Thông báo");
            this.Close();
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void btnminisize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
