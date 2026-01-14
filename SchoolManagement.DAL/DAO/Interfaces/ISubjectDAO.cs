using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface ISubjectDAO
    {
        Task<List<SubjectDTO>> GetAllAsync();
        Task<int> InsertAsync(SubjectDTO dto);
        Task<int> UpdateAsync(SubjectDTO dto);
        Task<int> DeleteAsync(int subjectId);
    }
}
