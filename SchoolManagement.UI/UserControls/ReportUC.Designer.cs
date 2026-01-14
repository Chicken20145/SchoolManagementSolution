namespace SchoolManagement.UI
{
    partial class ReportUC
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpFilterReport = new GroupBox();
            cboSubject = new ComboBox();
            lblSubject = new Label();
            btnRefresh = new Button();
            btnExport = new Button();
            cboYear = new ComboBox();
            lblYear = new Label();
            cboSemester = new ComboBox();
            lblSemester = new Label();
            cboClass = new ComboBox();
            lblClass = new Label();
            dgvReport = new DataGridView();
            colStudentId = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colAverageScore = new DataGridViewTextBoxColumn();
            colRank = new DataGridViewTextBoxColumn();
            lblSummary = new Label();
            grpFilterReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // grpFilterReport
            // 
            grpFilterReport.Controls.Add(cboSubject);
            grpFilterReport.Controls.Add(lblSubject);
            grpFilterReport.Controls.Add(btnRefresh);
            grpFilterReport.Controls.Add(btnExport);
            grpFilterReport.Controls.Add(cboYear);
            grpFilterReport.Controls.Add(lblYear);
            grpFilterReport.Controls.Add(cboSemester);
            grpFilterReport.Controls.Add(lblSemester);
            grpFilterReport.Controls.Add(cboClass);
            grpFilterReport.Controls.Add(lblClass);
            grpFilterReport.Dock = DockStyle.Top;
            grpFilterReport.Location = new Point(0, 0);
            grpFilterReport.Margin = new Padding(3, 4, 3, 4);
            grpFilterReport.Name = "grpFilterReport";
            grpFilterReport.Padding = new Padding(11, 13, 11, 13);
            grpFilterReport.Size = new Size(907, 160);
            grpFilterReport.TabIndex = 0;
            grpFilterReport.TabStop = false;
            grpFilterReport.Text = "Bộ lọc thống kê";
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(15, 116);
            cboSubject.Margin = new Padding(3, 4, 3, 4);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(171, 28);
            cboSubject.TabIndex = 9;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(15, 92);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(68, 20);
            lblSubject.TabIndex = 8;
            lblSubject.Text = "Môn học:";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Blue;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(674, 64);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(86, 40);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Green;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(582, 64);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(86, 40);
            btnExport.TabIndex = 6;
            btnExport.Text = "Xuất file";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += BtnExport_Click;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Items.AddRange(new object[] { "2023-2024", "2024-2025", "2025-2026" });
            cboYear.Location = new Point(397, 64);
            cboYear.Margin = new Padding(3, 4, 3, 4);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(171, 28);
            cboYear.TabIndex = 5;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(397, 40);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(72, 20);
            lblYear.TabIndex = 4;
            lblYear.Text = "Năm học:";
            // 
            // cboSemester
            // 
            cboSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSemester.FormattingEnabled = true;
            cboSemester.Items.AddRange(new object[] { "1", "2" });
            cboSemester.Location = new Point(206, 64);
            cboSemester.Margin = new Padding(3, 4, 3, 4);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(171, 28);
            cboSemester.TabIndex = 3;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(206, 40);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(57, 20);
            lblSemester.TabIndex = 2;
            lblSemester.Text = "Học kỳ:";
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(15, 64);
            cboClass.Margin = new Padding(3, 4, 3, 4);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(171, 28);
            cboClass.TabIndex = 1;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(15, 40);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(37, 20);
            lblClass.TabIndex = 0;
            lblClass.Text = "Lớp:";
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AllowUserToDeleteRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Columns.AddRange(new DataGridViewColumn[] { colStudentId, colStudentName, colAverageScore, colRank });
            dgvReport.Dock = DockStyle.Fill;
            dgvReport.Location = new Point(0, 160);
            dgvReport.Margin = new Padding(3, 4, 3, 4);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersVisible = false;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(907, 507);
            dgvReport.TabIndex = 1;
            // 
            // colStudentId
            // 
            colStudentId.DataPropertyName = "StudentId";
            colStudentId.HeaderText = "Mã học sinh";
            colStudentId.MinimumWidth = 6;
            colStudentId.Name = "colStudentId";
            colStudentId.ReadOnly = true;
            // 
            // colStudentName
            // 
            colStudentName.DataPropertyName = "StudentName";
            colStudentName.HeaderText = "Họ và tên";
            colStudentName.MinimumWidth = 6;
            colStudentName.Name = "colStudentName";
            colStudentName.ReadOnly = true;
            // 
            // colAverageScore
            // 
            colAverageScore.DataPropertyName = "AverageScore";
            colAverageScore.HeaderText = "Điểm trung bình";
            colAverageScore.MinimumWidth = 6;
            colAverageScore.Name = "colAverageScore";
            colAverageScore.ReadOnly = true;
            // 
            // colRank
            // 
            colRank.DataPropertyName = "Rank";
            colRank.HeaderText = "Xếp loại";
            colRank.MinimumWidth = 6;
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
            // 
            // lblSummary
            // 
            lblSummary.Dock = DockStyle.Bottom;
            lblSummary.Location = new Point(0, 667);
            lblSummary.Name = "lblSummary";
            lblSummary.Padding = new Padding(11, 10, 11, 10);
            lblSummary.Size = new Size(907, 40);
            lblSummary.TabIndex = 2;
            lblSummary.Text = "Chưa có dữ liệu tổng hợp.";
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ReportUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvReport);
            Controls.Add(lblSummary);
            Controls.Add(grpFilterReport);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportUC";
            Size = new Size(907, 707);
            Load += ReportUC_Load;
            grpFilterReport.ResumeLayout(false);
            grpFilterReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpFilterReport;
        private Label lblClass;
        private ComboBox cboClass;
        private Label lblSemester;
        private ComboBox cboSemester;
        private Label lblYear;
        private ComboBox cboYear;
        private Button btnExport;
        private Button btnRefresh;
        private DataGridView dgvReport;
        private DataGridViewTextBoxColumn colStudentId;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colAverageScore;
        private DataGridViewTextBoxColumn colRank;
        private ComboBox cboSubject;
        private Label lblSubject;
        private Label lblSummary;
    }
}
