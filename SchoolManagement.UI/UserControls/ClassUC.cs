using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using SchoolManagement.BLL.Services;
using SchoolManagement.DTO;

namespace SchoolManagement.UI
{
    public partial class ClassUC : UserControl
    {
        private readonly ClassService _classService;
        private readonly TeacherService _teacherService;

        public ClassUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _classService = new ClassService(cs);
            _teacherService = new TeacherService(cs);
        }

        private async void ClassUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadGrades();
            await LoadTeachersAsync();
            await LoadClassDataAsync();
            SetupGrid();
        }

        private void LoadGrades()
        {
            if (cboGrade.Items.Count == 0)
            {
                cboGrade.Items.AddRange(new object[] { "10", "11", "12" });
            }
        }

        private void SetupGrid()
        {
            dgvClasses.AutoGenerateColumns = false;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.MultiSelect = false;
            dgvClasses.ReadOnly = true;
            dgvClasses.CellClick += dgvClasses_CellClick;

            if (dgvClasses.Columns["HomeroomTeacherId"] != null)
                dgvClasses.Columns["HomeroomTeacherId"].Visible = false;
            if (dgvClasses.Columns["ClassId"] != null)
                dgvClasses.Columns["ClassId"].Visible = false;

            // Add STT column at the beginning if not exists
            if (!dgvClasses.Columns.Contains("colSTT"))
            {
                var colSTT = new DataGridViewTextBoxColumn
                {
                    Name = "colSTT",
                    HeaderText = "STT",
                    ReadOnly = true,
                    Width = 60,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
                };
                dgvClasses.Columns.Insert(0, colSTT);
            }

            // Auto-numbering STT
            dgvClasses.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvClasses.Columns[e.ColumnIndex].Name == "colSTT")
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            };
        }

        private async Task LoadTeachersAsync()
        {
            try
            {
                var teachers = await _teacherService.GetAllItemsAsync();

                var nullItem = new TeacherItemDTO { TeacherId = 0, FullName = "-- Không chọn --" };
                var data = new[] { nullItem }.Concat(teachers).ToList();

                cboGVCN.DisplayMember = "FullName";
                cboGVCN.ValueMember = "TeacherId";
                cboGVCN.DataSource = data;
                cboGVCN.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải giáo viên: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadClassDataAsync()
        {
            try
            {
                var classes = await _classService.GetAllAsync();

                // Sort by Grade then ClassName
                var sortedClasses = classes.OrderBy(c => c.Grade).ThenBy(c => c.ClassName).ToList();

                dgvClasses.DataSource = null;
                dgvClasses.DataSource = sortedClasses;
                dgvClasses.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvClasses.Rows[e.RowIndex].DataBoundItem as ClassDTO;
                if (row == null) return;

                txtClassId.Text = row.ClassId.ToString();
                txtClassName.Text = row.ClassName ?? "";

                if (!string.IsNullOrWhiteSpace(row.Grade))
                    cboGrade.SelectedItem = row.Grade;
                else
                    cboGrade.SelectedIndex = -1;

                if (row.HomeroomTeacherId.HasValue && row.HomeroomTeacherId.Value > 0)
                {
                    cboGVCN.SelectedValue = row.HomeroomTeacherId.Value;
                }
                else
                {
                    cboGVCN.SelectedValue = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chọn dòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClassName.Focus();
                return;
            }

            if (cboGrade.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khối (10/11/12).", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGrade.Focus();
                return;
            }

            try
            {
                int? teacherId = null;
                if (cboGVCN.SelectedValue != null && int.TryParse(cboGVCN.SelectedValue.ToString(), out var tid) && tid > 0)
                    teacherId = tid;

                var dto = new ClassDTO
                {
                    ClassName = txtClassName.Text.Trim(),
                    Grade = cboGrade.SelectedItem?.ToString() ?? "",
                    HomeroomTeacherId = teacherId
                };

                await _classService.InsertAsync(dto);
                MessageBox.Show("Thêm lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadClassDataAsync();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show($"Tên lớp '{txtClassName.Text.Trim()}' đã tồn tại.\nVui lòng chọn tên khác.",
                    "Trùng tên lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClassName.SelectAll();
                txtClassName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassId.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtClassName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClassName.Focus();
                return;
            }

            if (cboGrade.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khối (10/11/12).", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGrade.Focus();
                return;
            }

            try
            {
                int? teacherId = null;
                if (cboGVCN.SelectedValue != null && int.TryParse(cboGVCN.SelectedValue.ToString(), out var tid) && tid > 0)
                    teacherId = tid;

                var dto = new ClassDTO
                {
                    ClassId = int.Parse(txtClassId.Text),
                    ClassName = txtClassName.Text.Trim(),
                    Grade = cboGrade.SelectedItem?.ToString() ?? "",
                    HomeroomTeacherId = teacherId
                };

                await _classService.UpdateAsync(dto);
                MessageBox.Show("Cập nhật lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadClassDataAsync();
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                MessageBox.Show($"Tên lớp '{txtClassName.Text.Trim()}' đã tồn tại.\nVui lòng chọn tên khác.",
                    "Trùng tên lớp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClassName.SelectAll();
                txtClassName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClassId.Text))
            {
                MessageBox.Show("Vui lòng chọn lớp trong bảng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa lớp này?\n\nLưu ý: Không thể xóa lớp đang có học sinh.", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                await _classService.DeleteAsync(int.Parse(txtClassId.Text));
                MessageBox.Show("Xóa lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearFields();
                await LoadClassDataAsync();
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show("Không thể xóa lớp này vì đang có học sinh trong lớp.\n\nVui lòng xóa hoặc chuyển học sinh sang lớp khác trước.",
                    "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa lớp: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClear_Click(object sender, EventArgs e) => ClearFields();

        private void ClearFields()
        {
            txtClassId.Clear();
            txtClassName.Clear();
            cboGrade.SelectedIndex = -1;
            cboGVCN.SelectedValue = 0;
            dgvClasses.ClearSelection();
            txtClassName.Focus();
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtClassId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
