namespace SchoolManagement.UI
{
    partial class SubjectUC
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
            grpSubjectInfo = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtCredit = new TextBox();
            lblCredit = new Label();
            txtSubjectName = new TextBox();
            lblSubjectName = new Label();
            txtSubjectId = new TextBox();
            lblSubjectId = new Label();
            dgvSubjects = new DataGridView();
            colSubjectId = new DataGridViewTextBoxColumn();
            colSubjectName = new DataGridViewTextBoxColumn();
            colCredit = new DataGridViewTextBoxColumn();
            grpSubjectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).BeginInit();
            SuspendLayout();
            // 
            // grpSubjectInfo
            // 
            grpSubjectInfo.Controls.Add(btnClear);
            grpSubjectInfo.Controls.Add(btnDelete);
            grpSubjectInfo.Controls.Add(btnEdit);
            grpSubjectInfo.Controls.Add(btnAdd);
            grpSubjectInfo.Controls.Add(txtCredit);
            grpSubjectInfo.Controls.Add(lblCredit);
            grpSubjectInfo.Controls.Add(txtSubjectName);
            grpSubjectInfo.Controls.Add(lblSubjectName);
            grpSubjectInfo.Controls.Add(txtSubjectId);
            grpSubjectInfo.Controls.Add(lblSubjectId);
            grpSubjectInfo.Dock = DockStyle.Top;
            grpSubjectInfo.Location = new Point(0, 0);
            grpSubjectInfo.Margin = new Padding(3, 4, 3, 4);
            grpSubjectInfo.Name = "grpSubjectInfo";
            grpSubjectInfo.Padding = new Padding(11, 13, 11, 13);
            grpSubjectInfo.Size = new Size(907, 227);
            grpSubjectInfo.TabIndex = 0;
            grpSubjectInfo.TabStop = false;
            grpSubjectInfo.Text = "Quản lý môn học";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Gray;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(674, 64);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(86, 47);
            btnClear.TabIndex = 9;
            btnClear.Text = "Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(582, 64);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 47);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Orange;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(489, 64);
            btnEdit.Margin = new Padding(3, 4, 3, 4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(86, 47);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Green;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(397, 64);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(86, 47);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // txtCredit
            // 
            txtCredit.Location = new Point(206, 64);
            txtCredit.Margin = new Padding(3, 4, 3, 4);
            txtCredit.Name = "txtCredit";
            txtCredit.Size = new Size(171, 27);
            txtCredit.TabIndex = 5;
            // 
            // lblCredit
            // 
            lblCredit.AutoSize = true;
            lblCredit.Location = new Point(206, 40);
            lblCredit.Name = "lblCredit";
            lblCredit.Size = new Size(55, 20);
            lblCredit.TabIndex = 4;
            lblCredit.Text = "Tín chỉ:";
            // 
            // txtSubjectName
            // 
            txtSubjectName.Location = new Point(15, 131);
            txtSubjectName.Margin = new Padding(3, 4, 3, 4);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(171, 27);
            txtSubjectName.TabIndex = 3;
            // 
            // lblSubjectName
            // 
            lblSubjectName.AutoSize = true;
            lblSubjectName.Location = new Point(15, 107);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(69, 20);
            lblSubjectName.TabIndex = 2;
            lblSubjectName.Text = "Tên môn:";
            // 
            // txtSubjectId
            // 
            txtSubjectId.Location = new Point(15, 64);
            txtSubjectId.Margin = new Padding(3, 4, 3, 4);
            txtSubjectId.Name = "txtSubjectId";
            txtSubjectId.ReadOnly = true;
            txtSubjectId.Size = new Size(171, 27);
            txtSubjectId.TabIndex = 1;
            // 
            // lblSubjectId
            // 
            lblSubjectId.AutoSize = true;
            lblSubjectId.Location = new Point(15, 40);
            lblSubjectId.Name = "lblSubjectId";
            lblSubjectId.Size = new Size(67, 20);
            lblSubjectId.TabIndex = 0;
            lblSubjectId.Text = "Mã môn:";
            // 
            // dgvSubjects
            // 
            dgvSubjects.AllowUserToAddRows = false;
            dgvSubjects.AllowUserToDeleteRows = false;
            dgvSubjects.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubjects.BackgroundColor = Color.White;
            dgvSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubjects.Columns.AddRange(new DataGridViewColumn[] { colSubjectId, colSubjectName, colCredit });
            dgvSubjects.Dock = DockStyle.Fill;
            dgvSubjects.Location = new Point(0, 227);
            dgvSubjects.Margin = new Padding(3, 4, 3, 4);
            dgvSubjects.MultiSelect = false;
            dgvSubjects.Name = "dgvSubjects";
            dgvSubjects.ReadOnly = true;
            dgvSubjects.RowHeadersVisible = false;
            dgvSubjects.RowHeadersWidth = 51;
            dgvSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubjects.Size = new Size(907, 480);
            dgvSubjects.TabIndex = 1;
            // 
            // colSubjectId
            // 
            colSubjectId.DataPropertyName = "SubjectId";
            colSubjectId.HeaderText = "Mã môn";
            colSubjectId.MinimumWidth = 6;
            colSubjectId.Name = "colSubjectId";
            colSubjectId.ReadOnly = true;
            // 
            // colSubjectName
            // 
            colSubjectName.DataPropertyName = "SubjectName";
            colSubjectName.HeaderText = "Tên môn";
            colSubjectName.MinimumWidth = 6;
            colSubjectName.Name = "colSubjectName";
            colSubjectName.ReadOnly = true;
            // 
            // colCredit
            // 
            colCredit.DataPropertyName = "Credit";
            colCredit.HeaderText = "Tín chỉ";
            colCredit.MinimumWidth = 6;
            colCredit.Name = "colCredit";
            colCredit.ReadOnly = true;
            // 
            // SubjectUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvSubjects);
            Controls.Add(grpSubjectInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SubjectUC";
            Size = new Size(907, 707);
            Load += SubjectUC_Load;
            grpSubjectInfo.ResumeLayout(false);
            grpSubjectInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSubjects).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpSubjectInfo;
        private Label lblSubjectId;
        private TextBox txtSubjectId;
        private Label lblSubjectName;
        private TextBox txtSubjectName;
        private Label lblCredit;
        private TextBox txtCredit;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvSubjects;
        private DataGridViewTextBoxColumn colSubjectId;
        private DataGridViewTextBoxColumn colSubjectName;
        private DataGridViewTextBoxColumn colCredit;
    }
}
