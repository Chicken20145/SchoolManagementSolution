namespace SchoolManagement.UI
{
    partial class ScoreUC
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
            grpScoreFilter = new GroupBox();
            btnClear = new Button();
            btnCalc = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            txtYear = new TextBox();
            lblYear = new Label();
            cboSemester = new ComboBox();
            lblSemester = new Label();
            cboSubject = new ComboBox();
            lblSubject = new Label();
            cboClass = new ComboBox();
            lblClass = new Label();
            dgvScores = new DataGridView();
            colStudentId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colDiemMieng = new DataGridViewTextBoxColumn();
            colDiem15p = new DataGridViewTextBoxColumn();
            colDiem1Tiet = new DataGridViewTextBoxColumn();
            colDiemThi = new DataGridViewTextBoxColumn();
            colAvg = new DataGridViewTextBoxColumn();
            colRank = new DataGridViewTextBoxColumn();
            grpScoreFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScores).BeginInit();
            SuspendLayout();
            // 
            // grpScoreFilter
            // 
            grpScoreFilter.Controls.Add(btnClear);
            grpScoreFilter.Controls.Add(btnCalc);
            grpScoreFilter.Controls.Add(btnSave);
            grpScoreFilter.Controls.Add(btnLoad);
            grpScoreFilter.Controls.Add(txtYear);
            grpScoreFilter.Controls.Add(lblYear);
            grpScoreFilter.Controls.Add(cboSemester);
            grpScoreFilter.Controls.Add(lblSemester);
            grpScoreFilter.Controls.Add(cboSubject);
            grpScoreFilter.Controls.Add(lblSubject);
            grpScoreFilter.Controls.Add(cboClass);
            grpScoreFilter.Controls.Add(lblClass);
            grpScoreFilter.Dock = DockStyle.Top;
            grpScoreFilter.Location = new Point(0, 0);
            grpScoreFilter.Margin = new Padding(3, 4, 3, 4);
            grpScoreFilter.Name = "grpScoreFilter";
            grpScoreFilter.Padding = new Padding(11, 13, 11, 13);
            grpScoreFilter.Size = new Size(907, 187);
            grpScoreFilter.TabIndex = 0;
            grpScoreFilter.TabStop = false;
            grpScoreFilter.Text = "Nhập điểm";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(796, 36);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 47);
            btnClear.TabIndex = 11;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnCalc
            // 
            btnCalc.BackColor = Color.Orange;
            btnCalc.FlatStyle = FlatStyle.Flat;
            btnCalc.ForeColor = Color.White;
            btnCalc.Location = new Point(647, 36);
            btnCalc.Margin = new Padding(3, 4, 3, 4);
            btnCalc.Name = "btnCalc";
            btnCalc.Size = new Size(143, 47);
            btnCalc.TabIndex = 10;
            btnCalc.Text = "Tính TB + Xếp loại";
            btnCalc.UseVisualStyleBackColor = false;
            btnCalc.Click += BtnCalc_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Green;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(555, 36);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(86, 47);
            btnSave.TabIndex = 9;
            btnSave.Text = "Lưu điểm";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.BackColor = Color.SteelBlue;
            btnLoad.FlatStyle = FlatStyle.Flat;
            btnLoad.ForeColor = Color.White;
            btnLoad.Location = new Point(411, 36);
            btnLoad.Margin = new Padding(3, 4, 3, 4);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(138, 47);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Tải danh sách";
            btnLoad.UseVisualStyleBackColor = false;
            btnLoad.Click += BtnLoad_Click;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(280, 83);
            txtYear.Margin = new Padding(3, 4, 3, 4);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(105, 27);
            txtYear.TabIndex = 7;
            txtYear.Text = "2024-2025";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(206, 87);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(72, 20);
            lblYear.TabIndex = 6;
            lblYear.Text = "Năm học:";
            // 
            // cboSemester
            // 
            cboSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSemester.FormattingEnabled = true;
            cboSemester.Items.AddRange(new object[] { "HK1", "HK2" });
            cboSemester.Location = new Point(80, 83);
            cboSemester.Margin = new Padding(3, 4, 3, 4);
            cboSemester.Name = "cboSemester";
            cboSemester.Size = new Size(114, 28);
            cboSemester.TabIndex = 5;
            // 
            // lblSemester
            // 
            lblSemester.AutoSize = true;
            lblSemester.Location = new Point(15, 87);
            lblSemester.Name = "lblSemester";
            lblSemester.Size = new Size(57, 20);
            lblSemester.TabIndex = 4;
            lblSemester.Text = "Học kỳ:";
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(248, 36);
            cboSubject.Margin = new Padding(3, 4, 3, 4);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(137, 28);
            cboSubject.TabIndex = 3;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(206, 40);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(42, 20);
            lblSubject.TabIndex = 2;
            lblSubject.Text = "Môn:";
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(57, 36);
            cboClass.Margin = new Padding(3, 4, 3, 4);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(137, 28);
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
            // dgvScores
            // 
            dgvScores.AllowUserToAddRows = false;
            dgvScores.AllowUserToDeleteRows = false;
            dgvScores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvScores.BackgroundColor = Color.White;
            dgvScores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScores.Columns.AddRange(new DataGridViewColumn[] { colStudentId, colFullName, colDiemMieng, colDiem15p, colDiem1Tiet, colDiemThi, colAvg, colRank });
            dgvScores.Dock = DockStyle.Fill;
            dgvScores.Location = new Point(0, 187);
            dgvScores.Margin = new Padding(3, 4, 3, 4);
            dgvScores.MultiSelect = false;
            dgvScores.Name = "dgvScores";
            dgvScores.RowHeadersVisible = false;
            dgvScores.RowHeadersWidth = 51;
            dgvScores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvScores.Size = new Size(907, 520);
            dgvScores.TabIndex = 1;
            dgvScores.CellContentClick += dgvScores_CellContentClick;
            // 
            // colStudentId
            // 
            colStudentId.DataPropertyName = "StudentId";
            colStudentId.HeaderText = "Mã HS";
            colStudentId.MinimumWidth = 6;
            colStudentId.Name = "colStudentId";
            colStudentId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.HeaderText = "Họ tên";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colDiemMieng
            // 
            colDiemMieng.DataPropertyName = "DiemMieng";
            colDiemMieng.HeaderText = "Điểm miệng";
            colDiemMieng.MinimumWidth = 6;
            colDiemMieng.Name = "colDiemMieng";
            // 
            // colDiem15p
            // 
            colDiem15p.DataPropertyName = "Diem15p";
            colDiem15p.HeaderText = "15 phút";
            colDiem15p.MinimumWidth = 6;
            colDiem15p.Name = "colDiem15p";
            // 
            // colDiem1Tiet
            // 
            colDiem1Tiet.DataPropertyName = "Diem1Tiet";
            colDiem1Tiet.HeaderText = "1 tiết";
            colDiem1Tiet.MinimumWidth = 6;
            colDiem1Tiet.Name = "colDiem1Tiet";
            // 
            // colDiemThi
            // 
            colDiemThi.DataPropertyName = "DiemThi";
            colDiemThi.HeaderText = "Cuối kì";
            colDiemThi.MinimumWidth = 6;
            colDiemThi.Name = "colDiemThi";
            // 
            // colAvg
            // 
            colAvg.DataPropertyName = "AverageScore";
            colAvg.HeaderText = "TB";
            colAvg.MinimumWidth = 6;
            colAvg.Name = "colAvg";
            colAvg.ReadOnly = true;
            // 
            // colRank
            // 
            colRank.DataPropertyName = "Rank";
            colRank.HeaderText = "Xếp loại";
            colRank.MinimumWidth = 6;
            colRank.Name = "colRank";
            colRank.ReadOnly = true;
            // 
            // ScoreUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvScores);
            Controls.Add(grpScoreFilter);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ScoreUC";
            Size = new Size(907, 707);
            Load += ScoreUC_Load;
            grpScoreFilter.ResumeLayout(false);
            grpScoreFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScores).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpScoreFilter;
        private Label lblClass;
        private ComboBox cboClass;
        private Label lblSubject;
        private ComboBox cboSubject;
        private Label lblSemester;
        private ComboBox cboSemester;
        private Label lblYear;
        private TextBox txtYear;
        private Button btnLoad;
        private Button btnSave;
        private Button btnCalc;
        private Button btnClear;
        private DataGridView dgvScores;
        private DataGridViewTextBoxColumn colStudentId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colDiemMieng;
        private DataGridViewTextBoxColumn colDiem15p;
        private DataGridViewTextBoxColumn colDiem1Tiet;
        private DataGridViewTextBoxColumn colDiemThi;
        private DataGridViewTextBoxColumn colAvg;
        private DataGridViewTextBoxColumn colRank;
    }
}
