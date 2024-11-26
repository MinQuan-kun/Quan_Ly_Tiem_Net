namespace Do_anLaptrinhWinCK.All_Computer
{
    partial class ThucDon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Guna2Button btnAll;
            Guna.UI2.WinForms.Guna2Button btnKem;
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.dvgMenu = new System.Windows.Forms.DataGridView();
            this.FoodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuoc = new Guna.UI2.WinForms.Guna2Button();
            this.btnCom = new Guna.UI2.WinForms.Guna2Button();
            this.btnMi = new Guna.UI2.WinForms.Guna2Button();
            this.btnSnack = new Guna.UI2.WinForms.Guna2Button();
            this.panelMenu = new System.Windows.Forms.Panel();
            btnAll = new Guna.UI2.WinForms.Guna2Button();
            btnKem = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(btnAll);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(btnKem);
            this.panel1.Controls.Add(this.btnNuoc);
            this.panel1.Controls.Add(this.btnCom);
            this.panel1.Controls.Add(this.btnMi);
            this.panel1.Controls.Add(this.btnSnack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 58);
            this.panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThem.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Location = new System.Drawing.Point(682, 0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(71, 58);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // dvgMenu
            // 
            this.dvgMenu.AllowUserToAddRows = false;
            this.dvgMenu.AllowUserToDeleteRows = false;
            this.dvgMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgMenu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FoodID,
            this.FoodName,
            this.Price});
            this.dvgMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.dvgMenu.Location = new System.Drawing.Point(421, 0);
            this.dvgMenu.Name = "dvgMenu";
            this.dvgMenu.ReadOnly = true;
            this.dvgMenu.RowHeadersWidth = 51;
            this.dvgMenu.RowTemplate.Height = 24;
            this.dvgMenu.Size = new System.Drawing.Size(332, 506);
            this.dvgMenu.TabIndex = 1;
            // 
            // FoodID
            // 
            this.FoodID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FoodID.DataPropertyName = "FoodID";
            this.FoodID.HeaderText = "Mã món ăn";
            this.FoodID.MinimumWidth = 6;
            this.FoodID.Name = "FoodID";
            this.FoodID.ReadOnly = true;
            this.FoodID.Width = 104;
            // 
            // FoodName
            // 
            this.FoodName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FoodName.DataPropertyName = "FoodName";
            this.FoodName.HeaderText = "Tên món";
            this.FoodName.MinimumWidth = 6;
            this.FoodName.Name = "FoodName";
            this.FoodName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Đơn giá";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 83;
            // 
            // btnAll
            // 
            btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            btnAll.Dock = System.Windows.Forms.DockStyle.Left;
            btnAll.FillColor = System.Drawing.Color.Black;
            btnAll.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnAll.ForeColor = System.Drawing.Color.White;
            btnAll.HoverState.BorderColor = System.Drawing.Color.White;
            btnAll.HoverState.CustomBorderColor = System.Drawing.Color.White;
            btnAll.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Select_All;
            btnAll.ImageOffset = new System.Drawing.Point(10, -10);
            btnAll.Location = new System.Drawing.Point(340, 0);
            btnAll.Name = "btnAll";
            btnAll.Size = new System.Drawing.Size(78, 58);
            btnAll.TabIndex = 24;
            btnAll.Text = "Tất cả";
            btnAll.TextOffset = new System.Drawing.Point(-5, 10);
            btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnKem
            // 
            btnKem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnKem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnKem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            btnKem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            btnKem.Dock = System.Windows.Forms.DockStyle.Left;
            btnKem.FillColor = System.Drawing.Color.Black;
            btnKem.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnKem.ForeColor = System.Drawing.Color.White;
            btnKem.HoverState.BorderColor = System.Drawing.Color.White;
            btnKem.HoverState.CustomBorderColor = System.Drawing.Color.White;
            btnKem.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Kawaii_Ice_Cream;
            btnKem.ImageOffset = new System.Drawing.Point(7, -10);
            btnKem.Location = new System.Drawing.Point(272, 0);
            btnKem.Name = "btnKem";
            btnKem.Size = new System.Drawing.Size(68, 58);
            btnKem.TabIndex = 19;
            btnKem.Text = "Kem";
            btnKem.TextOffset = new System.Drawing.Point(-5, 10);
            btnKem.Click += new System.EventHandler(this.btnKem_Click);
            // 
            // btnNuoc
            // 
            this.btnNuoc.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNuoc.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNuoc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNuoc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNuoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNuoc.FillColor = System.Drawing.Color.Black;
            this.btnNuoc.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuoc.ForeColor = System.Drawing.Color.White;
            this.btnNuoc.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Wine_Bar;
            this.btnNuoc.ImageOffset = new System.Drawing.Point(8, -10);
            this.btnNuoc.Location = new System.Drawing.Point(204, 0);
            this.btnNuoc.Name = "btnNuoc";
            this.btnNuoc.Size = new System.Drawing.Size(68, 58);
            this.btnNuoc.TabIndex = 21;
            this.btnNuoc.Text = "Nước";
            this.btnNuoc.TextOffset = new System.Drawing.Point(-5, 10);
            this.btnNuoc.Click += new System.EventHandler(this.btnNuoc_Click);
            // 
            // btnCom
            // 
            this.btnCom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCom.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCom.FillColor = System.Drawing.Color.Black;
            this.btnCom.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCom.ForeColor = System.Drawing.Color.White;
            this.btnCom.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Rice_Bowl;
            this.btnCom.ImageOffset = new System.Drawing.Point(8, -10);
            this.btnCom.Location = new System.Drawing.Point(136, 0);
            this.btnCom.Name = "btnCom";
            this.btnCom.Size = new System.Drawing.Size(68, 58);
            this.btnCom.TabIndex = 20;
            this.btnCom.Text = "Cơm";
            this.btnCom.TextOffset = new System.Drawing.Point(-5, 10);
            this.btnCom.Click += new System.EventHandler(this.btnCom_Click);
            // 
            // btnMi
            // 
            this.btnMi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMi.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMi.FillColor = System.Drawing.Color.Black;
            this.btnMi.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMi.ForeColor = System.Drawing.Color.White;
            this.btnMi.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Kawaii_Noodle;
            this.btnMi.ImageOffset = new System.Drawing.Point(5, -10);
            this.btnMi.Location = new System.Drawing.Point(68, 0);
            this.btnMi.Name = "btnMi";
            this.btnMi.Size = new System.Drawing.Size(68, 58);
            this.btnMi.TabIndex = 15;
            this.btnMi.Text = "Mì";
            this.btnMi.TextOffset = new System.Drawing.Point(-5, 10);
            this.btnMi.Click += new System.EventHandler(this.btnMi_Click);
            // 
            // btnSnack
            // 
            this.btnSnack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSnack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSnack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSnack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSnack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSnack.FillColor = System.Drawing.Color.Black;
            this.btnSnack.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnack.ForeColor = System.Drawing.Color.White;
            this.btnSnack.Image = global::Do_anLaptrinhWinCK.Properties.Resources.Potato_Chips;
            this.btnSnack.ImageOffset = new System.Drawing.Point(10, -10);
            this.btnSnack.Location = new System.Drawing.Point(0, 0);
            this.btnSnack.Name = "btnSnack";
            this.btnSnack.Size = new System.Drawing.Size(68, 58);
            this.btnSnack.TabIndex = 14;
            this.btnSnack.Text = "Snack";
            this.btnSnack.TextOffset = new System.Drawing.Point(-5, 10);
            this.btnSnack.Click += new System.EventHandler(this.btnSnack_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(421, 506);
            this.panelMenu.TabIndex = 2;
            // 
            // ThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.dvgMenu);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ThucDon";
            this.Size = new System.Drawing.Size(753, 564);
            this.Load += new System.EventHandler(this.ThucDon_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvgMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnNuoc;
        private Guna.UI2.WinForms.Guna2Button btnCom;
        private Guna.UI2.WinForms.Guna2Button btnMi;
        private Guna.UI2.WinForms.Guna2Button btnSnack;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dvgMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.Panel panelMenu;
    }
}
