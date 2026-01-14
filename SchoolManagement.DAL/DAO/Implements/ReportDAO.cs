using System.Data;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class ReportDAO : IReportDAO
    {
        public async Task<List<ReportScoreRowDTO>> GetScoreSheetAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            const string sql = @"
SELECT
    st.student_id,
    st.full_name,
    c.class_id,
    c.class_name,
    sb.subject_id,
    sb.subject_name,
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
WHERE st.class_id = @class_id 
  AND sb.subject_id = @subject_id
  AND st.status = 1
ORDER BY st.full_name;";

            var p = new[]
            {
                new MySqlParameter("@class_id", classId),
                new MySqlParameter("@subject_id", subjectId),
                new MySqlParameter("@semester", semester),
                new MySqlParameter("@school_year", schoolYear),
            };

            var dt = await DbHelper.QueryAsync(sql, p);
            var list = new List<ReportScoreRowDTO>();

            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ReportScoreRowDTO
                {
                    StudentId = Convert.ToInt32(r["student_id"]),
                    StudentName = Convert.ToString(r["full_name"]) ?? string.Empty,

                    ClassId = Convert.ToInt32(r["class_id"]),
                    ClassName = Convert.ToString(r["class_name"]) ?? string.Empty,

                    SubjectId = Convert.ToInt32(r["subject_id"]),
                    SubjectName = Convert.ToString(r["subject_name"]) ?? string.Empty,

                    Semester = semester,
                    SchoolYear = schoolYear,

                    Score15 = r["score_15"] == DBNull.Value ? null : Convert.ToSingle(r["score_15"]),
                    Score45 = r["score_45"] == DBNull.Value ? null : Convert.ToSingle(r["score_45"]),
                    ScoreFinal = r["score_final"] == DBNull.Value ? null : Convert.ToSingle(r["score_final"]),
                });
            }

            return list;
        }

        public async Task<ReportSummaryDTO?> GetSummaryAsync(int classId, int subjectId, int semester, string schoolYear)
        {
            const string sql = @"
SELECT
    c.class_id,
    c.class_name,
    sb.subject_id,
    sb.subject_name,
    COUNT(DISTINCT st.student_id) AS total_students,
    COUNT(sc.score_id) AS total_score_rows,
    AVG(sc.score_15) AS avg15,
    AVG(sc.score_45) AS avg45,
    AVG(sc.score_final) AS avgfinal
FROM students st
JOIN classes c ON c.class_id = st.class_id
CROSS JOIN subjects sb
LEFT JOIN scores sc
    ON sc.student_id = st.student_id
   AND sc.subject_id = sb.subject_id
   AND sc.semester = @semester
   AND sc.school_year = @school_year
WHERE st.class_id = @class_id 
  AND sb.subject_id = @subject_id
  AND st.status = 1
GROUP BY c.class_id, c.class_name, sb.subject_id, sb.subject_name;";

            var p = new[]
            {
                new MySqlParameter("@class_id", classId),
                new MySqlParameter("@subject_id", subjectId),
                new MySqlParameter("@semester", semester),
                new MySqlParameter("@school_year", schoolYear),
            };

            var dt = await DbHelper.QueryAsync(sql, p);
            if (dt.Rows.Count == 0) return null;

            var r = dt.Rows[0];

            float? avg15 = r["avg15"] == DBNull.Value ? null : Convert.ToSingle(r["avg15"]);
            float? avg45 = r["avg45"] == DBNull.Value ? null : Convert.ToSingle(r["avg45"]);
            float? avgFinal = r["avgfinal"] == DBNull.Value ? null : Convert.ToSingle(r["avgfinal"]);

            float? overall = null;
            {
                float sum = 0; int cnt = 0;
                if (avg15.HasValue) { sum += avg15.Value; cnt++; }
                if (avg45.HasValue) { sum += avg45.Value; cnt++; }
                if (avgFinal.HasValue) { sum += avgFinal.Value; cnt++; }
                overall = cnt == 0 ? null : (float)Math.Round(sum / cnt, 2);
            }

            return new ReportSummaryDTO
            {
                ClassId = Convert.ToInt32(r["class_id"]),
                ClassName = Convert.ToString(r["class_name"]) ?? string.Empty,
                SubjectId = Convert.ToInt32(r["subject_id"]),
                SubjectName = Convert.ToString(r["subject_name"]) ?? string.Empty,
                Semester = semester,
                SchoolYear = schoolYear,

                TotalStudents = Convert.ToInt32(r["total_students"]),
                TotalScoreRows = Convert.ToInt32(r["total_score_rows"]),
                Avg15 = avg15,
                Avg45 = avg45,
                AvgFinal = avgFinal,
                AvgOverall = overall
            };
        }
    }
}
