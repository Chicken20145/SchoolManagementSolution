using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Services
{
    public class SessionService
    {
        private static UserDTO? _currentUser;

        public UserDTO? CurrentUser 
        { 
            get => _currentUser;
            private set => _currentUser = value;
        }

        public bool IsLoggedIn => CurrentUser != null;
        
        public bool IsAdmin => CurrentUser?.Role == "ADMIN";
        
        public bool IsTeacher => CurrentUser?.Role == "TEACHER";

        public void SetUser(UserDTO user)
        {
            CurrentUser = user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public void ClearSession()
        {
            Logout();
        }
    }
}
