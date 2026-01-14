using SchoolManagement.BLL.Interfaces;
using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.BLL.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreDAO _dao;

        public ScoreService()
        {
            _dao = new ScoreDAO();
        }

        public ScoreService(IScoreDAO dao)
        {
            _dao = dao;
        }

        public async Task<List<ScoreDTO>> GetByStudentAsync(int studentId) => await _dao.GetByStudentAsync(studentId);
        
        public async Task<List<ScoreDTO>> GetByClassAndSubjectAsync(int classId, int subjectId, int semester, string schoolYear)
            => await _dao.GetByClassAndSubjectAsync(classId, subjectId, semester, schoolYear);

        public async Task<int> AddAsync(ScoreDTO dto) => await _dao.InsertAsync(dto);
        public async Task<int> UpdateAsync(ScoreDTO dto) => await _dao.UpdateAsync(dto);
        public async Task<int> DeleteAsync(int scoreId) => await _dao.DeleteAsync(scoreId);

        public Task<List<ScoreEntryDTO>> GetEntriesAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            if (classId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            if (subjectId <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            if (semester != 1 && semester != 2) throw new ArgumentException("Semester chỉ được 1 hoặc 2.");
            if (string.IsNullOrWhiteSpace(schoolYear)) throw new ArgumentException("SchoolYear rỗng.");

            return _dao.GetEntriesAsync(classId, subjectId, semester, schoolYear.Trim());
        }

        public Task<int> SaveBatchAsync(List<ScoreEntryDTO> items)
        {
            return _dao.SaveBatchAsync(items);
        }
    }
}
