using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;
using SchoolManagement.DTO;
using System.Globalization;

namespace SchoolManagement.UI
{
    public partial class ScoreUC : UserControl
    {
        private readonly ScoreService _scoreService;
        private readonly ClassService _classService;
        private readonly SubjectService _subjectService;
        private BindingList<ScoreEntryDTO> _bindingList = new();
        private HashSet<int> _dirtyRows = new();

        public ScoreUC()
        {
            InitializeComponent();

            var cs = ConfigurationManager.ConnectionStrings["SchoolDb"]?.ConnectionString
                     ?? throw new ConfigurationErrorsException("Missing 'SchoolDb' connection string in App.config");
            _scoreService = new ScoreService();
            _classService = new ClassService(cs);
            _subjectService = new SubjectService(cs);
        }

        private async void ScoreUC_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            try
            {
                SetButtonsEnabled(false);
                
                cboSemester.Items.Clear();
                cboSemester.Items.Add("1");
                cboSemester.Items.Add("2");
                cboSemester.SelectedIndex = 0;

                if (string.IsNullOrWhiteSpace(txtYear.Text))
                    txtYear.Text = "2024-2025";

                await LoadCombosAsync();
                ConfigureGrid();
                SetupGridEvents();
                
                SetButtonsEnabled(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetButtonsEnabled(false);
            }
        }

        private void SetButtonsEnabled(bool enabled)
        {
            btnLoad.Enabled = enabled;
            btnSave.Enabled = enabled;
            btnCalc.Enabled = enabled;
            btnClear.Enabled = enabled;
        }

        private async Task LoadCombosAsync()
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

        private void ConfigureGrid()
        {
            dgvScores.AutoGenerateColumns = false;
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvScores.BackgroundColor = System.Drawing.Color.White;
            dgvScores.RowHeadersVisible = false;
            dgvScores.Columns.Clear();

            // Hidden columns
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScoreId",
                DataPropertyName = "ScoreId",
                Visible = false
            });

            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentId",
                DataPropertyName = "StudentId",
                Visible = false
            });

            // STT column (unbound - auto numbering)
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSTT",
                HeaderText = "STT",
                ReadOnly = true,
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // Student Name (sorted A-Z)
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentName",
                HeaderText = "Họ và tên",
                DataPropertyName = "StudentName",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 200
            });

            // Score columns
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScore15",
                HeaderText = "Điểm 15'",
                DataPropertyName = "Score15",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    NullValue = "",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScore45",
                HeaderText = "Điểm 45'",
                DataPropertyName = "Score45",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    NullValue = "",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScoreFinal",
                HeaderText = "Điểm CK",
                DataPropertyName = "ScoreFinal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle 
                { 
                    NullValue = "",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAvg",
                HeaderText = "Điểm TB",
                DataPropertyName = "AverageScore",
                ReadOnly = true,
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    NullValue = "",
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = System.Drawing.Color.LightGoldenrodYellow,
                    Format = "0.00"
                }
            });

            dgvScores.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRank",
                HeaderText = "Xếp loại",
                DataPropertyName = "Rank",
                ReadOnly = true,
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    NullValue = "",
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    BackColor = System.Drawing.Color.LightCyan
                }
            });

            // Auto-numbering STT when formatting
            dgvScores.CellFormatting += DgvScores_CellFormatting;


            // Auto-numbering STT when formatting
            dgvScores.CellFormatting += DgvScores_CellFormatting;
        }

        private void DgvScores_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvScores.Columns[e.ColumnIndex].Name == "colSTT")
            {
                e.Value = (e.RowIndex + 1).ToString();
                e.FormattingApplied = true;
            }
        }

        private void SetupGridEvents()
        {
            dgvScores.CellValidating += DgvScores_CellValidating;
            dgvScores.CellValueChanged += DgvScores_CellValueChanged;
            dgvScores.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvScores.IsCurrentCellDirty)
                {
                    dgvScores.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
        }

        private void DgvScores_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            var col = dgvScores.Columns[e.ColumnIndex].Name;
            if (col != "colScore15" && col != "colScore45" && col != "colScoreFinal") return;

            var valueStr = (e.FormattedValue?.ToString() ?? "").Trim();

            if (string.IsNullOrEmpty(valueStr)) return;

            // Chuyển dấu phẩy thành dấu chấm
            valueStr = valueStr.Replace(',', '.');

            // Parse với InvariantCulture để đảm bảo dấu chấm được nhận dạng
            if (!float.TryParse(valueStr, NumberStyles.Float, CultureInfo.InvariantCulture, out var value) || value < 0 || value > 10)
            {
                e.Cancel = true;
                MessageBox.Show("Điểm phải trong khoảng 0 - 10 (hoặc để trống).\n\nCó thể nhập: 7.5 hoặc 7,5",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DgvScores_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvScores.Columns[e.ColumnIndex].Name;
            if (col != "colScore15" && col != "colScore45" && col != "colScoreFinal") return;

            _dirtyRows.Add(e.RowIndex); // Track row đã sửa

            dgvScores.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow; // Highlight màu vàng
        }
        #region Tính TB + Xếp Loại

        private decimal? ParseScore(object? value)
        {
            if (value == null || value == DBNull.Value) return null;
            var s = Convert.ToString(value)?.Trim();
            if (string.IsNullOrWhiteSpace(s)) return null;
            s = s.Replace(',', '.');
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
                return d;
            return null;
        }

        private decimal CalculateAverage(decimal? score15, decimal? score45, decimal? scoreFinal)
        {
            if (!score15.HasValue && !score45.HasValue && !scoreFinal.HasValue)
                return 0;
            var s15 = score15 ?? 0;
            var s45 = score45 ?? 0;
            var sFinal = scoreFinal ?? 0;
            return Math.Round((s15 + s45 + (sFinal * 2m)) / 4m, 2);
        }

        private string CalculateRank(decimal avg)
        {
            if (avg >= 8.0m) return "Giỏi";
            if (avg >= 6.5m) return "Khá";
            if (avg >= 5.0m) return "Trung bình";
            if (avg >= 3.5m) return "Yếu";
            if (avg > 0) return "Kém";
            return "";
        }

        private void ComputeAverageAndRankForAllStudents()
        {
            if (_bindingList == null || _bindingList.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu. Vui lòng bấm 'Tải danh sách' trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int calculated = 0;
            int skipped = 0;

            foreach (var entry in _bindingList)
            {
                var s15 = entry.Score15.HasValue ? (decimal?)entry.Score15.Value : null;
                var s45 = entry.Score45.HasValue ? (decimal?)entry.Score45.Value : null;
                var sFinal = entry.ScoreFinal.HasValue ? (decimal?)entry.ScoreFinal.Value : null;

                if (!s15.HasValue && !s45.HasValue && !sFinal.HasValue)
                {
                    entry.AverageScore = null;
                    entry.Rank = "";
                    skipped++;
                    continue;
                }

                var avg = CalculateAverage(s15, s45, sFinal);
                entry.AverageScore = avg;
                entry.Rank = CalculateRank(avg);
                calculated++;
            }

            dgvScores.Refresh();

            var message = $"✅ Đã tính điểm trung bình và xếp loại cho {calculated} học sinh.\n\n";
            if (skipped > 0)
                message += $"⚠️ Bỏ qua {skipped} học sinh chưa có điểm.\n\n";
            message += "📊 Công thức: TB = (Điểm 15' + Điểm 45' + Điểm CK × 2) / 4\n\n";
            message += "📝 Tiêu chí xếp loại:\n";
            message += "   • Giỏi: TB ≥ 8.0\n   • Khá: TB ≥ 6.5\n   • Trung bình: TB ≥ 5.0\n   • Yếu: TB ≥ 3.5\n   • Kém: TB < 3.5";

            MessageBox.Show(message, "Tính TB + Xếp loại thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        private (int classId, int subjectId, int semester, string schoolYear) ReadFilter()
        {
            if (cboClass.SelectedValue == null) throw new Exception("Vui lòng chọn lớp.");
            if (cboSubject.SelectedValue == null) throw new Exception("Vui lòng chọn môn học.");

            int classId = Convert.ToInt32(cboClass.SelectedValue);
            int subjectId = Convert.ToInt32(cboSubject.SelectedValue);

            if (!int.TryParse(Convert.ToString(cboSemester.SelectedItem), out int semester) || (semester != 1 && semester != 2))
                throw new Exception("Kỳ không hợp lệ (chỉ 1 hoặc 2).");

            var schoolYear = (txtYear.Text ?? "").Trim();
            if (string.IsNullOrWhiteSpace(schoolYear))
                throw new Exception("Vui lòng nhập năm học (vd: 2024-2025).");

            return (classId, subjectId, semester, schoolYear);
        }

        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadGridAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task LoadGridAsync()
        {
            var (classId, subjectId, semester, schoolYear) = ReadFilter();
            var data = await _scoreService.GetEntriesAsync(classId, subjectId, semester, schoolYear);
            
            var sortedData = data.OrderBy(s => s.StudentName).ToList();
            _bindingList = new BindingList<ScoreEntryDTO>(sortedData);
            
            dgvScores.DataSource = _bindingList;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        // 4. Lưu batch (chỉ dòng đã sửa)
        private async Task SaveAsync()
        {
            try
            {
                if (_bindingList == null || _bindingList.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu để lưu. Vui lòng bấm 'Tải danh sách' trước.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_dirtyRows.Count == 0)
                {
                    MessageBox.Show("Không có thay đổi nào để lưu.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var changedItems = _dirtyRows.Select(i => _bindingList[i]).ToList();

                foreach (var item in changedItems)
                {
                    ValidateScore(item.Score15, "Điểm 15'");
                    ValidateScore(item.Score45, "Điểm 45'");
                    ValidateScore(item.ScoreFinal, "Điểm CK");
                }

                var result = DialogResult.Yes;
                if (_dirtyRows.Count > 5)
                {
                    result = MessageBox.Show(
                        $"Bạn đang lưu điểm cho {_dirtyRows.Count} học sinh.\n\nXác nhận lưu?",
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                }

                if (result != DialogResult.Yes) return;

                int affected = await _scoreService.SaveBatchAsync(changedItems);
                
                _dirtyRows.Clear();
                
                foreach (DataGridViewRow row in dgvScores.Rows)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                }

                MessageBox.Show(
                    $"Lưu điểm thành công!\n\n" +
                    $"Số học sinh đã cập nhật: {changedItems.Count}\n" +
                    $"Số bản ghi đã lưu: {affected}",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ValidateScore(float? value, string fieldName)
        {
            if (value == null) return;
            if (value < 0 || value > 10)
                throw new Exception($"{fieldName} phải trong khoảng 0 - 10 (hoặc để trống).");
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            ComputeAverageAndRankForAllStudents();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            var hasChanges = _dirtyRows.Count > 0;
            
            if (hasChanges)
            {
                var result = MessageBox.Show(
                    "Có thay đổi chưa lưu. Bạn có chắc muốn xóa?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                
                if (result != DialogResult.Yes) return;
            }

            ClearForm();
        }

        private void ClearForm()
        {
            dgvScores.DataSource = null;
            _bindingList = new BindingList<ScoreEntryDTO>();
            _dirtyRows.Clear();
            cboClass.SelectedIndex = -1;
            cboSubject.SelectedIndex = -1;
            cboSemester.SelectedIndex = 0;
            txtYear.Text = "2024-2025";
        }

        private void dgvScores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
