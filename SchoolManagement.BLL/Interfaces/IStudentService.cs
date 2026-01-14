using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetAllAsync(string? keyword = null);
        Task<int> AddAsync(StudentDTO dto);
        Task<int> UpdateAsync(StudentDTO dto);
        Task<int> DeleteAsync(int studentId);
    }
}
