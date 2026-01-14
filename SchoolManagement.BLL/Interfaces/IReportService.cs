using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Interfaces
{
    public interface IReportService
    {
        Task<List<ReportScoreRowDTO>> GetScoreSheetAsync(int classId, int subjectId, int semester, string schoolYear);
        Task<ReportSummaryDTO?> GetSummaryAsync(int classId, int subjectId, int semester, string schoolYear);
    }
}
