using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;
using SchoolManagement.DTO;

namespace SchoolManagement.UI
{
    public partial class SubjectUC : UserControl
    {
        private readonly SubjectService _subjectService;

        public SubjectUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _subjectService = new SubjectService(cs);
        }

        private async void SubjectUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            await LoadSubjectDataAsync();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvSubjects.AutoGenerateColumns = false;
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.MultiSelect = false;
            dgvSubjects.ReadOnly = true;
            dgvSubjects.CellClick += dgvSubjects_CellClick;

            if (dgvSubjects.Columns["SubjectId"] != null)
                dgvSubjects.Columns["SubjectId"].Visible = false;

            // Add STT column at the beginning if not exists
            if (!dgvSubjects.Columns.Contains("colSTT"))
            {
                var colSTT = new DataGridViewTextBoxColumn
                {
                    Name = "colSTT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvSubjects.Columns.Insert(0, colSTT);
            }

            // Auto-numbering STT
            dgvSubjects.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvSubjects.Columns[e.ColumnIndex].Name == "colSTT")
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            };
        }

        private async Task LoadSubjectDataAsync()
        {
            try
            {
                var subjects = await _subjectService.GetAllAsync();
                
                // Sort by SubjectName A-Z
                var sortedSubjects = subjects.OrderBy(s => s.SubjectName).ToList();

                dgvSubjects.DataSource = null;
                dgvSubjects.DataSource = sortedSubjects;
                dgvSubjects.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu môn học: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvSubjects.Rows[e.RowIndex].DataBoundItem as SubjectDTO;
                if (row == null) return;

                txtSubjectId.Text = row.SubjectId.ToString();
                txtSubjectName.Text = row.SubjectName;
                txtCredit.Text = row.Credit.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectName.Focus();
                return;
            }

            if (!int.TryParse(txtCredit.Text, out int credit) || credit <= 0)
            {
                MessageBox.Show("Tín chỉ phải là số nguyên dương!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCredit.Focus();
                return;
            }

            try
            {
                var dto = new SubjectDTO
                {
                    SubjectName = txtSubjectName.Text.Trim(),
                    Credit = credit
                };

                await _subjectService.InsertAsync(dto);
                MessageBox.Show("Thêm môn học thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadSubjectDataAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Lỗi khi thêm môn học!";
                
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    errorMessage = $"Tên môn học '{txtSubjectName.Text.Trim()}' đã tồn tại.\nVui lòng nhập tên khác.";
                }
                else
                {
                    errorMessage = $"Lỗi khi thêm môn học:\n{ex.Message}";
                }
                
                MessageBox.Show(errorMessage, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectId.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần sửa trong bảng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubjectName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên môn học!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubjectName.Focus();
                return;
            }

            if (!int.TryParse(txtCredit.Text, out int credit) || credit <= 0)
            {
                MessageBox.Show("Tín chỉ phải là số nguyên dương!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCredit.Focus();
                return;
            }

            try
            {
                var dto = new SubjectDTO
                {
                    SubjectId = int.Parse(txtSubjectId.Text),
                    SubjectName = txtSubjectName.Text.Trim(),
                    Credit = credit
                };

                await _subjectService.UpdateAsync(dto);
                MessageBox.Show("Cập nhật môn học thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadSubjectDataAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Lỗi khi cập nhật môn học!";
                
                if (ex.Message.Contains("Duplicate entry") || ex.Message.Contains("duplicate key"))
                {
                    errorMessage = $"Tên môn học '{txtSubjectName.Text.Trim()}' đã tồn tại.\nVui lòng nhập tên khác.";
                }
                else
                {
                    errorMessage = $"Lỗi khi cập nhật môn học:\n{ex.Message}";
                }
                
                MessageBox.Show(errorMessage, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectId.Text))
            {
                MessageBox.Show("Vui lòng chọn môn học cần xóa trong bảng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa môn học này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                await _subjectService.DeleteAsync(int.Parse(txtSubjectId.Text));
                MessageBox.Show("Xóa môn học thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadSubjectDataAsync();
            }
            catch (Exception ex)
            {
                string errorMessage = "Lỗi khi xóa môn học!";
                
                if (ex.Message.Contains("foreign key") || ex.Message.Contains("constraint"))
                {
                    errorMessage = "Không thể xóa môn học này.\nMôn học đang được sử dụng bởi giáo viên hoặc lớp học.";
                }
                else
                {
                    errorMessage = $"Lỗi khi xóa môn học:\n{ex.Message}";
                }
                
                MessageBox.Show(errorMessage, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtSubjectId.Clear();
            txtSubjectName.Clear();
            txtCredit.Clear();
            dgvSubjects.ClearSelection();
            txtSubjectName.Focus();
        }
    }
}
