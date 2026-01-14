using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface IScoreDAO
    {
        Task<List<ScoreDTO>> GetByStudentAsync(int studentId);
        Task<List<ScoreDTO>> GetByClassAndSubjectAsync(int classId, int subjectId, int semester, string schoolYear);
        Task<int> InsertAsync(ScoreDTO dto);
        Task<int> UpdateAsync(ScoreDTO dto);
        Task<int> DeleteAsync(int scoreId);

        Task<List<ScoreEntryDTO>> GetEntriesAsync(int classId, int subjectId, int semester, string schoolYear);
        Task<int> SaveAsync(ScoreEntryDTO dto);
        Task<int> SaveBatchAsync(List<ScoreEntryDTO> items);
    }
}
