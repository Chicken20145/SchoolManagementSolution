namespace SchoolManagement.UI
{
    partial class MainForm
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
            pnlMenu = new Panel();
            pnlLogout = new Panel();
            btnLogout = new Button();
            flpMenu = new FlowLayoutPanel();
            btnClass = new Button();
            btnSubject = new Button();
            btnScore = new Button();
            btnTeacher = new Button();
            btnReport = new Button();
            btnStudent = new Button();
            lblAppTitle = new Label();
            pnlHeader = new Panel();
            lblUser = new Label();
            pnlContent = new Panel();
            pnlMenu.SuspendLayout();
            pnlLogout.SuspendLayout();
            flpMenu.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.Gainsboro;
            pnlMenu.Controls.Add(pnlLogout);
            pnlMenu.Controls.Add(flpMenu);
            pnlMenu.Controls.Add(lblAppTitle);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 67);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(251, 715);
            pnlMenu.TabIndex = 0;
            // 
            // pnlLogout
            // 
            pnlLogout.BackColor = Color.Gainsboro;
            pnlLogout.Controls.Add(btnLogout);
            pnlLogout.Dock = DockStyle.Bottom;
            pnlLogout.Location = new Point(0, 635);
            pnlLogout.Margin = new Padding(3, 4, 3, 4);
            pnlLogout.Name = "pnlLogout";
            pnlLogout.Size = new Size(251, 80);
            pnlLogout.TabIndex = 3;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.LightCoral;
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 0);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(251, 80);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += BtnLogout_Click;
            // 
            // flpMenu
            // 
            flpMenu.AutoScroll = true;
            flpMenu.BackColor = Color.Gainsboro;
            flpMenu.Controls.Add(btnClass);
            flpMenu.Controls.Add(btnSubject);
            flpMenu.Controls.Add(btnScore);
            flpMenu.Controls.Add(btnTeacher);
            flpMenu.Controls.Add(btnReport);
            flpMenu.Controls.Add(btnStudent);
            flpMenu.Dock = DockStyle.Fill;
            flpMenu.FlowDirection = FlowDirection.TopDown;
            flpMenu.Location = new Point(0, 80);
            flpMenu.Margin = new Padding(3, 4, 3, 4);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(251, 635);
            flpMenu.TabIndex = 1;
            flpMenu.WrapContents = false;
            // 
            // btnClass
            // 
            btnClass.BackColor = Color.SteelBlue;
            btnClass.FlatStyle = FlatStyle.Flat;
            btnClass.Font = new Font("Segoe UI", 9F);
            btnClass.ForeColor = Color.White;
            btnClass.Location = new Point(11, 8);
            btnClass.Margin = new Padding(11, 8, 11, 0);
            btnClass.Name = "btnClass";
            btnClass.Size = new Size(229, 53);
            btnClass.TabIndex = 0;
            btnClass.Text = "Quản lý lớp học";
            btnClass.UseVisualStyleBackColor = false;
            btnClass.Click += BtnClass_Click;
            // 
            // btnSubject
            // 
            btnSubject.BackColor = Color.SteelBlue;
            btnSubject.FlatStyle = FlatStyle.Flat;
            btnSubject.Font = new Font("Segoe UI", 9F);
            btnSubject.ForeColor = Color.White;
            btnSubject.Location = new Point(11, 69);
            btnSubject.Margin = new Padding(11, 8, 11, 0);
            btnSubject.Name = "btnSubject";
            btnSubject.Size = new Size(229, 53);
            btnSubject.TabIndex = 1;
            btnSubject.Text = "Quản lý môn học";
            btnSubject.UseVisualStyleBackColor = false;
            btnSubject.Click += BtnSubject_Click;
            // 
            // btnScore
            // 
            btnScore.BackColor = Color.SteelBlue;
            btnScore.FlatStyle = FlatStyle.Flat;
            btnScore.Font = new Font("Segoe UI", 9F);
            btnScore.ForeColor = Color.White;
            btnScore.Location = new Point(11, 130);
            btnScore.Margin = new Padding(11, 8, 11, 0);
            btnScore.Name = "btnScore";
            btnScore.Size = new Size(229, 53);
            btnScore.TabIndex = 2;
            btnScore.Text = "Nhập điểm";
            btnScore.UseVisualStyleBackColor = false;
            btnScore.Click += BtnScore_Click;
            // 
            // btnTeacher
            // 
            btnTeacher.BackColor = Color.SteelBlue;
            btnTeacher.FlatStyle = FlatStyle.Flat;
            btnTeacher.Font = new Font("Segoe UI", 9F);
            btnTeacher.ForeColor = Color.White;
            btnTeacher.Location = new Point(11, 191);
            btnTeacher.Margin = new Padding(11, 8, 11, 0);
            btnTeacher.Name = "btnTeacher";
            btnTeacher.Size = new Size(229, 53);
            btnTeacher.TabIndex = 3;
            btnTeacher.Text = "Quản lý giáo viên";
            btnTeacher.UseVisualStyleBackColor = false;
            btnTeacher.Click += BtnTeacher_Click;
            // 
            // btnReport
            // 
            btnReport.BackColor = Color.SteelBlue;
            btnReport.FlatStyle = FlatStyle.Flat;
            btnReport.Font = new Font("Segoe UI", 9F);
            btnReport.ForeColor = Color.White;
            btnReport.Location = new Point(11, 252);
            btnReport.Margin = new Padding(11, 8, 11, 0);
            btnReport.Name = "btnReport";
            btnReport.Size = new Size(229, 53);
            btnReport.TabIndex = 4;
            btnReport.Text = "Thông kê học lực";
            btnReport.UseVisualStyleBackColor = false;
            btnReport.Click += BtnReport_Click;
            // 
            // btnStudent
            // 
            btnStudent.BackColor = Color.SteelBlue;
            btnStudent.FlatStyle = FlatStyle.Flat;
            btnStudent.Font = new Font("Segoe UI", 9F);
            btnStudent.ForeColor = Color.White;
            btnStudent.Location = new Point(11, 313);
            btnStudent.Margin = new Padding(11, 8, 11, 0);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(229, 53);
            btnStudent.TabIndex = 5;
            btnStudent.Text = "Quản lý học sinh";
            btnStudent.UseVisualStyleBackColor = false;
            btnStudent.Click += BtnStudent_Click;
            // 
            // lblAppTitle
            // 
            lblAppTitle.BackColor = Color.Gray;
            lblAppTitle.Dock = DockStyle.Top;
            lblAppTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(0, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(251, 80);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Hệ thống quản lý trường học";
            lblAppTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.WhiteSmoke;
            pnlHeader.Controls.Add(lblUser);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1159, 67);
            pnlHeader.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Right;
            lblUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUser.Location = new Point(930, 0);
            lblUser.Name = "lblUser";
            lblUser.Padding = new Padding(0, 0, 11, 0);
            lblUser.Size = new Size(229, 67);
            lblUser.TabIndex = 0;
            lblUser.Text = "Xin chào: ADMIN";
            lblUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.White;
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(251, 67);
            pnlContent.Margin = new Padding(3, 4, 3, 4);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(908, 715);
            pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 782);
            Controls.Add(pnlContent);
            Controls.Add(pnlMenu);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản ly trường học";
            Load += MainForm_Load;
            pnlMenu.ResumeLayout(false);
            pnlLogout.ResumeLayout(false);
            flpMenu.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel pnlMenu;
        private FlowLayoutPanel flpMenu;
        private Label lblAppTitle;
        private Panel pnlHeader;
        private Label lblUser;
        private Panel pnlContent;
        private Panel pnlLogout;
        private Button btnLogout;
        private Button btnClass;
        private Button btnSubject;
        private Button btnScore;
        private Button btnTeacher;
        private Button btnReport;
        private Button btnStudent;
    }
}
