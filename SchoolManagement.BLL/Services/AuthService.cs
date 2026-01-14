using System;
using System.Threading.Tasks;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Services
{
    public class AuthService
    {
        private readonly IUserDAO _userDao;
        private readonly SessionService _sessionService;

        public AuthService(IUserDAO userDao, SessionService sessionService)
        {
            _userDao = userDao;
            _sessionService = sessionService;
        }

        /// <summary>
        /// Login đơn giản với username và password
        /// </summary>
        public async Task<UserDTO?> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Username và password không được rỗng.");

            var user = await _userDao.LoginAsync(username, password);
            
            if (user != null)
            {
                _sessionService.SetUser(user);
            }
            
            return user;
        }

        public void Logout()
        {
            _sessionService.Logout();
        }

        public UserDTO? GetCurrentUser()
        {
            return _sessionService.CurrentUser;
        }

        public bool IsLoggedIn()
        {
            return _sessionService.IsLoggedIn;
        }

        public bool IsAdmin()
        {
            return _sessionService.IsAdmin;
        }

        public bool IsTeacher()
        {
            return _sessionService.IsTeacher;
        }
    }
}
