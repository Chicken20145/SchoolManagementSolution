using System.Data;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class ScoreDAO : IScoreDAO
    {
        public async Task<List<ScoreDTO>> GetByStudentAsync(int studentId)
        {
            const string sql = @"
SELECT sc.score_id, sc.student_id, sc.subject_id, sc.semester, sc.school_year, 
       sc.score_15, sc.score_45, sc.score_final,
       st.full_name as student_name, s.subject_name
FROM scores sc
JOIN students st ON st.student_id = sc.student_id
JOIN subjects s ON s.subject_id = sc.subject_id
WHERE sc.student_id=@student_id
ORDER BY sc.school_year DESC, sc.semester DESC, s.subject_name;";

            var dt = await DbHelper.QueryAsync(sql, new MySqlParameter("@student_id", studentId));
            return ToList(dt);
        }

        public async Task<List<ScoreDTO>> GetByClassAndSubjectAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            const string sql = @"
SELECT sc.score_id, sc.student_id, sc.subject_id, sc.semester, sc.school_year,
       sc.score_15, sc.score_45, sc.score_final,
       st.full_name as student_name, s.subject_name
FROM scores sc
JOIN students st ON st.student_id = sc.student_id
JOIN subjects s ON s.subject_id = sc.subject_id
WHERE st.class_id=@class_id AND sc.subject_id=@subject_id 
  AND sc.semester=@semester AND sc.school_year=@school_year
ORDER BY st.full_name;";

            var dt = await DbHelper.QueryAsync(sql,
                new MySqlParameter("@class_id", classId),
                new MySqlParameter("@subject_id", subjectId),
                new MySqlParameter("@semester", semester),
                new MySqlParameter("@school_year", schoolYear)
            );

            return ToList(dt);
        }

        public async Task<int> InsertAsync(ScoreDTO dto)
        {
            const string sql = @"
INSERT INTO scores(student_id, subject_id, semester, school_year, score_15, score_45, score_final)
VALUES(@student_id, @subject_id, @semester, @school_year, @score_15, @score_45, @score_final);
SELECT LAST_INSERT_ID();";

            var obj = await DbHelper.ScalarAsync(sql,
                new MySqlParameter("@student_id", dto.StudentId),
                new MySqlParameter("@subject_id", dto.SubjectId),
                new MySqlParameter("@semester", dto.Semester),
                new MySqlParameter("@school_year", dto.SchoolYear),
                new MySqlParameter("@score_15", (object?)dto.Score15 ?? DBNull.Value),
                new MySqlParameter("@score_45", (object?)dto.Score45 ?? DBNull.Value),
                new MySqlParameter("@score_final", (object?)dto.ScoreFinal ?? DBNull.Value)
            );

            return Convert.ToInt32(obj);
        }

        public async Task<int> UpdateAsync(ScoreDTO dto)
        {
            const string sql = @"
UPDATE scores
SET score_15=@score_15, score_45=@score_45, score_final=@score_final
WHERE score_id=@score_id;";

            return await DbHelper.ExecuteAsync(sql,
                new MySqlParameter("@score_15", (object?)dto.Score15 ?? DBNull.Value),
                new MySqlParameter("@score_45", (object?)dto.Score45 ?? DBNull.Value),
                new MySqlParameter("@score_final", (object?)dto.ScoreFinal ?? DBNull.Value),
                new MySqlParameter("@score_id", dto.ScoreId)
            );
        }

        public async Task<int> DeleteAsync(int scoreId)
        {
            const string sql = "DELETE FROM scores WHERE score_id=@id;";
            return await DbHelper.ExecuteAsync(sql, new MySqlParameter("@id", scoreId));
        }

        public async Task<List<ScoreEntryDTO>> GetEntriesAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            const string sql = @"
SELECT
    sc.score_id,
    st.student_id,
    st.full_name,
    c.class_id,
    c.class_name,
    sb.subject_id,
    sb.subject_name,
    @semester AS semester,
    @school_year AS school_year,
    sc.score_15,
    sc.score_45,
    sc.score_final
FROM students st
JOIN classes c ON c.class_id = st.class_id
CROSS JOIN subjects sb
LEFT JOIN scores sc
    ON sc.student_id = st.student_id
   AND sc.subject_id = sb.subject_id
   AND sc.semester = @semester
   AND sc.school_year = @school_year
WHERE st.class_id = @class_id AND sb.subject_id = @subject_id AND st.status = 1
ORDER BY st.full_name;";

            var p = new[]
            {
                new MySqlParameter("@class_id", classId),
                new MySqlParameter("@subject_id", subjectId),
                new MySqlParameter("@semester", semester),
                new MySqlParameter("@school_year", schoolYear)
            };

            var dt = await DbHelper.QueryAsync(sql, p);
            var list = new List<ScoreEntryDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ScoreEntryDTO
                {
                    ScoreId = r["score_id"] == DBNull.Value ? null : Convert.ToInt32(r["score_id"]),
                    StudentId = Convert.ToInt32(r["student_id"]),
                    StudentName = Convert.ToString(r["full_name"]) ?? string.Empty,
                    ClassId = Convert.ToInt32(r["class_id"]),
                    ClassName = Convert.ToString(r["class_name"]) ?? string.Empty,
                    SubjectId = Convert.ToInt32(r["subject_id"]),
                    SubjectName = Convert.ToString(r["subject_name"]) ?? string.Empty,
                    Semester = Convert.ToInt32(r["semester"]),
                    SchoolYear = Convert.ToString(r["school_year"]) ?? string.Empty,
                    Score15 = r["score_15"] == DBNull.Value ? null : Convert.ToSingle(r["score_15"]),
                    Score45 = r["score_45"] == DBNull.Value ? null : Convert.ToSingle(r["score_45"]),
                    ScoreFinal = r["score_final"] == DBNull.Value ? null : Convert.ToSingle(r["score_final"])
                });
            }

            return list;
        }

        public async Task<int> SaveAsync(ScoreEntryDTO dto)
        {
            var allNull = dto.Score15 == null && dto.Score45 == null && dto.ScoreFinal == null;

            if (dto.ScoreId.HasValue && allNull)
            {
                const string delSql = "DELETE FROM scores WHERE score_id = @id;";
                return await DbHelper.ExecuteAsync(delSql, new MySqlParameter("@id", dto.ScoreId.Value));
            }

            if (!dto.ScoreId.HasValue)
            {
                const string insSql = @"
INSERT INTO scores(student_id, subject_id, semester, school_year, score_15, score_45, score_final)
VALUES(@student_id, @subject_id, @semester, @school_year, @s15, @s45, @sfinal);";

                return await DbHelper.ExecuteAsync(insSql,
                    new MySqlParameter("@student_id", dto.StudentId),
                    new MySqlParameter("@subject_id", dto.SubjectId),
                    new MySqlParameter("@semester", dto.Semester),
                    new MySqlParameter("@school_year", dto.SchoolYear),
                    new MySqlParameter("@s15", (object?)dto.Score15 ?? DBNull.Value),
                    new MySqlParameter("@s45", (object?)dto.Score45 ?? DBNull.Value),
                    new MySqlParameter("@sfinal", (object?)dto.ScoreFinal ?? DBNull.Value)
                );
            }
            else
            {
                const string updSql = @"
UPDATE scores
SET score_15 = @s15,
    score_45 = @s45,
    score_final = @sfinal
WHERE score_id = @id;";

                return await DbHelper.ExecuteAsync(updSql,
                    new MySqlParameter("@s15", (object?)dto.Score15 ?? DBNull.Value),
                    new MySqlParameter("@s45", (object?)dto.Score45 ?? DBNull.Value),
                    new MySqlParameter("@sfinal", (object?)dto.ScoreFinal ?? DBNull.Value),
                    new MySqlParameter("@id", dto.ScoreId.Value)
                );
            }
        }

        public async Task<int> SaveBatchAsync(List<ScoreEntryDTO> items)
        {
            if (items == null || items.Count == 0) return 0;

            await using var conn = DbConnectionFactory.CreateConnection();
            await conn.OpenAsync();
            await using var tx = await conn.BeginTransactionAsync();

            try
            {
                int affected = 0;

                foreach (var dto in items)
                {
                    var allNull = dto.Score15 == null && dto.Score45 == null && dto.ScoreFinal == null;

                    if (dto.ScoreId.HasValue && allNull)
                    {
                        await using var cmdDel = new MySqlCommand("DELETE FROM scores WHERE score_id = @id;", conn, (MySqlTransaction)tx);
                        cmdDel.Parameters.AddWithValue("@id", dto.ScoreId.Value);
                        affected += await cmdDel.ExecuteNonQueryAsync();
                        continue;
                    }

                    if (!dto.ScoreId.HasValue)
                    {
                        await using var cmdIns = new MySqlCommand(@"
INSERT INTO scores(student_id, subject_id, semester, school_year, score_15, score_45, score_final)
VALUES(@student_id, @subject_id, @semester, @school_year, @s15, @s45, @sfinal);", conn, (MySqlTransaction)tx);

                        cmdIns.Parameters.AddWithValue("@student_id", dto.StudentId);
                        cmdIns.Parameters.AddWithValue("@subject_id", dto.SubjectId);
                        cmdIns.Parameters.AddWithValue("@semester", dto.Semester);
                        cmdIns.Parameters.AddWithValue("@school_year", dto.SchoolYear);
                        cmdIns.Parameters.AddWithValue("@s15", (object?)dto.Score15 ?? DBNull.Value);
                        cmdIns.Parameters.AddWithValue("@s45", (object?)dto.Score45 ?? DBNull.Value);
                        cmdIns.Parameters.AddWithValue("@sfinal", (object?)dto.ScoreFinal ?? DBNull.Value);

                        affected += await cmdIns.ExecuteNonQueryAsync();
                    }
                    else
                    {
                        await using var cmdUpd = new MySqlCommand(@"
UPDATE scores
SET score_15 = @s15,
    score_45 = @s45,
    score_final = @sfinal
WHERE score_id = @id;", conn, (MySqlTransaction)tx);

                        cmdUpd.Parameters.AddWithValue("@s15", (object?)dto.Score15 ?? DBNull.Value);
                        cmdUpd.Parameters.AddWithValue("@s45", (object?)dto.Score45 ?? DBNull.Value);
                        cmdUpd.Parameters.AddWithValue("@sfinal", (object?)dto.ScoreFinal ?? DBNull.Value);
                        cmdUpd.Parameters.AddWithValue("@id", dto.ScoreId.Value);

                        affected += await cmdUpd.ExecuteNonQueryAsync();
                    }
                }

                await tx.CommitAsync();
                return affected;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        private static List<ScoreDTO> ToList(DataTable dt)
        {
            var list = new List<ScoreDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ScoreDTO
                {
                    ScoreId = Convert.ToInt32(r["score_id"]),
                    StudentId = Convert.ToInt32(r["student_id"]),
                    SubjectId = Convert.ToInt32(r["subject_id"]),
                    Semester = Convert.ToInt32(r["semester"]),
                    SchoolYear = Convert.ToString(r["school_year"]) ?? string.Empty,
                    Score15 = r["score_15"] == DBNull.Value ? null : Convert.ToSingle(r["score_15"]),
                    Score45 = r["score_45"] == DBNull.Value ? null : Convert.ToSingle(r["score_45"]),
                    ScoreFinal = r["score_final"] == DBNull.Value ? null : Convert.ToSingle(r["score_final"]),
                    StudentName = Convert.ToString(r["student_name"]) ?? string.Empty,
                    SubjectName = Convert.ToString(r["subject_name"]) ?? string.Empty
                });
            }

            return list;
        }
    }
}
