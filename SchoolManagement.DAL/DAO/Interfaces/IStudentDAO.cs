using System.Collections.Generic;
using System.Threading.Tasks;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface IStudentDAO
    {
        Task<List<StudentDTO>> GetAllAsync();
        Task<List<StudentDTO>> GetByClassAsync(int classId);
        Task<int> InsertAsync(StudentDTO dto);
        Task<int> UpdateAsync(StudentDTO dto);
        Task<int> DeleteAsync(int studentId);
    }
}