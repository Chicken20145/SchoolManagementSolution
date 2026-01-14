using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Interfaces
{
    public interface IReportDAO
    {
        Task<List<ReportScoreRowDTO>> GetScoreSheetAsync(int classId, int subjectId, int semester, string schoolYear);
        Task<ReportSummaryDTO?> GetSummaryAsync(int classId, int subjectId, int semester, string schoolYear);
    }
}
