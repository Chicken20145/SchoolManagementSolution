using System.Data;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class SubjectDAO : ISubjectDAO
    {
        public async Task<List<SubjectDTO>> GetAllAsync()
        {
            const string sql = "SELECT subject_id, subject_name, credit FROM subjects ORDER BY subject_name;";

            var dt = await DbHelper.QueryAsync(sql);
            var list = new List<SubjectDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new SubjectDTO
                {
                    SubjectId = Convert.ToInt32(r["subject_id"]),
                    SubjectName = Convert.ToString(r["subject_name"]) ?? string.Empty,
                    Credit = r["credit"] == DBNull.Value ? 0 : Convert.ToInt32(r["credit"])
                });
            }

            return list;
        }

        public async Task<int> InsertAsync(SubjectDTO dto)
        {
            const string sql = @"
INSERT INTO subjects(subject_name, credit)
VALUES(@subject_name, @credit);
SELECT LAST_INSERT_ID();";

            var obj = await DbHelper.ScalarAsync(sql,
                new MySqlParameter("@subject_name", dto.SubjectName),
                new MySqlParameter("@credit", dto.Credit)
            );

            return Convert.ToInt32(obj);
        }

        public async Task<int> UpdateAsync(SubjectDTO dto)
        {
            const string sql = @"
UPDATE subjects
SET subject_name=@subject_name, credit=@credit
WHERE subject_id=@subject_id;";

            return await DbHelper.ExecuteAsync(sql,
                new MySqlParameter("@subject_name", dto.SubjectName),
                new MySqlParameter("@credit", dto.Credit),
                new MySqlParameter("@subject_id", dto.SubjectId)
            );
        }

        public async Task<int> DeleteAsync(int subjectId)
        {
            const string sql = "DELETE FROM subjects WHERE subject_id=@id;";
            return await DbHelper.ExecuteAsync(sql, new MySqlParameter("@id", subjectId));
        }
    }
}
