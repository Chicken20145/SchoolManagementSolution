using System;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;
using SchoolManagement.DTO;

namespace SchoolManagement.UI
{
    public partial class TeacherUC : UserControl
    {
        private readonly TeacherService _teacherService;
        private readonly SubjectService _subjectService;

        public TeacherUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _teacherService = new TeacherService(cs);
            _subjectService = new SubjectService(cs);
        }

        private async void TeacherUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            await LoadSubjectsAsync();
            await LoadTeacherDataAsync();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvTeachers.AutoGenerateColumns = false;
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.MultiSelect = false;
            dgvTeachers.ReadOnly = true;
            dgvTeachers.CellClick += dgvTeachers_CellClick;

            if (dgvTeachers.Columns["SubjectId"] != null)
                dgvTeachers.Columns["SubjectId"].Visible = false;
            if (dgvTeachers.Columns["TeacherId"] != null)
                dgvTeachers.Columns["TeacherId"].Visible = false;

            // Add STT column at the beginning if not exists
            if (!dgvTeachers.Columns.Contains("colSTT"))
            {
                var colSTT = new DataGridViewTextBoxColumn
                {
                    Name = "colSTT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvTeachers.Columns.Insert(0, colSTT);
            }

            // Auto-numbering STT
            dgvTeachers.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvTeachers.Columns[e.ColumnIndex].Name == "colSTT")
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            };
        }

        private async Task LoadSubjectsAsync()
        {
            try
            {
                var subjects = await _subjectService.GetAllAsync();

                var nullItem = new SubjectDTO { SubjectId = 0, SubjectName = "-- Không chọn --" };
                var data = new[] { nullItem }.Concat(subjects).ToList();

                cboSubject.DisplayMember = "SubjectName";
                cboSubject.ValueMember = "SubjectId";
                cboSubject.DataSource = data;
                cboSubject.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải môn học: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadTeacherDataAsync()
        {
            try
            {
                var teachers = await _teacherService.GetAllAsync();
                
                // Sort by FullName A-Z
                var sortedTeachers = teachers.OrderBy(t => t.FullName).ToList();

                dgvTeachers.DataSource = null;
                dgvTeachers.DataSource = sortedTeachers;
                dgvTeachers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu giáo viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvTeachers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvTeachers.Rows[e.RowIndex].DataBoundItem as TeacherDTO;
                if (row == null) return;

                txtTeacherId.Text = row.TeacherId.ToString();
                txtTeacherName.Text = row.FullName ?? "";
                txtEmail.Text = row.Email ?? "";
                txtPhone.Text = row.Phone ?? "";

                if (row.SubjectId.HasValue && row.SubjectId.Value > 0)
                {
                    cboSubject.SelectedValue = row.SubjectId.Value;
                }
                else
                {
                    cboSubject.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTeacherInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(txtTeacherName.Text))
            {
                errorMessage = "Vui lòng nhập đầy đủ họ và tên giáo viên.";
                txtTeacherName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorMessage = "Vui lòng nhập email giáo viên.";
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                errorMessage = "Email không hợp lệ. Vui lòng nhập đúng định dạng email.";
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorMessage = "Vui lòng nhập số điện thoại giáo viên.";
                txtPhone.Focus();
                return false;
            }

            if (!IsValidPhoneNumber(txtPhone.Text.Trim()))
            {
                errorMessage = "Số điện thoại không hợp lệ.\nYêu cầu: Chỉ số, độ dài 9-10 chữ số.";
                txtPhone.Focus();
                return false;
            }

            if (cboSubject.SelectedValue == null || (int)cboSubject.SelectedValue == 0)
            {
                errorMessage = "Vui lòng chọn môn học giảng dạy.";
                cboSubject.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim();
            
            // Check if contains only digits
            if (!Regex.IsMatch(phone, @"^\d+$"))
                return false;

            // Check length: 9-10 digits
            return phone.Length >= 9 && phone.Length <= 10;
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateTeacherInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? subjectId = null;
                if (cboSubject.SelectedValue != null && int.TryParse(cboSubject.SelectedValue.ToString(), out var sid) && sid > 0)
                    subjectId = sid;

                var dto = new TeacherDTO
                {
                    FullName = txtTeacherName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    SubjectId = subjectId
                };

                await _teacherService.InsertAsync(dto);
                MessageBox.Show("Thêm giáo viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadTeacherDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm giáo viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeacherId.Text))
            {
                MessageBox.Show("Vui lòng chọn giáo viên trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateTeacherInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int? subjectId = null;
                if (cboSubject.SelectedValue != null && int.TryParse(cboSubject.SelectedValue.ToString(), out var sid) && sid > 0)
                    subjectId = sid;

                var dto = new TeacherDTO
                {
                    TeacherId = int.Parse(txtTeacherId.Text),
                    FullName = txtTeacherName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    SubjectId = subjectId
                };

                await _teacherService.UpdateAsync(dto);
                MessageBox.Show("Cập nhật giáo viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadTeacherDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa giáo viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTeacherId.Text))
            {
                MessageBox.Show("Vui lòng chọn giáo viên trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa giáo viên này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                await _teacherService.DeleteAsync(int.Parse(txtTeacherId.Text));
                MessageBox.Show("Xóa giáo viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                ClearFields();
                await LoadTeacherDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa giáo viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtTeacherId.Clear();
            txtTeacherName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            cboSubject.SelectedValue = 0;
            dgvTeachers.ClearSelection();
            txtTeacherName.Focus();
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
