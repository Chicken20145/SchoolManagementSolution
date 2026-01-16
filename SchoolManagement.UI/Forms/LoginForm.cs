using System;
using System.Windows.Forms;
using SchoolManagement.BLL.Services;
using SchoolManagement.DAL.DAO.Implements;

namespace SchoolManagement.UI
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private readonly SessionService _sessionService;
        private bool _isExiting = false;

        public LoginForm()
        {
            InitializeComponent();
            _sessionService = new SessionService();
            _authService = new AuthService(new UserDAO(), _sessionService);
            this.FormClosing += LoginForm_FormClosing;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void LoginForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // If already confirmed exit via button, don't show dialog again
            if (_isExiting)
                return;

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
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tài khoản.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang đăng nhập...";

                var user = await _authService.LoginAsync(username, password);
                
                if (user == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                var mainForm = new MainForm(_sessionService);
                mainForm.FormClosed += (_, __) =>
                {
                    _authService.Logout();
                    this.Show();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                };
                
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Bạn có muốn thoát ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _isExiting = true;
                Application.Exit();
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}

