using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface IClassDAO
    {
        Task<List<ClassDTO>> GetAllAsync();
        Task<List<ClassItemDTO>> GetItemsAsync();
        Task<int> InsertAsync(ClassDTO dto);
        Task<int> UpdateAsync(ClassDTO dto);
        Task<int> DeleteAsync(int classId);
    }
}
