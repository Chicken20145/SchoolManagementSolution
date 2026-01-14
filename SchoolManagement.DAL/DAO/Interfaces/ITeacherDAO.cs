using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface ITeacherDAO
    {
        Task<List<TeacherDTO>> GetAllAsync();
        Task<List<TeacherItemDTO>> GetItemsAsync();
        Task<int> InsertAsync(TeacherDTO dto);
        Task<int> UpdateAsync(TeacherDTO dto);
        Task<int> DeleteAsync(int teacherId);
    }
}
