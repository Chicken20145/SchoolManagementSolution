using System.Threading.Tasks;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface IUserDAO
    {
        Task<UserDTO?> LoginAsync(string username, string password);
    }
}
