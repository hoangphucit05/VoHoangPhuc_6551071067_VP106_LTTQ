namespace KiemTra
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            txtGiaBan = new TextBox();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            Thoat = new Button();
            btnThem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            groupBox3 = new GroupBox();
            DanhSachSP = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            Gia = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DanhSachSP).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtGiaBan);
            groupBox1.Controls.Add(txtMaSP);
            groupBox1.Controls.Add(txtTenSP);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(2, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(341, 148);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản Phẩm";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(106, 103);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(121, 23);
            txtGiaBan.TabIndex = 3;
            txtGiaBan.TabStop = false;
            txtGiaBan.TextAlign = HorizontalAlignment.Right;
            txtGiaBan.MaxLength = 12;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(106, 37);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(121, 23);
            txtMaSP.TabIndex = 4;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(106, 66);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(229, 23);
            txtTenSP.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 106);
            label3.Name = "label3";
            label3.Size = new Size(85, 15);
            label3.TabIndex = 2;
            label3.Text = "Giá bán (VND):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 74);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên sản phẩm:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã sản phẩm:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Thoat);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Location = new Point(387, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(403, 148);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thao tác";
            // 
            // Thoat
            // 
            Thoat.Location = new Point(310, 61);
            Thoat.Name = "Thoat";
            Thoat.Size = new Size(75, 23);
            Thoat.TabIndex = 5;
            Thoat.Text = "Thoát";
            Thoat.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(23, 61);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(75, 23);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
  
            // btnXoa
            // 
            btnXoa.Location = new Point(212, 61);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 23);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(115, 61);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(75, 23);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DanhSachSP);
            groupBox3.Location = new Point(12, 207);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(845, 231);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Danh sách sản phẩm:";
            // 
            // DanhSachSP
            // 
            DanhSachSP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DanhSachSP.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, Gia });
            DanhSachSP.Location = new Point(3, 19);
            DanhSachSP.MultiSelect = false;
            DanhSachSP.Name = "DanhSachSP";
            DanhSachSP.ReadOnly = true;
            DanhSachSP.AllowUserToAddRows = false;
            DanhSachSP.Size = new Size(836, 212);
            DanhSachSP.TabIndex = 0;
            // 
            // MaSP
            // 
            MaSP.HeaderText = "Mã Sản Phẩm";
            MaSP.Name = "MaSP";
            MaSP.ReadOnly = true;
            // 
            // TenSP
            // 
            TenSP.HeaderText = "Tên Sản Phẩm";
            TenSP.Name = "TenSP";
            TenSP.ReadOnly = true;
            // 
            // Gia
            // 
            Gia.HeaderText = "Giá bán (VND)";
            Gia.Name = "Gia";
            Gia.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Quản Lý sản phẩm /Hàng hóa - VP106";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DanhSachSP).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtGiaBan;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button Thoat;
        private Button btnThem;
        private Button btnXoa;
        private Button btnSua;
        private GroupBox groupBox3;
        private DataGridView DanhSachSP;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn Gia;
    }
}
