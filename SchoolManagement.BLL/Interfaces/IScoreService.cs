using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Interfaces
{
    public interface IScoreService
    {
        Task<List<ScoreEntryDTO>> GetEntriesAsync(int classId, int subjectId, int semester, string schoolYear);
        Task<int> SaveBatchAsync(List<ScoreEntryDTO> items);
    }
}
