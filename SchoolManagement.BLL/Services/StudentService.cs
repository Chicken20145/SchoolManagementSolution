using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.BLL.Services
{
    public class StudentService
    {
        private readonly StudentDAO _dao = new StudentDAO();

        public async Task<List<StudentDTO>> GetAllAsync() => await _dao.GetAllAsync();
        public async Task<List<StudentDTO>> GetByClassAsync(int classId) => await _dao.GetByClassAsync(classId);
        public async Task<int> AddAsync(StudentDTO dto) => await _dao.InsertAsync(dto);
        public async Task<int> UpdateAsync(StudentDTO dto) => await _dao.UpdateAsync(dto);
        public async Task<int> DeleteAsync(int studentId) => await _dao.DeleteAsync(studentId);
    }
}
