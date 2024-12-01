using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Do_anLaptrinhWinCK.All_Customer
{
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent();
        }

        private void Khachhang_Load(object sender, EventArgs e)
        {
            loadDuLieu();
        }

        private void loadDuLieu()
        {
            using (databaseDataContext db = new databaseDataContext())
            {
                dgvUsers.DataSource = db.Users
                    .OrderBy(m => m.UserID)
                    .Select(m => new
                    {
                        m.UserID,
                        m.Password,
                        m.Username,
                        m.Role,
                        m.CardID,
                        m.Active,
                        m.Email,
                        m.OTP,
                        m.Point
                    }).ToList();
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow < 0 || idrow >= dgvUsers.Rows.Count)
                return;
            HienthiDuLieuDong(idrow);
        }
        private void HienthiDuLieuDong(int idrow)
        {
            databaseDataContext db = new databaseDataContext();
            // Lấy UserID từ dòng được chọn (Cells[0])
            int userID = int.Parse(dgvUsers.Rows[idrow].Cells[0].Value.ToString());
            var user = db.Users.SingleOrDefault(p => p.UserID == userID);
            if (user != null)
            {
                txtID.Text = user.UserID.ToString();
                txtUsername.Text = user.Username;
                cbActive.Text = user.Active.ToString();
                cbRole.Text = user.Role;
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            int? ID = string.IsNullOrWhiteSpace(txtID.Text) ? (int?)null : int.Parse(txtID.Text);
            string Role = string.IsNullOrWhiteSpace(cbRole.Text) ? null : cbRole.Text;
            string Active = string.IsNullOrWhiteSpace(cbActive.Text) ? null : cbActive.Text;
            string name = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text;
            if (ID == null)
            {
                MessageBox.Show("Vui lòng nhập UserID để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }
            if(string.IsNullOrEmpty(Role) && string.IsNullOrEmpty(Active))
            {
                MessageBox.Show("Vai trò và trạng thái không được để trống", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            using (databaseDataContext db = new databaseDataContext())
            {
                // Tìm người dùng theo ID
                var existingUser = db.Users.SingleOrDefault(u => u.UserID == ID);

                if (existingUser != null)
                {
                    existingUser.Role = Role;
                    existingUser.Active = Active;
                    db.SubmitChanges();

                    MessageBox.Show("Chỉnh sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDuLieu();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy UserID để chỉnh sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            int? ID = string.IsNullOrWhiteSpace(txtID.Text) ? (int?)null : int.Parse(txtID.Text);
            string name = string.IsNullOrWhiteSpace(txtUsername.Text) ? null : txtUsername.Text;
            string Role = string.IsNullOrWhiteSpace(cbRole.Text) ? null : cbRole.Text;
            string Active = string.IsNullOrWhiteSpace(cbActive.Text) ? null : cbActive.Text;

            databaseDataContext db = new databaseDataContext();
            var query = db.Users.AsQueryable();
            if (ID.HasValue)
            {
                query = query.Where(m => m.UserID == ID.Value);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(m => m.Username.Contains(name));
            }
            if (!string.IsNullOrEmpty(Role))
            {
                query = query.Where(m => m.Role.Contains(Role));
            }
            if (!string.IsNullOrEmpty(Active))
            {
                query = query.Where(m => m.Active.Contains(Active));
            }
            var results = query.ToList();
            if (results.Count > 0)
            {
                dgvUsers.DataSource = results.Select(m => new
                {
                    m.UserID,
                    m.Password,
                    m.Username,
                    m.Role,
                    m.CardID,
                    m.Active,
                    m.Email,
                    m.OTP,
                    m.Point
                }).ToList();
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnInds_Click(object sender, EventArgs e)
        {

        }
    }
}
