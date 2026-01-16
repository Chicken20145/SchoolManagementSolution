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
    public partial class StudentUC : UserControl
    {
        private readonly StudentService _studentService = new StudentService();
        private readonly ClassService _classService;

        public StudentUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _classService = new ClassService(cs);
        }

        private async void StudentUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            await LoadClassesAsync();
            await LoadStudentDataAsync();
            SetupGrid();
        }

        private void SetupGrid()
        {
            dgvStudents.AutoGenerateColumns = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.CellClick += dgvStudents_CellClick;

            dgvStudents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvStudents.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvStudents.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            HideIfExists("ClassId");
            HideIfExists("Status");
            HideIfExists("StudentId");

            // Add STT column at the beginning if not exists
            if (!dgvStudents.Columns.Contains("colSTT"))
            {
                var colSTT = new DataGridViewTextBoxColumn
                {
                    Name = "colSTT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvStudents.Columns.Insert(0, colSTT);
            }

            // Auto-numbering STT
            dgvStudents.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvStudents.Columns[e.ColumnIndex].Name == "colSTT")
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            };
        }

        private void HideIfExists(string colName)
        {
            if (dgvStudents.Columns.Contains(colName))
                dgvStudents.Columns[colName].Visible = false;
        }

        private async Task LoadClassesAsync()
        {
            try
            {
                var classes = await _classService.GetItemsAsync();

                cboClass.DisplayMember = "ClassName";
                cboClass.ValueMember = "ClassId";
                cboClass.DataSource = classes;
                cboClass.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lớp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadStudentDataAsync()
        {
            try
            {
                var students = cboClass.SelectedIndex >= 0
                    ? await _studentService.GetByClassAsync((int)cboClass.SelectedValue)
                    : await _studentService.GetAllAsync();

                // Sort by FullName A-Z
                var sortedStudents = students.OrderBy(s => s.FullName).ToList();

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = sortedStudents;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;

            if (cboClass.SelectedItem is ClassDTO selectedClass)
            {
                txtGrade.Text = selectedClass.Grade ?? "";
            }
            else
            {
                txtGrade.Text = "";
            }

            await LoadStudentDataAsync();
        }

        private bool ValidateStudentInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorMessage = "Vui lòng nhập đầy đủ họ và tên học sinh.";
                txtFullName.Focus();
                return false;
            }

            if (cboClass.SelectedIndex < 0)
            {
                errorMessage = "Vui lòng chọn lớp học.";
                cboClass.Focus();
                return false;
            }

            if (cboGender.SelectedIndex < 0)
            {
                errorMessage = "Vui lòng chọn giới tính.";
                cboGender.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorMessage = "Vui lòng nhập số điện thoại.";
                txtPhone.Focus();
                return false;
            }

            if (!IsValidPhoneNumber(txtPhone.Text.Trim()))
            {
                errorMessage = "Số điện thoại không hợp lệ.\nYêu cầu: Chỉ số, độ dài 9-10 chữ số.";
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorMessage = "Vui lòng nhập địa chỉ.";
                txtAddress.Focus();
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

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new StudentDTO
                {
                    FullName = txtFullName.Text.Trim(),
                    Dob = dtpDOB.Value.Date,
                    Gender = cboGender.SelectedItem?.ToString(),
                    ClassId = (int)cboClass.SelectedValue,
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = (byte)(chkStatus.Checked ? 1 : 0)
                };

                await _studentService.AddAsync(dto);
                MessageBox.Show("Thêm học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadStudentDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 học sinh trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateStudentInput(out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new StudentDTO
                {
                    StudentId = int.Parse(txtStudentId.Text),
                    FullName = txtFullName.Text.Trim(),
                    Dob = dtpDOB.Value.Date,
                    Gender = cboGender.SelectedItem?.ToString(),
                    ClassId = (int)cboClass.SelectedValue,
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = (byte)(chkStatus.Checked ? 1 : 0)
                };

                await _studentService.UpdateAsync(dto);
                MessageBox.Show("Cập nhật học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadStudentDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 học sinh trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa học sinh này?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                await _studentService.DeleteAsync(int.Parse(txtStudentId.Text));
                MessageBox.Show("Xóa học sinh thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                await LoadStudentDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa học sinh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearFields();

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvStudents.Rows[e.RowIndex].DataBoundItem as StudentDTO;
                if (row == null) return;

                txtStudentId.Text = row.StudentId.ToString();
                txtFullName.Text = row.FullName;
                dtpDOB.Value = row.Dob ?? DateTime.Now;
                cboGender.SelectedItem = row.Gender ?? "Nam";
                cboClass.SelectedValue = row.ClassId;
                txtPhone.Text = row.Phone ?? "";
                txtAddress.Text = row.Address ?? "";
                chkStatus.Checked = row.Status == 1;
                txtGrade.Text = row.Grade ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtGrade.Clear();
            cboGender.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            cboClass.SelectedIndex = -1;
            chkStatus.Checked = true;
            txtFullName.Focus();
        }
    }
}
