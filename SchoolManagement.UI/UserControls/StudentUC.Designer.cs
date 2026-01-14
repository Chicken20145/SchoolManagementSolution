namespace SchoolManagement.UI
{
    partial class StudentUC
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
            grpStudentInfo = new GroupBox();
            chkStatus = new CheckBox();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtGrade = new TextBox();
            lblGrade = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cboClass = new ComboBox();
            lblClass = new Label();
            cboGender = new ComboBox();
            lblGender = new Label();
            dtpDOB = new DateTimePicker();
            lblDOB = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtStudentId = new TextBox();
            lblStudentId = new Label();
            dgvStudents = new DataGridView();
            colStudentId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colDOB = new DataGridViewTextBoxColumn();
            colGender = new DataGridViewTextBoxColumn();
            colClassName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            grpStudentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // grpStudentInfo
            // 
            grpStudentInfo.Controls.Add(chkStatus);
            grpStudentInfo.Controls.Add(txtAddress);
            grpStudentInfo.Controls.Add(lblAddress);
            grpStudentInfo.Controls.Add(txtPhone);
            grpStudentInfo.Controls.Add(lblPhone);
            grpStudentInfo.Controls.Add(txtGrade);
            grpStudentInfo.Controls.Add(lblGrade);
            grpStudentInfo.Controls.Add(btnClear);
            grpStudentInfo.Controls.Add(btnDelete);
            grpStudentInfo.Controls.Add(btnEdit);
            grpStudentInfo.Controls.Add(btnAdd);
            grpStudentInfo.Controls.Add(cboClass);
            grpStudentInfo.Controls.Add(lblClass);
            grpStudentInfo.Controls.Add(cboGender);
            grpStudentInfo.Controls.Add(lblGender);
            grpStudentInfo.Controls.Add(dtpDOB);
            grpStudentInfo.Controls.Add(lblDOB);
            grpStudentInfo.Controls.Add(txtFullName);
            grpStudentInfo.Controls.Add(lblFullName);
            grpStudentInfo.Controls.Add(txtStudentId);
            grpStudentInfo.Controls.Add(lblStudentId);
            grpStudentInfo.Dock = DockStyle.Top;
            grpStudentInfo.Location = new Point(0, 0);
            grpStudentInfo.Margin = new Padding(3, 4, 3, 4);
            grpStudentInfo.Name = "grpStudentInfo";
            grpStudentInfo.Padding = new Padding(11, 13, 11, 13);
            grpStudentInfo.Size = new Size(907, 320);
            grpStudentInfo.TabIndex = 0;
            grpStudentInfo.TabStop = false;
            grpStudentInfo.Text = "Thông tin học sinh";
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.Checked = true;
            chkStatus.CheckState = CheckState.Checked;
            chkStatus.Location = new Point(15, 283);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(95, 24);
            chkStatus.TabIndex = 20;
            chkStatus.Text = "Đang học";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(15, 225);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(362, 47);
            txtAddress.TabIndex = 19;

            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(15, 201);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(58, 20);
            lblAddress.TabIndex = 18;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(206, 171);
            txtPhone.Margin = new Padding(3, 4, 3, 4);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(171, 27);
            txtPhone.TabIndex = 17;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(15, 170);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(100, 20);
            lblPhone.TabIndex = 16;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtGrade
            // 
            txtGrade.BackColor = Color.WhiteSmoke;
            txtGrade.Location = new Point(503, 64);
            txtGrade.Margin = new Padding(3, 4, 3, 4);
            txtGrade.Name = "txtGrade";
            txtGrade.ReadOnly = true;
            txtGrade.Size = new Size(70, 27);
            txtGrade.TabIndex = 15;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(503, 40);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(42, 20);
            lblGrade.TabIndex = 14;
            lblGrade.Text = "Khối:";
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
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.FormattingEnabled = true;
            cboClass.Location = new Point(397, 64);
            cboClass.Margin = new Padding(3, 4, 3, 4);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(86, 28);
            cboClass.TabIndex = 9;
            cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(397, 40);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(37, 20);
            lblClass.TabIndex = 8;
            lblClass.Text = "Lớp:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.Location = new Point(206, 131);
            cboGender.Margin = new Padding(3, 4, 3, 4);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(171, 28);
            cboGender.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(206, 107);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(68, 20);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // dtpDOB
            // 
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(206, 64);
            dtpDOB.Margin = new Padding(3, 4, 3, 4);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(171, 27);
            dtpDOB.TabIndex = 5;
            // 
            // lblDOB
            // 
            lblDOB.AutoSize = true;
            lblDOB.Location = new Point(206, 40);
            lblDOB.Name = "lblDOB";
            lblDOB.Size = new Size(77, 20);
            lblDOB.TabIndex = 4;
            lblDOB.Text = "Ngày sinh:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(15, 131);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(171, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 107);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtStudentId
            // 
            txtStudentId.BackColor = Color.WhiteSmoke;
            txtStudentId.Location = new Point(15, 64);
            txtStudentId.Margin = new Padding(3, 4, 3, 4);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.ReadOnly = true;
            txtStudentId.Size = new Size(171, 27);
            txtStudentId.TabIndex = 1;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(15, 40);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(91, 20);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "Mã học sinh:";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colStudentId, colFullName, colDOB, colGender, colClassName, colPhone, colAddress, colGrade });
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.Location = new Point(0, 320);
            dgvStudents.Margin = new Padding(3, 4, 3, 4);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(907, 387);
            dgvStudents.TabIndex = 1;
            // 
            // colStudentId
            // 
            colStudentId.DataPropertyName = "StudentId";
            colStudentId.FillWeight = 60F;
            colStudentId.HeaderText = "Mã HS";
            colStudentId.MinimumWidth = 6;
            colStudentId.Name = "colStudentId";
            colStudentId.ReadOnly = true;
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
            // colDOB
            // 
            colDOB.DataPropertyName = "Dob";
            colDOB.FillWeight = 80F;
            colDOB.HeaderText = "Ngày sinh";
            colDOB.MinimumWidth = 6;
            colDOB.Name = "colDOB";
            colDOB.ReadOnly = true;
            // 
            // colGender
            // 
            colGender.DataPropertyName = "Gender";
            colGender.FillWeight = 70F;
            colGender.HeaderText = "Giới tính";
            colGender.MinimumWidth = 6;
            colGender.Name = "colGender";
            colGender.ReadOnly = true;
            // 
            // colClassName
            // 
            colClassName.DataPropertyName = "ClassName";
            colClassName.FillWeight = 60F;
            colClassName.HeaderText = "Lớp";
            colClassName.MinimumWidth = 6;
            colClassName.Name = "colClassName";
            colClassName.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.DataPropertyName = "Phone";
            colPhone.FillWeight = 90F;
            colPhone.HeaderText = "SĐT";
            colPhone.MinimumWidth = 6;
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            colAddress.FillWeight = 150F;
            colAddress.HeaderText = "Địa chỉ";
            colAddress.MinimumWidth = 6;
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.DataPropertyName = "Grade";
            colGrade.FillWeight = 50F;
            colGrade.HeaderText = "Khối";
            colGrade.MinimumWidth = 6;
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // StudentUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvStudents);
            Controls.Add(grpStudentInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StudentUC";
            Size = new Size(907, 707);
            Load += StudentUC_Load;
            grpStudentInfo.ResumeLayout(false);
            grpStudentInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpStudentInfo;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private Label lblGender;
        private ComboBox cboGender;
        private Label lblClass;
        private ComboBox cboClass;
        private Label lblGrade;
        private TextBox txtGrade;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private CheckBox chkStatus;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvStudents;
        private DataGridViewTextBoxColumn colStudentId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colDOB;
        private DataGridViewTextBoxColumn colGender;
        private DataGridViewTextBoxColumn colClassName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colGrade;
    }
}
