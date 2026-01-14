using System.Data;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class TeacherDAO : ITeacherDAO
    {
        public async Task<List<TeacherDTO>> GetAllAsync()
        {
            const string sql = @"
SELECT 
    t.teacher_id,
    t.full_name,
    t.email,
    t.phone,
    t.subject_id,
    s.subject_name
FROM teachers t
LEFT JOIN subjects s ON s.subject_id = t.subject_id
ORDER BY t.full_name;";

            var dt = await DbHelper.QueryAsync(sql);
            var list = new List<TeacherDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new TeacherDTO
                {
                    TeacherId = Convert.ToInt32(r["teacher_id"]),
                    FullName = Convert.ToString(r["full_name"]) ?? string.Empty,
                    Email = r["email"] == DBNull.Value ? null : Convert.ToString(r["email"]),
                    Phone = r["phone"] == DBNull.Value ? null : Convert.ToString(r["phone"]),
                    SubjectId = r["subject_id"] == DBNull.Value ? null : Convert.ToInt32(r["subject_id"]),
                    SubjectName = r["subject_name"] == DBNull.Value ? null : Convert.ToString(r["subject_name"])
                });
            }

            return list;
        }

        public async Task<List<TeacherItemDTO>> GetItemsAsync()
        {
            const string sql = "SELECT teacher_id, full_name FROM teachers ORDER BY full_name;";

            var dt = await DbHelper.QueryAsync(sql);
            var list = new List<TeacherItemDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new TeacherItemDTO
                {
                    TeacherId = Convert.ToInt32(r["teacher_id"]),
                    FullName = Convert.ToString(r["full_name"]) ?? string.Empty
                });
            }

            return list;
        }

        public async Task<int> InsertAsync(TeacherDTO dto)
        {
            const string sql = @"
INSERT INTO teachers(full_name, email, phone, subject_id)
VALUES(@full_name, @email, @phone, @subject_id);
SELECT LAST_INSERT_ID();";

            var obj = await DbHelper.ScalarAsync(sql,
                new MySqlParameter("@full_name", dto.FullName),
                new MySqlParameter("@email", (object?)dto.Email ?? DBNull.Value),
                new MySqlParameter("@phone", (object?)dto.Phone ?? DBNull.Value),
                new MySqlParameter("@subject_id", (object?)dto.SubjectId ?? DBNull.Value)
            );

            return Convert.ToInt32(obj);
        }

        public async Task<int> UpdateAsync(TeacherDTO dto)
        {
            const string sql = @"
UPDATE teachers
SET full_name=@full_name, email=@email, phone=@phone, subject_id=@subject_id
WHERE teacher_id=@teacher_id;";

            return await DbHelper.ExecuteAsync(sql,
                new MySqlParameter("@full_name", dto.FullName),
                new MySqlParameter("@email", (object?)dto.Email ?? DBNull.Value),
                new MySqlParameter("@phone", (object?)dto.Phone ?? DBNull.Value),
                new MySqlParameter("@subject_id", (object?)dto.SubjectId ?? DBNull.Value),
                new MySqlParameter("@teacher_id", dto.TeacherId)
            );
        }

        public async Task<int> DeleteAsync(int teacherId)
        {
            const string sql = "DELETE FROM teachers WHERE teacher_id=@id;";
            return await DbHelper.ExecuteAsync(sql, new MySqlParameter("@id", teacherId));
        }
    }
}
