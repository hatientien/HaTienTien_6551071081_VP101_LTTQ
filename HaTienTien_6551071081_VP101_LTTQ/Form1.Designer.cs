namespace HaTienTien_6551071081_VP101_LTTQ
{
    partial class FrmQuanLyCongViec
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
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvCongViec = new DataGridView();
            btnThem = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            groupBox2 = new GroupBox();
            colMa = new DataGridViewTextBoxColumn();
            colTen = new DataGridViewTextBoxColumn();
            colLuong = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongViec).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(56, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(824, 159);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin công việc";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(377, 99);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(268, 27);
            textBox3.TabIndex = 5;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(377, 68);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(268, 27);
            textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(377, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(268, 27);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 106);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 2;
            label3.Text = "Lương tháng:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 75);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên công việc:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 43);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã công việc:";
            // 
            // dgvCongViec
            // 
            dgvCongViec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCongViec.Columns.AddRange(new DataGridViewColumn[] { colMa, colTen, colLuong });
            dgvCongViec.Location = new Point(15, 26);
            dgvCongViec.Name = "dgvCongViec";
            dgvCongViec.RowHeadersWidth = 51;
            dgvCongViec.AutoGenerateColumns = false;
            dgvCongViec.ReadOnly = true;
            dgvCongViec.AllowUserToAddRows = false;
            dgvCongViec.AllowUserToDeleteRows = false;
            dgvCongViec.MultiSelect = false;
            dgvCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCongViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCongViec.Size = new Size(803, 214);
            dgvCongViec.TabIndex = 1;
            dgvCongViec.CellClick += dgvCongViec_CellClick;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(132, 492);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(86, 57);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.Location = new Point(291, 492);
            button2.Name = "button2";
            button2.Size = new Size(104, 57);
            button2.TabIndex = 3;
            button2.Text = "Sửa ";
            button2.Enabled = false;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(470, 492);
            button3.Name = "button3";
            button3.Size = new Size(101, 57);
            button3.TabIndex = 4;
            button3.Text = "Xóa ";
            button3.Enabled = false;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(653, 492);
            button4.Name = "button4";
            button4.Size = new Size(94, 57);
            button4.TabIndex = 5;
            button4.Text = "Thoát";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvCongViec);
            groupBox2.Location = new Point(56, 246);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(824, 240);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách công việc";
            // 
            // colMa
            // 
            colMa.DataPropertyName = "MaCongViec";
            colMa.HeaderText = "Mã Công Việc";
            colMa.MinimumWidth = 6;
            colMa.Name = "colMa";
            colMa.ReadOnly = true;
            colMa.Visible = true;
            colMa.Width = 125;
            // 
            // colTen
            // 
            colTen.DataPropertyName = "TenCongViec";
            colTen.HeaderText = "Tên Công Việc";
            colTen.MinimumWidth = 6;
            colTen.Name = "colTen";
            colTen.ReadOnly = true;
            colTen.Visible = true;
            colTen.Width = 125;
            // 
            // colLuong
            // 
            colLuong.DataPropertyName = "LuongThang";
            colLuong.HeaderText = "Lương Tháng";
            colLuong.MinimumWidth = 6;
            colLuong.Name = "colLuong";
            colLuong.ReadOnly = true;
            colLuong.Visible = true;
            colLuong.Width = 125;
            // 
            // FrmQuanLyCongViec
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 619);
            Controls.Add(groupBox2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnThem);
            Controls.Add(groupBox1);
            Name = "FrmQuanLyCongViec";
            Text = "Quản lý công việc - frmCongViec";
            Load += FrmQuanLyCongViec_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCongViec).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvCongViec;
        private Button btnThem;
        private Button button2;
        private Button button3;
        private Button button4;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn colMa;
        private DataGridViewTextBoxColumn colTen;
        private DataGridViewTextBoxColumn colLuong;
    }
}
