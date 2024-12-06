namespace Do_anLaptrinhWinCK.All_Computer
{
    partial class Computer
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
            this.PanelIfor = new System.Windows.Forms.Panel();
            this.PanelHoadon = new System.Windows.Forms.Panel();
            this.PanelMay = new System.Windows.Forms.Panel();
            this.Panelmenu = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PanelCauhinh = new System.Windows.Forms.Panel();
            this.PanelType = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PanelIfor.SuspendLayout();
            this.Panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.PanelType.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelIfor
            // 
            this.PanelIfor.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PanelIfor.Controls.Add(this.Panelmenu);
            this.PanelIfor.Controls.Add(this.PanelMay);
            this.PanelIfor.Controls.Add(this.PanelHoadon);
            this.PanelIfor.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelIfor.Location = new System.Drawing.Point(517, 0);
            this.PanelIfor.Name = "PanelIfor";
            this.PanelIfor.Size = new System.Drawing.Size(236, 564);
            this.PanelIfor.TabIndex = 0;
            // 
            // PanelHoadon
            // 
            this.PanelHoadon.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelHoadon.Location = new System.Drawing.Point(0, 464);
            this.PanelHoadon.Name = "PanelHoadon";
            this.PanelHoadon.Size = new System.Drawing.Size(236, 100);
            this.PanelHoadon.TabIndex = 0;
            // 
            // PanelMay
            // 
            this.PanelMay.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelMay.Location = new System.Drawing.Point(0, 0);
            this.PanelMay.Name = "PanelMay";
            this.PanelMay.Size = new System.Drawing.Size(236, 100);
            this.PanelMay.TabIndex = 1;
            // 
            // Panelmenu
            // 
            this.Panelmenu.Controls.Add(this.dataGridView1);
            this.Panelmenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panelmenu.Location = new System.Drawing.Point(0, 100);
            this.Panelmenu.Name = "Panelmenu";
            this.Panelmenu.Size = new System.Drawing.Size(236, 364);
            this.Panelmenu.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(236, 364);
            this.dataGridView1.TabIndex = 0;
            // 
            // PanelCauhinh
            // 
            this.PanelCauhinh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelCauhinh.Location = new System.Drawing.Point(0, 464);
            this.PanelCauhinh.Name = "PanelCauhinh";
            this.PanelCauhinh.Size = new System.Drawing.Size(517, 100);
            this.PanelCauhinh.TabIndex = 1;
            // 
            // PanelType
            // 
            this.PanelType.Controls.Add(this.button3);
            this.PanelType.Controls.Add(this.button2);
            this.PanelType.Controls.Add(this.button1);
            this.PanelType.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelType.Location = new System.Drawing.Point(0, 0);
            this.PanelType.Name = "PanelType";
            this.PanelType.Size = new System.Drawing.Size(517, 77);
            this.PanelType.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(141, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Computer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.PanelType);
            this.Controls.Add(this.PanelCauhinh);
            this.Controls.Add(this.PanelIfor);
            this.Name = "Computer";
            this.Size = new System.Drawing.Size(753, 564);
            this.PanelIfor.ResumeLayout(false);
            this.Panelmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.PanelType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelIfor;
        private System.Windows.Forms.Panel PanelHoadon;
        private System.Windows.Forms.Panel PanelMay;
        private System.Windows.Forms.Panel Panelmenu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel PanelCauhinh;
        private System.Windows.Forms.Panel PanelType;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
