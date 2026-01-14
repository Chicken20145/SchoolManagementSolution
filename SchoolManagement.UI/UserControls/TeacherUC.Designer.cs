namespace SchoolManagement.UI
{
    partial class TeacherUC
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
            grpTeacherInfo = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cboSubject = new ComboBox();
            lblSubject = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtTeacherName = new TextBox();
            lblTeacherName = new Label();
            txtTeacherId = new TextBox();
            lblTeacherId = new Label();
            dgvTeachers = new DataGridView();
            colTeacherId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colSubjectName = new DataGridViewTextBoxColumn();
            grpTeacherInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).BeginInit();
            SuspendLayout();
            // 
            // grpTeacherInfo
            // 
            grpTeacherInfo.Controls.Add(btnClear);
            grpTeacherInfo.Controls.Add(btnDelete);
            grpTeacherInfo.Controls.Add(btnEdit);
            grpTeacherInfo.Controls.Add(btnAdd);
            grpTeacherInfo.Controls.Add(cboSubject);
            grpTeacherInfo.Controls.Add(lblSubject);
            grpTeacherInfo.Controls.Add(txtPhone);
            grpTeacherInfo.Controls.Add(lblPhone);
            grpTeacherInfo.Controls.Add(txtEmail);
            grpTeacherInfo.Controls.Add(lblEmail);
            grpTeacherInfo.Controls.Add(txtTeacherName);
            grpTeacherInfo.Controls.Add(lblTeacherName);
            grpTeacherInfo.Controls.Add(txtTeacherId);
            grpTeacherInfo.Controls.Add(lblTeacherId);
            grpTeacherInfo.Dock = DockStyle.Top;
            grpTeacherInfo.Location = new Point(0, 0);
            grpTeacherInfo.Margin = new Padding(3, 4, 3, 4);
            grpTeacherInfo.Name = "grpTeacherInfo";
            grpTeacherInfo.Padding = new Padding(11, 13, 11, 13);
            grpTeacherInfo.Size = new Size(907, 250);
            grpTeacherInfo.TabIndex = 0;
            grpTeacherInfo.TabStop = false;
            grpTeacherInfo.Text = "Thông tin giáo viên";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(779, 171);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 47);
            btnClear.TabIndex = 13;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(687, 171);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 47);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Orange;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(595, 171);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 47);
            btnEdit.TabIndex = 11;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(503, 171);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 47);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // cboSubject
            // 
            cboSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSubject.FormattingEnabled = true;
            cboSubject.Location = new Point(397, 131);
            cboSubject.Margin = new Padding(3, 4, 3, 4);
            cboSubject.Name = "cboSubject";
            cboSubject.Size = new Size(171, 28);
            cboSubject.TabIndex = 9;
            cboSubject.SelectedIndexChanged += cboSubject_SelectedIndexChanged;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(397, 107);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(70, 20);
            lblSubject.TabIndex = 8;
            lblSubject.Text = "Môn dạy:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(206, 64);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(171, 27);
            txtPhone.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(206, 40);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(206, 131);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(206, 107);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtTeacherName
            // 
            txtTeacherName.Location = new Point(15, 131);
            txtTeacherName.Margin = new Padding(3, 4, 3, 4);
            txtTeacherName.Name = "txtTeacherName";
            txtTeacherName.Size = new Size(171, 27);
            txtTeacherName.TabIndex = 3;
            // 
            // lblTeacherName
            // 
            lblTeacherName.AutoSize = true;
            lblTeacherName.Location = new Point(15, 107);
            lblTeacherName.Name = "lblTeacherName";
            lblTeacherName.Size = new Size(76, 20);
            lblTeacherName.TabIndex = 2;
            lblTeacherName.Text = "Họ và tên:";
            // 
            // txtTeacherId
            // 
            txtTeacherId.BackColor = Color.WhiteSmoke;
            txtTeacherId.Location = new Point(15, 64);
            txtTeacherId.Margin = new Padding(3, 4, 3, 4);
            txtTeacherId.Name = "txtTeacherId";
            txtTeacherId.ReadOnly = true;
            txtTeacherId.Size = new Size(171, 27);
            txtTeacherId.TabIndex = 1;
            // 
            // lblTeacherId
            // 
            lblTeacherId.AutoSize = true;
            lblTeacherId.Location = new Point(15, 40);
            lblTeacherId.Name = "lblTeacherId";
            lblTeacherId.Size = new Size(98, 20);
            lblTeacherId.TabIndex = 0;
            lblTeacherId.Text = "Mã giáo viên:";
            // 
            // dgvTeachers
            // 
            dgvTeachers.AllowUserToAddRows = false;
            dgvTeachers.AllowUserToDeleteRows = false;
            dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTeachers.BackgroundColor = Color.White;
            dgvTeachers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeachers.Columns.AddRange(new DataGridViewColumn[] { colTeacherId, colFullName, colEmail, colPhone, colSubjectName });
            dgvTeachers.Dock = DockStyle.Fill;
            dgvTeachers.Location = new Point(0, 250);
            dgvTeachers.Margin = new Padding(3, 4, 3, 4);
            dgvTeachers.MultiSelect = false;
            dgvTeachers.Name = "dgvTeachers";
            dgvTeachers.ReadOnly = true;
            dgvTeachers.RowHeadersVisible = false;
            dgvTeachers.RowHeadersWidth = 51;
            dgvTeachers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeachers.Size = new Size(907, 457);
            dgvTeachers.TabIndex = 1;
            // 
            // colTeacherId
            // 
            colTeacherId.DataPropertyName = "TeacherId";
            colTeacherId.FillWeight = 80F;
            colTeacherId.HeaderText = "Mã GV";
            colTeacherId.MinimumWidth = 6;
            colTeacherId.Name = "colTeacherId";
            colTeacherId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.DataPropertyName = "FullName";
            colFullName.FillWeight = 150F;
            colFullName.HeaderText = "Họ và tên";
            colFullName.MinimumWidth = 6;
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.DataPropertyName = "Email";
            colEmail.FillWeight = 120F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.HeaderText = "SĐT";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colSubjectName
            // 
            colSubjectName.DataPropertyName = "SubjectName";
            colSubjectName.FillWeight = 120F;
            colSubjectName.HeaderText = "Môn dạy";
            colSubjectName.MinimumWidth = 6;
            colSubjectName.Name = "colSubjectName";
            colSubjectName.ReadOnly = true;
            // 
            // TeacherUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvTeachers);
            Controls.Add(grpTeacherInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "TeacherUC";
            Size = new Size(907, 707);
            Load += TeacherUC_Load;
            grpTeacherInfo.ResumeLayout(false);
            grpTeacherInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeachers).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpTeacherInfo;
        private Label lblTeacherId;
        private TextBox txtTeacherId;
        private Label lblTeacherName;
        private TextBox txtTeacherName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblSubject;
        private ComboBox cboSubject;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvTeachers;
        private DataGridViewTextBoxColumn colTeacherId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colSubjectName;
    }
}
