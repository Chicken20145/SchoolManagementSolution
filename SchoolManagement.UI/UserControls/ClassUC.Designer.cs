namespace SchoolManagement.UI
{
    partial class ClassUC
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
            grpClassInfo = new GroupBox();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            cboGVCN = new ComboBox();
            lblGVCN = new Label();
            cboGrade = new ComboBox();
            lblGrade = new Label();
            txtClassName = new TextBox();
            lblClassName = new Label();
            txtClassId = new TextBox();
            lblClassId = new Label();
            dgvClasses = new DataGridView();
            colClassId = new DataGridViewTextBoxColumn();
            colClassName = new DataGridViewTextBoxColumn();
            colGrade = new DataGridViewTextBoxColumn();
            colGVCN = new DataGridViewTextBoxColumn();
            grpClassInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
            SuspendLayout();
            // 
            // grpClassInfo
            // 
            grpClassInfo.Controls.Add(btnClear);
            grpClassInfo.Controls.Add(btnDelete);
            grpClassInfo.Controls.Add(btnEdit);
            grpClassInfo.Controls.Add(btnAdd);
            grpClassInfo.Controls.Add(cboGVCN);
            grpClassInfo.Controls.Add(lblGVCN);
            grpClassInfo.Controls.Add(cboGrade);
            grpClassInfo.Controls.Add(lblGrade);
            grpClassInfo.Controls.Add(txtClassName);
            grpClassInfo.Controls.Add(lblClassName);
            grpClassInfo.Controls.Add(txtClassId);
            grpClassInfo.Controls.Add(lblClassId);
            grpClassInfo.Dock = DockStyle.Top;
            grpClassInfo.Location = new Point(0, 0);
            grpClassInfo.Margin = new Padding(3, 4, 3, 4);
            grpClassInfo.Name = "grpClassInfo";
            grpClassInfo.Padding = new Padding(11, 13, 11, 13);
            grpClassInfo.Size = new Size(907, 227);
            grpClassInfo.TabIndex = 0;
            grpClassInfo.TabStop = false;
            grpClassInfo.Text = "Quản lý lớp học";
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
            btnClear.TabIndex = 11;
            btnClear.Text = "Làm Mới";
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
            btnDelete.TabIndex = 10;
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
            btnEdit.TabIndex = 9;
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
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // cboGVCN
            // 
            cboGVCN.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGVCN.FormattingEnabled = true;
            cboGVCN.Location = new Point(206, 131);
            cboGVCN.Margin = new Padding(3, 4, 3, 4);
            cboGVCN.Name = "cboGVCN";
            cboGVCN.Size = new Size(171, 28);
            cboGVCN.TabIndex = 7;
            // 
            // lblGVCN
            // 
            lblGVCN.AutoSize = true;
            lblGVCN.Location = new Point(206, 107);
            lblGVCN.Name = "lblGVCN";
            lblGVCN.Size = new Size(51, 20);
            lblGVCN.TabIndex = 6;
            lblGVCN.Text = "GVCN:";
            // 
            // cboGrade
            // 
            cboGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGrade.FormattingEnabled = true;
            cboGrade.Items.AddRange(new object[] { "10", "11", "12" });
            cboGrade.Location = new Point(206, 64);
            cboGrade.Margin = new Padding(3, 4, 3, 4);
            cboGrade.Name = "cboGrade";
            cboGrade.Size = new Size(171, 28);
            cboGrade.TabIndex = 5;
            cboGrade.SelectedIndexChanged += cboGrade_SelectedIndexChanged;
            // 
            // lblGrade
            // 
            lblGrade.AutoSize = true;
            lblGrade.Location = new Point(206, 40);
            lblGrade.Name = "lblGrade";
            lblGrade.Size = new Size(42, 20);
            lblGrade.TabIndex = 4;
            lblGrade.Text = "Khối:";
            // 
            // txtClassName
            // 
            txtClassName.Location = new Point(15, 131);
            txtClassName.Margin = new Padding(3, 4, 3, 4);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(171, 27);
            txtClassName.TabIndex = 3;
            // 
            // lblClassName
            // 
            lblClassName.AutoSize = true;
            lblClassName.Location = new Point(15, 107);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(61, 20);
            lblClassName.TabIndex = 2;
            lblClassName.Text = "Tên lớp:";
            // 
            // txtClassId
            // 
            txtClassId.Location = new Point(15, 64);
            txtClassId.Margin = new Padding(3, 4, 3, 4);
            txtClassId.Name = "txtClassId";
            txtClassId.ReadOnly = true;
            txtClassId.Size = new Size(171, 27);
            txtClassId.TabIndex = 1;
            txtClassId.TextChanged += txtClassId_TextChanged;
            // 
            // lblClassId
            // 
            lblClassId.AutoSize = true;
            lblClassId.Location = new Point(15, 40);
            lblClassId.Name = "lblClassId";
            lblClassId.Size = new Size(59, 20);
            lblClassId.TabIndex = 0;
            lblClassId.Text = "Mã lớp:";
            // 
            // dgvClasses
            // 
            dgvClasses.AllowUserToAddRows = false;
            dgvClasses.AllowUserToDeleteRows = false;
            dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClasses.BackgroundColor = Color.White;
            dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClasses.Columns.AddRange(new DataGridViewColumn[] { colClassId, colClassName, colGrade, colGVCN });
            dgvClasses.Dock = DockStyle.Fill;
            dgvClasses.Location = new Point(0, 227);
            dgvClasses.Margin = new Padding(3, 4, 3, 4);
            dgvClasses.MultiSelect = false;
            dgvClasses.Name = "dgvClasses";
            dgvClasses.ReadOnly = true;
            dgvClasses.RowHeadersVisible = false;
            dgvClasses.RowHeadersWidth = 51;
            dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClasses.Size = new Size(907, 480);
            dgvClasses.TabIndex = 1;
            // 
            // colClassId
            // 
            colClassId.DataPropertyName = "ClassId";
            colClassId.HeaderText = "Mã lớp";
            colClassId.MinimumWidth = 6;
            colClassId.Name = "colClassId";
            colClassId.ReadOnly = true;
            // 
            // colClassName
            // 
            colClassName.DataPropertyName = "ClassName";
            colClassName.HeaderText = "Tên lớp";
            colClassName.MinimumWidth = 6;
            colClassName.Name = "colClassName";
            colClassName.ReadOnly = true;
            // 
            // colGrade
            // 
            colGrade.DataPropertyName = "Grade";
            colGrade.HeaderText = "Khối";
            colGrade.MinimumWidth = 6;
            colGrade.Name = "colGrade";
            colGrade.ReadOnly = true;
            // 
            // colGVCN
            // 
            colGVCN.DataPropertyName = "HomeroomTeacherName";
            colGVCN.HeaderText = "GVCN";
            colGVCN.MinimumWidth = 6;
            colGVCN.Name = "colGVCN";
            colGVCN.ReadOnly = true;
            // 
            // ClassUC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvClasses);
            Controls.Add(grpClassInfo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ClassUC";
            Size = new Size(907, 707);
            Load += ClassUC_Load;
            grpClassInfo.ResumeLayout(false);
            grpClassInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
            ResumeLayout(false);
        }

        private GroupBox grpClassInfo;
        private Label lblClassId;
        private TextBox txtClassId;
        private Label lblClassName;
        private TextBox txtClassName;
        private Label lblGrade;
        private ComboBox cboGrade;
        private Label lblGVCN;
        private ComboBox cboGVCN;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvClasses;
        private DataGridViewTextBoxColumn colClassId;
        private DataGridViewTextBoxColumn colClassName;
        private DataGridViewTextBoxColumn colGrade;
        private DataGridViewTextBoxColumn colGVCN;
    }
}
