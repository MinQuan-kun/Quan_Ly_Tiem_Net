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
using System.Windows.Forms;

namespace Do_anLaptrinhWinCK.All_Computer
{
    public partial class ThucDon : UserControl
    {
        // Cờ đánh dấu cho các chức năng thêm, xóa, tìm, sửa, inds
        public bool them = false;
        public bool xoa = false;
        public bool tim = false;
        public bool sua = false;
        public bool inds = false;
        public ThucDon()
        {
            InitializeComponent();
        }

        private void ThucDon_Load(object sender, EventArgs e)
        {
            loadDuLieu();
            HienthiDuLieuDong(0);
            Default();
        }
        //Hàm load dữ liệu
        private void loadDuLieu()
        {
            databaseDataContext db = new databaseDataContext();
            dvgMenu.DataSource = db.Menus
                .OrderBy(m => m.CategoryID)
                .Select(m => new
                {
                    m.FoodID,
                    m.CategoryID,
                    m.FoodName,
                    m.Price,
                    m.Quantity
                }).ToList();
            loadAllPictuer();
        }

        private void dvgMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idrow = e.RowIndex;
            if (idrow < 0 || idrow >= dvgMenu.Rows.Count)
                return;
            HienthiDuLieuDong(idrow);
        }
        //Hàm hiện thị dữ liệu mỗi dòng
        private void HienthiDuLieuDong(int idrow)
        {
            databaseDataContext db = new databaseDataContext();
            int mamon = int.Parse(dvgMenu.Rows[idrow].Cells[0].Value.ToString());
            Menu m = db.Menus.Where(p => p.FoodID == mamon).FirstOrDefault();
            if(m != null)
            {
                txtMaloai.Text = m.CategoryID.ToString();
                txtDongia.Text = m.Price.ToString();
                txtTenmon.Text = m.FoodName;
                txtSoluong.Text = m.Quantity.ToString();
                txtMamon.Text = m.FoodID.ToString();
                if (m.Image != null)
                {
                    byte[] imageData = m.Image.ToArray();
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbFoodImage.Image = Image.FromStream(ms); 
                    }
                }
                else
                {
                    pbFoodImage.Image = null;
                }
            }    
        }
        // Hàm mặc định
        private void Default()
        {
            // vô hiệu các nút
            txtDongia.Enabled = false;
            txtMaloai.Enabled = false;
            txtMamon.Enabled = false;
            txtSoluong.Enabled = false;
            txtTenmon.Enabled = false;
            pbFoodImage.Enabled = false;
            // reset các dữ liệu đang có trên textbox
            txtMamon.Text = null;
            txtSoluong.Text = null;
            txtDongia.Text = null;
            txtTenmon.Text = null;
            txtMaloai.Text = null;
            pbFoodImage.Image = null;
        }
        // Hàm hiện thị dữ liệu theo Category
        private void loadDuLieuTheoCategory(int categoryID)
        {
            databaseDataContext db = new databaseDataContext();
            var data = db.Menus
                         .Where(menu => menu.CategoryID == categoryID)
                         .Select(menu => new
                         {
                             menu.FoodID,
                             menu.CategoryID,
                             menu.FoodName,
                             menu.Price,
                             menu.Quantity
                         }).ToList();
            dvgMenu.DataSource = data;
            Default();
        }
        //Hàm hiện thị ảnh theo kết quả
        private void loadPictureBoxesTheoRes(List<Menu> menus)
        {
            if (menus == null || menus.Count == 0)
                return;
            if (panelMenu.Controls.Count == 0 || !(panelMenu.Controls[0] is FlowLayoutPanel))
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(5)
                };
                panelMenu.Controls.Add(flowPanel);
            }
            FlowLayoutPanel currentFlowPanel = (FlowLayoutPanel)panelMenu.Controls[0];
            currentFlowPanel.Controls.Clear();
            foreach (var menu in menus)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };
                if (menu.Image != null)
                {
                    using (var ms = new MemoryStream(menu.Image.ToArray()))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.Gray;
                }
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(pictureBox, menu.FoodName);
                currentFlowPanel.Controls.Add(pictureBox);
            }
        }
        // Hàm hiện thị ảnh theo catagory
        private void loadPictureBoxesTheoCategory(int categoryID)
        {
            databaseDataContext db = new databaseDataContext();
            var data = db.Menus
                         .Where(menu => menu.CategoryID == categoryID)
                         .Select(menu => new
                         {
                             menu.CategoryID,
                             menu.FoodName,
                             menu.Image,
                         }).ToList();
            if (panelMenu.Controls.Count == 0 || !(panelMenu.Controls[0] is FlowLayoutPanel))
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(5)
                };
                panelMenu.Controls.Add(flowPanel);
            }
            FlowLayoutPanel currentFlowPanel = (FlowLayoutPanel)panelMenu.Controls[0];
            currentFlowPanel.Controls.Clear();
            foreach (var item in data)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };
                if (item.Image != null)
                {
                    using (var ms = new MemoryStream(item.Image.ToArray()))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.Gray;
                }
                currentFlowPanel.Controls.Add(pictureBox);
            }
            Default();
        }
        // Hàm hiện thị toàn bộ ảnh
        private void loadAllPictuer()
        {
            databaseDataContext db = new databaseDataContext();
            var data = db.Menus
                .OrderBy(menu => menu.CategoryID)
                .Select(menu => new
                {
                    menu.CategoryID,
                    menu.FoodName,
                    menu.Image
                }).ToList();
            if (panelMenu.Controls.Count == 0 || !(panelMenu.Controls[0] is FlowLayoutPanel))
            {
                FlowLayoutPanel flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    Padding = new Padding(10)
                };
                panelMenu.Controls.Add(flowPanel);
            }
            FlowLayoutPanel currentFlowPanel = (FlowLayoutPanel)panelMenu.Controls[0];
            currentFlowPanel.Controls.Clear();
            foreach (var item in data)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.FixedSingle
                };
                if (item.Image != null)
                {
                    using (var ms = new MemoryStream(item.Image.ToArray()))
                    {
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBox.BackColor = Color.Gray;
                }
                currentFlowPanel.Controls.Add(pictureBox);
            }
            Default();
        }
        // Sử lý sự kiện nhấn nút cơm
        private void btnCom_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(1); // Cơm
            loadPictureBoxesTheoCategory(1);
        }
        // Sử lý sự kiện nhấn nút nước
        private void btnNuoc_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(2); // Nước uống
            loadPictureBoxesTheoCategory(2);
        }
        // Sử lý sự kiện nhấn nút snack
        private void btnSnack_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(3); // Snack
            loadPictureBoxesTheoCategory(3);
        }
        // Sử lý sự kiện nhấn nút mì
        private void btnMi_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(4); // Mì
            loadPictureBoxesTheoCategory(4);
        }
        // Sử lý sự kiện nhấn nút kem
        private void btnKem_Click(object sender, EventArgs e)
        {
            loadDuLieuTheoCategory(5); // Kem
            loadPictureBoxesTheoCategory(5);
        }
        // Sử lý sự kiện nhấn nút tất cả
        private void btnAll_Click(object sender, EventArgs e)
        {
            databaseDataContext db = new databaseDataContext();
            var data = db.Menus.Select(menu => new
            {
                menu.FoodID,
                menu.CategoryID,
                menu.FoodName,
                menu.Price,
                menu.Quantity
            }).ToList();
            dvgMenu.DataSource = data;
            loadAllPictuer();
        }
        // Hàm sử lý ảnh
        private byte[] ConvertImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                if (image != null)
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Lưu dưới dạng JPEG
                }
                else
                {
                    MessageBox.Show("Ảnh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return ms.ToArray();
            }
        }
        // Sử lý sự kiện nhấn nút inds
        private void btnInds_Click(object sender, EventArgs e)
        {
            inds = true;
            btnOK.FillColor = System.Drawing.Color.Yellow;
        }
        // Sử lý sự kiện nhấn nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtDongia.Enabled = true;
            txtMaloai.Enabled = true;
            txtMamon.Enabled = true;
            txtSoluong.Enabled = true;
            txtTenmon.Enabled = true;
            pbFoodImage.Enabled = true;
            btnOK.FillColor = System.Drawing.Color.LightGray;
            sua = true;
        }
        // Sử lý sự kiện nhấn nút tìm
        private void btnTim_Click(object sender, EventArgs e)
        {
            Default();
            txtDongia.Enabled = true;
            txtMaloai.Enabled = true;
            txtMamon.Enabled = true;
            txtSoluong.Enabled = true;
            txtTenmon.Enabled = true;
            btnOK.FillColor = System.Drawing.Color.Purple;
            tim = true;
        }
        // Sử lý sự kiện nhấn nút thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            Default();
            txtDongia.Enabled = true;
            txtSoluong.Enabled = true;
            txtDongia.Enabled = true;
            txtTenmon.Enabled = true;
            txtMaloai.Enabled = true;
            pbFoodImage.Enabled = true;
            btnOK.FillColor = System.Drawing.Color.Green;
            them = true;
        }
        // Sử lý sự kiện nhấn nút xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Default();
            txtMamon.Enabled = true;
            btnOK.FillColor = System.Drawing.Color.Red;
            xoa = true;
        }
        // Sử lý sự kiện nhấn nút ok
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(them == true)
            {
                int maloai;
                if (!int.TryParse(txtMaloai.Text, out maloai))
                {
                    MessageBox.Show("Mã loại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaloai.Focus();
                    return;
                }
                string tenmon = txtTenmon.Text;
                databaseDataContext db = new databaseDataContext();
                Category ct = db.Categories.Where(c => c.CategoryID == maloai).SingleOrDefault();
                if (ct == null)
                {
                    MessageBox.Show("Mã loại không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaloai.Focus();
                    return;
                }
                if (maloai != 2 && (string.IsNullOrEmpty(ct.CategoryName) || !tenmon.Contains(ct.CategoryName)))
                {
                    MessageBox.Show("Tên món ăn không phù hợp với loại món!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenmon.Focus();
                    return;
                }
                decimal dongia = decimal.Parse(txtDongia.Text);
                int soluong = int.Parse(txtSoluong.Text);
                int maxFoodID = db.Menus.Any() ? db.Menus.Max(m => m.FoodID) : 0;
                int newFoodID = maxFoodID + 1;
                Menu newMenu = new Menu
                {
                    FoodID = newFoodID,
                    CategoryID = maloai,
                    FoodName = tenmon,
                    Price = dongia,
                    Quantity = soluong,
                    Image = pbFoodImage.Image != null ? ConvertImageToByteArray(pbFoodImage.Image) : null
                };
                db.Menus.InsertOnSubmit(newMenu);
                db.SubmitChanges();
                loadDuLieu();
                MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                them = false;
            } 
            else if(xoa == true)
            {
                int mamon;
                if (!int.TryParse(txtMaloai.Text, out mamon))
                {
                    MessageBox.Show("Mã loại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMamon.Focus();
                    return;
                }
                databaseDataContext db = new databaseDataContext();
                Menu m = db.Menus.Where(c => c.FoodID == mamon).SingleOrDefault();
                if (m == null)
                {
                    MessageBox.Show("Mã loại không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaloai.Focus();
                    return;
                }
                else
                {
                    db.Menus.DeleteOnSubmit(m);
                    db.SubmitChanges();
                    loadDuLieu();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                xoa = false;
            }
            else if(tim == true)
            {
                int? maloai = string.IsNullOrWhiteSpace(txtMaloai.Text) ? (int?)null : int.Parse(txtMaloai.Text);
                int? mamon = string.IsNullOrWhiteSpace(txtMamon.Text) ? (int?)null : int.Parse(txtMamon.Text);
                string tenmon = string.IsNullOrWhiteSpace(txtTenmon.Text) ? null : txtTenmon.Text;
                int? soluong = string.IsNullOrWhiteSpace(txtSoluong.Text) ? (int?)null : int.Parse(txtSoluong.Text);
                decimal? dongia = string.IsNullOrWhiteSpace(txtDongia.Text) ? (decimal?)null : decimal.Parse(txtDongia.Text);
                databaseDataContext db = new databaseDataContext();
                var query = db.Menus.AsQueryable();

                if (maloai.HasValue)
                {
                    query = query.Where(m => m.CategoryID == maloai.Value);
                }
                if (mamon.HasValue)
                {
                    query = query.Where(m => m.FoodID == mamon.Value);
                }
                if (!string.IsNullOrEmpty(tenmon))
                {
                    query = query.Where(m => m.FoodName.Contains(tenmon));
                }
                if (soluong.HasValue)
                {
                    query = query.Where(m => m.Quantity == soluong.Value);
                }
                if (dongia.HasValue)
                {
                    query = query.Where(m => m.Price == dongia.Value);
                }
                var results = query.ToList();
                if (results.Count > 0)
                {
                    dvgMenu.DataSource = results.Select(m => new
                    {
                        m.FoodID,
                        m.CategoryID,
                        m.FoodName,
                        m.Price,
                        m.Quantity
                    }).ToList();
                    loadPictureBoxesTheoRes(results);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tim = false;
            }
            else if (sua == true)
            {
                int mamon;
                if (!int.TryParse(txtMamon.Text, out mamon))
                {
                    MessageBox.Show("Mã món không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMamon.Focus();
                    return;
                }
                databaseDataContext db = new databaseDataContext();
                Menu existingMenu = db.Menus.SingleOrDefault(menu => menu.FoodID == mamon);

                if (existingMenu == null)
                {
                    MessageBox.Show("Không tìm thấy món ăn với mã món này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMamon.Focus();
                    return;
                }
                int maloai;
                if (!int.TryParse(txtMaloai.Text, out maloai))
                {
                    MessageBox.Show("Mã loại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaloai.Focus();
                    return;
                }
                decimal dongia;
                if (!decimal.TryParse(txtDongia.Text, out dongia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDongia.Focus();
                    return;
                }
                int soluong;
                if (!int.TryParse(txtSoluong.Text, out soluong))
                {
                    MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoluong.Focus();
                    return;
                }
                string tenmon = txtTenmon.Text.Trim();
                if (string.IsNullOrEmpty(tenmon))
                {
                    MessageBox.Show("Tên món không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenmon.Focus();
                    return;
                }
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;
                        pbFoodImage.Image = Image.FromFile(filePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                        return;
                    }
                }
                existingMenu.CategoryID = maloai;
                existingMenu.FoodName = tenmon;
                existingMenu.Price = dongia;
                existingMenu.Quantity = soluong;
                if (pbFoodImage.Image != null)
                {
                    existingMenu.Image = ConvertImageToByteArray(pbFoodImage.Image);
                }
                db.SubmitChanges();
                loadDuLieu();
                MessageBox.Show("Cập nhật thông tin món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sua = false;
            }
            else if(inds == true)
            {
                inds = false;
            } 
        }
        // Sử lý sự kiện nhấn vào thêm ảnh
        private void pbFoodImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    pbFoodImage.Image = Image.FromFile(filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                }
            }
        }
    }
}