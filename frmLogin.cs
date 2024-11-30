using Do_anLaptrinhWinCK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Do_anLaptrinhWinCK
{
    public partial class frmLogin : Form
    {
        public static string UserInfo { get; private set; } = "Bạn chưa đăng nhập!"; // Thuộc tính lưu thông tin người dùng
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(30);
        }
        private void SetRoundedCorners(int radius)
        {
            radius = Math.Min(radius, Math.Min(this.Width / 2, this.Height / 2));

            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();

            this.Region = new Region(path);
        }
        private Point mouseOffset;
        private bool isMouseDown = false;

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }
        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePosition;
            }
        }
        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string _username = txtUsername.Text;
            string _password = txtPassword.Text;
            if( _username == "" && _password == "")
            {
                MessageBox.Show("Vui lòng điền thông tin!", "Thông báo", MessageBoxButtons.OK);
            }    
            else if (_username == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (_password == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                databaseDataContext db = new databaseDataContext();
                User user = db.Users.SingleOrDefault(p => p.Username == _username);
                if (user != null)
                {
                    // Kiểm tra mật khẩu đang lưu trong database
                    MD5 md5 = MD5.Create();
                    byte[] inputBytes = Encoding.ASCII.GetBytes(_password + user.OTP);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);
                    if(user.Password == hashBytes)
                    {
                        if(user.Role == "Admin")
                        {
                            MessageBox.Show($"Xin chào {user.Username}!", "Thông báo", MessageBoxButtons.OK);
                            frmMain.infor = $"Admin: {user.Username}";
                        }
                        else if (user.Role == "Nhân viên")
                        {
                            MessageBox.Show($"Xin chào {user.Username}!", "Thông báo", MessageBoxButtons.OK);
                            frmMain.infor = $"Nhân viên: {user.Username}";
                        }
                        else if(user.Role == "Người dùng")
                        {
                            MessageBox.Show($"Xin chào {user.Username}!", "Thông báo", MessageBoxButtons.OK);
                            frmMain.infor = $"Người dùng: {user.Username}";
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        lblerror.Visible = true;
                        txtPassword.Focus();
                    }    
                }
                else
                {
                    MessageBox.Show("Thông tin không tồn tại!", "Thông báo", MessageBoxButtons.OK);
                    txtUsername.Focus();
                }    
            }
        }

        private void LinkQuenmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
