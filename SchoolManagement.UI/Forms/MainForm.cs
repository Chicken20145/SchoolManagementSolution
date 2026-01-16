// SchoolManagement.UI\Forms\MainForm.cs
using System;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;

namespace SchoolManagement.UI
{
    public partial class MainForm : Form
    {
        private readonly SessionService _sessionService;
        private bool _isLoggingOut = false;

        public MainForm(SessionService sessionService)
        {
            InitializeComponent();
            _sessionService = sessionService;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!_sessionService.IsLoggedIn)
            {
                MessageBox.Show("Chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblUser.Text = $"Xin chào: {_sessionService.CurrentUser!.Username.ToUpper()} ({_sessionService.CurrentUser.Role})";

            ApplyRolePermissions();

            LoadUserControl(new StudentUC());
        }

        private void ApplyRolePermissions()
        {
            if (_sessionService.IsAdmin)
            {
                btnClass.Enabled = true;
                btnSubject.Enabled = true;
                btnScore.Enabled = true;
                btnTeacher.Enabled = true;
                btnReport.Enabled = true;
                btnStudent.Enabled = true;
                return;
            }

            if (_sessionService.IsTeacher)
            {
                btnScore.Enabled = true;
                btnReport.Enabled = true;
                btnStudent.Enabled = true;

                btnClass.Enabled = false;
                btnClass.BackColor = System.Drawing.Color.Gray;
                
                btnSubject.Enabled = false;
                btnSubject.BackColor = System.Drawing.Color.Gray;
                
                btnTeacher.Enabled = false;
                btnTeacher.BackColor = System.Drawing.Color.Gray;
            }
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // If logging out, don't show confirmation dialog
            if (_isLoggingOut)
            {
                _sessionService.Logout();
                return;
            }

            // Only show confirmation when user closes form directly (X button, Alt+F4)
            var result = MessageBox.Show(
                "Bạn có muốn thoát ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                _sessionService.Logout();
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
        }

        private void BtnStudent_Click(object sender, EventArgs e)
        {
            LoadUserControl(new StudentUC());
        }

        private void BtnTeacher_Click(object sender, EventArgs e)
        {
            if (!btnTeacher.Enabled)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadUserControl(new TeacherUC());
        }

        private void BtnClass_Click(object sender, EventArgs e)
        {
            if (!btnClass.Enabled)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadUserControl(new ClassUC());
        }

        private void BtnSubject_Click(object sender, EventArgs e)
        {
            if (!btnSubject.Enabled)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadUserControl(new SubjectUC());
        }

        private void BtnScore_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ScoreUC());
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ReportUC());
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _isLoggingOut = true;
                this.Close();
            }
        }
    }
}

