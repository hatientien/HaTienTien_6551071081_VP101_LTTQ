using Microsoft.Data.SqlClient;
using HaTienTien_6551071081_VP101_LTTQ.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;

namespace HaTienTien_6551071081_VP101_LTTQ
{
    public partial class FrmQuanLyCongViec : Form
    {
        private string? selectedJobId;
        private string lastSalaryText = string.Empty;

        public FrmQuanLyCongViec()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.MaxLength = 10;
            textBox3.MaxLength = 8;
            dgvCongViec.AutoGenerateColumns = false;
            dgvCongViec.ReadOnly = true;
            dgvCongViec.AllowUserToAddRows = false;
            dgvCongViec.AllowUserToDeleteRows = false;
            dgvCongViec.MultiSelect = false;
            dgvCongViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textBox3.TextChanged += SalaryTextBox_TextChanged;
            textBox1.TextChanged += Input_TextChanged;
            textBox2.TextChanged += Input_TextChanged;
            textBox3.TextChanged += Input_TextChanged;
            FormClosing += FrmQuanLyCongViec_FormClosing;
        }

        private async void FrmQuanLyCongViec_Load(object? sender, EventArgs e)
        {
            try
            {
                await LoadJobsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể kết nối SQL Server hoặc khởi tạo cơ sở dữ liệu DuLieu.\n\n{ex.Message}\n\nHãy kiểm tra SQL Server (localhost) đã được cài đặt và đang chạy.",
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadJobsAsync()
        {
            await using var db = new DuLieuContext();
            dgvCongViec.DataSource = await db.CongViecs.AsNoTracking()
                .OrderBy(job => job.MaCongViec).ToListAsync();
            ResetForm();
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!TryReadForm(out var id, out var name, out var salary))
            {
                return;
            }

            try
            {
                await using var db = new DuLieuContext();
                if (await db.CongViecs.AnyAsync(job => job.MaCongViec == id))
                {
                    MessageBox.Show("Mã công việc đã tồn tại.", "Dữ liệu trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
                db.CongViecs.Add(new CongViec { MaCongViec = id, TenCongViec = name, LuongThang = salary });
                await db.SaveChangesAsync();
                await LoadJobsAsync();
                btnThem.Enabled = false;
                MessageBox.Show("Đã thêm công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException { Number: 2627 or 2601 })
            {
                MessageBox.Show("Mã công việc đã tồn tại.", "Dữ liệu trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private async void button2_Click(object? sender, EventArgs e)
        {
            if (!TryReadForm(out var id, out var name, out var salary))
            {
                return;
            }

            try
            {
                if (selectedJobId is null)
                {
                    return;
                }
                var originalId = selectedJobId;
                await using var db = new DuLieuContext();
                var job = await db.CongViecs.FindAsync(originalId);
                if (job is null)
                {
                    MessageBox.Show("Công việc không còn tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await LoadJobsAsync();
                    return;
                }
                if (originalId != id)
                {
                    if (await db.CongViecs.AnyAsync(item => item.MaCongViec == id))
                    {
                        MessageBox.Show("Mã công việc đã tồn tại.", "Dữ liệu trùng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    db.CongViecs.Remove(job);
                    db.CongViecs.Add(new CongViec { MaCongViec = id, TenCongViec = name, LuongThang = salary });
                }
                else
                {
                    job.TenCongViec = name;
                    job.LuongThang = salary;
                }
                await db.SaveChangesAsync();
                await LoadJobsAsync();
                MessageBox.Show("Đã cập nhật thông tin công việc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private async void button3_Click(object? sender, EventArgs e)
        {
            if (selectedJobId is null)
            {
                return;
            }

            var id = selectedJobId;
            if (MessageBox.Show("Bạn có muốn xóa công việc này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                ResetForm();
                return;
            }

            try
            {
                await using var db = new DuLieuContext();
                var job = await db.CongViecs.FindAsync(id);
                if (job is not null)
                {
                    db.CongViecs.Remove(job);
                    await db.SaveChangesAsync();
                }
                await LoadJobsAsync();
            }
            catch (Exception ex)
            {
                ShowDatabaseError(ex);
            }
        }

        private void button4_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void FrmQuanLyCongViec_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
            }
        }

        private void dgvCongViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvCongViec.Rows[e.RowIndex].DataBoundItem is not CongViec job)
            {
                return;
            }
            selectedJobId = job.MaCongViec;
            textBox1.Text = job.MaCongViec;
            textBox2.Text = job.TenCongViec;
            textBox3.Text = job.LuongThang;
            SetSelectionMode(true);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsAsciiDigit(e.KeyChar)
                && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '+' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void SalaryTextBox_TextChanged(object? sender, EventArgs e)
        {
            var text = textBox3.Text;
            if (Regex.IsMatch(text, @"^[+-]?[0-9]*([.,][0-9]*)?$"))
            {
                lastSalaryText = text;
                return;
            }

            var position = textBox3.SelectionStart;
            textBox3.Text = lastSalaryText;
            textBox3.SelectionStart = Math.Min(position, lastSalaryText.Length);
        }

        private void Input_TextChanged(object? sender, EventArgs e)
        {
            if (selectedJobId is null)
            {
                btnThem.Enabled = textBox1.Text.Length > 0 || textBox2.Text.Length > 0 || textBox3.Text.Length > 0;
            }
        }

        private void ResetForm()
        {
            selectedJobId = null;
            dgvCongViec.ClearSelection();
            dgvCongViec.CurrentCell = null;
            ClearFields();
            SetSelectionMode(false);
        }

        private bool TryReadForm(out string id, out string name, out string salary)
        {
            id = textBox1.Text.Trim();
            name = textBox2.Text.Trim();
            salary = textBox3.Text.Trim();

            if (id.Length == 0 || name.Length == 0 || salary.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã công việc, tên công việc và lương tháng.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (id.Length > 10)
            {
                MessageBox.Show("Mã công việc tối đa 10 ký tự.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
                return false;
            }

            if (salary.Length > 8 || (!Regex.IsMatch(salary, @"^[+-]?([0-9]+([.,][0-9]*)?|[.,][0-9]+)$") || !decimal.TryParse(salary.Replace(',', '.'), NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _)))
            {
                MessageBox.Show("Lương tháng phải là số và có tối đa 8 ký tự.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;
            }

            return true;
        }

        private void SetSelectionMode(bool selected)
        {
            btnThem.Enabled = !selected;
            button2.Enabled = selected;
            button3.Enabled = selected;
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private static void ShowDatabaseError(Exception ex)
        {
            MessageBox.Show($"Không thể lưu dữ liệu công việc.\n\n{ex.Message}", "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
