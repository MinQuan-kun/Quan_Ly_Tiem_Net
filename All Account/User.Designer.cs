namespace Do_anLaptrinhWinCK.All_Customer
{
    partial class User
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
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelSystem = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.lblHi = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChinhsua = new Guna.UI2.WinForms.Guna2Button();
            this.panelSystem.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // panelSystem
            // 
            this.panelSystem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelSystem.BackgroundImage = global::Do_anLaptrinhWinCK.Properties.Resources.ff5c3321a863db98821f6045453aac9b;
            this.panelSystem.Controls.Add(this.guna2CustomGradientPanel2);
            this.panelSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSystem.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSystem.FillColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSystem.FillColor3 = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSystem.FillColor4 = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSystem.Location = new System.Drawing.Point(0, 0);
            this.panelSystem.Name = "panelSystem";
            this.panelSystem.Size = new System.Drawing.Size(808, 35);
            this.panelSystem.TabIndex = 5;
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.Controls.Add(this.btnChinhsua);
            this.guna2CustomGradientPanel2.Controls.Add(this.lblHi);
            this.guna2CustomGradientPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(808, 37);
            this.guna2CustomGradientPanel2.TabIndex = 17;
            // 
            // lblHi
            // 
            this.lblHi.BackColor = System.Drawing.Color.Transparent;
            this.lblHi.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHi.Location = new System.Drawing.Point(3, 3);
            this.lblHi.Name = "lblHi";
            this.lblHi.Size = new System.Drawing.Size(113, 19);
            this.lblHi.TabIndex = 7;
            this.lblHi.Text = "Quản lý tài khoản ";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.Username,
            this.Password,
            this.Email,
            this.OTP,
            this.CardID,
            this.Point,
            this.Role,
            this.Active});
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 35);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new System.Drawing.Size(808, 505);
            this.dgvUsers.TabIndex = 6;
            // 
            // UserID
            // 
            this.UserID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.UserID.DataPropertyName = "UserID";
            this.UserID.HeaderText = "UserID";
            this.UserID.MinimumWidth = 6;
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Width = 60;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.DataPropertyName = "Username";
            this.Username.HeaderText = "Username";
            this.Username.MinimumWidth = 6;
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "Pass";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 125;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 125;
            // 
            // OTP
            // 
            this.OTP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.OTP.DataPropertyName = "OTP";
            this.OTP.HeaderText = "OTP";
            this.OTP.MinimumWidth = 6;
            this.OTP.Name = "OTP";
            this.OTP.ReadOnly = true;
            this.OTP.Width = 50;
            // 
            // CardID
            // 
            this.CardID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CardID.DataPropertyName = "CardID";
            this.CardID.HeaderText = "CardID";
            this.CardID.MinimumWidth = 6;
            this.CardID.Name = "CardID";
            this.CardID.ReadOnly = true;
            this.CardID.Width = 70;
            // 
            // Point
            // 
            this.Point.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Point.DataPropertyName = "Point";
            this.Point.HeaderText = "Point";
            this.Point.MinimumWidth = 6;
            this.Point.Name = "Point";
            this.Point.ReadOnly = true;
            this.Point.Width = 60;
            // 
            // Role
            // 
            this.Role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Role.DataPropertyName = "Role";
            this.Role.HeaderText = "Role";
            this.Role.MinimumWidth = 6;
            this.Role.Name = "Role";
            this.Role.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.MinimumWidth = 6;
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            // 
            // btnChinhsua
            // 
            this.btnChinhsua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChinhsua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChinhsua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChinhsua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChinhsua.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChinhsua.FillColor = System.Drawing.Color.Black;
            this.btnChinhsua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChinhsua.ForeColor = System.Drawing.Color.White;
            this.btnChinhsua.Location = new System.Drawing.Point(659, 0);
            this.btnChinhsua.Name = "btnChinhsua";
            this.btnChinhsua.Size = new System.Drawing.Size(149, 37);
            this.btnChinhsua.TabIndex = 8;
            this.btnChinhsua.Text = "Chỉnh sửa";
            // 
            // User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panelSystem);
            this.Name = "User";
            this.Size = new System.Drawing.Size(808, 540);
            this.Load += new System.EventHandler(this.Khachhang_Load);
            this.panelSystem.ResumeLayout(false);
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel panelSystem;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHi;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn OTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private Guna.UI2.WinForms.Guna2Button btnChinhsua;
    }
}
