using SchoolManagement.BLL.Interfaces;
using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportDAO _dao;

        public ReportService()
        {
            _dao = new ReportDAO();
        }

        public ReportService(IReportDAO dao)
        {
            _dao = dao;
        }

        public Task<List<ReportScoreRowDTO>> GetScoreSheetAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            if (classId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            if (subjectId <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            if (semester != 1 && semester != 2) throw new ArgumentException("Semester chỉ được 1 hoặc 2.");
            if (string.IsNullOrWhiteSpace(schoolYear)) throw new ArgumentException("SchoolYear rỗng.");

            return _dao.GetScoreSheetAsync(classId, subjectId, semester, schoolYear.Trim());
        }

        public Task<ReportSummaryDTO?> GetSummaryAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            if (classId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            if (subjectId <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            if (semester != 1 && semester != 2) throw new ArgumentException("Semester chỉ được 1 hoặc 2.");
            if (string.IsNullOrWhiteSpace(schoolYear)) throw new ArgumentException("SchoolYear rỗng.");

            return _dao.GetSummaryAsync(classId, subjectId, semester, schoolYear.Trim());
        }
    }
}
