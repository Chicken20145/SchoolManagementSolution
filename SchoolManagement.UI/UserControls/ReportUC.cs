using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;
using SchoolManagement.DTO;

namespace SchoolManagement.UI
{
    public partial class ReportUC : UserControl
    {
        private readonly ReportService _reportService;
        private readonly ClassService _classService;
        private readonly SubjectService _subjectService;
        
        public ReportUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _reportService = new ReportService();
            _classService = new ClassService(cs);
            _subjectService = new SubjectService(cs);
        }

        private async void ReportUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            try
            {
                cboSemester.Items.Clear();
                cboSemester.Items.Add("1");
                cboSemester.Items.Add("2");
                cboSemester.SelectedIndex = 0;

                if (cboYear.SelectedIndex == -1 && cboYear.Items.Count > 0)
                    cboYear.SelectedIndex = 1;

                await LoadCombosAsync();
                ConfigureGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadCombosAsync()
        {
            try
            {
                var classes = await _classService.GetAllAsync();
                cboClass.DataSource = classes;
                cboClass.DisplayMember = "ClassName";
                cboClass.ValueMember = "ClassId";
                cboClass.SelectedIndex = -1;

                var subjects = await _subjectService.GetAllAsync();
                cboSubject.DataSource = subjects;
                cboSubject.DisplayMember = "SubjectName";
                cboSubject.ValueMember = "SubjectId";
                cboSubject.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGrid()
        {
            dgvReport.AutoGenerateColumns = false;
            dgvReport.AllowUserToAddRows = false;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.ReadOnly = true;
            dgvReport.BackgroundColor = System.Drawing.Color.White;
            dgvReport.RowHeadersVisible = false;
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentId",
                HeaderText = "Mã HS",
                DataPropertyName = "StudentId",
                Width = 80
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StudentName",
                HeaderText = "Họ và tên",
                DataPropertyName = "StudentName",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Score15",
                HeaderText = "Điểm 15'",
                DataPropertyName = "Score15",
                Width = 100
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Score45",
                HeaderText = "Điểm 45'",
                DataPropertyName = "Score45",
                Width = 100
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ScoreFinal",
                HeaderText = "Điểm CK",
                DataPropertyName = "ScoreFinal",
                Width = 100
            });

            dgvReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Average",
                HeaderText = "Trung bình",
                DataPropertyName = "Average",
                Width = 100
            });
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await LoadReportAsync();
        }

        // 1. Load báo cáo điểm
        private async Task LoadReportAsync()
        {
            try
            {
                if (cboClass.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn lớp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboSubject.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn môn học.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int classId = Convert.ToInt32(cboClass.SelectedValue);
                int subjectId = Convert.ToInt32(cboSubject.SelectedValue);

                if (!int.TryParse(Convert.ToString(cboSemester.SelectedItem), out int semester) || (semester != 1 && semester != 2))
                {
                    MessageBox.Show("Kỳ không hợp lệ (chỉ 1 hoặc 2).", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboYear.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn năm học.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string schoolYear = cboYear.SelectedItem.ToString();

                var rows = await _reportService.GetScoreSheetAsync(classId, subjectId, semester, schoolYear);
                dgvReport.DataSource = null;
                dgvReport.DataSource = rows;

                var summary = await _reportService.GetSummaryAsync(classId, subjectId, semester, schoolYear);
                if (summary == null)
                {
                    lblSummary.Text = "Chưa có dữ liệu tổng hợp.";
                }
                else
                {
                    lblSummary.Text =
                        $"Tổng HS: {summary.TotalStudents} | Có điểm: {summary.TotalScoreRows} | " +
                        $"TB 15': {(summary.Avg15?.ToString("0.##") ?? "-")} | " +
                        $"TB 45': {(summary.Avg45?.ToString("0.##") ?? "-")} | " +
                        $"TB CK: {(summary.AvgFinal?.ToString("0.##") ?? "-")} | " +
                        $"TB chung: {(summary.AvgOverall?.ToString("0.##") ?? "-")}";
                }

                if (rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Đã tải {rows.Count} học sinh.", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải báo cáo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReport.Rows.Count == 0)
                {
                    MessageBox.Show("Vui lòng tải dữ liệu trước khi xuất.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
