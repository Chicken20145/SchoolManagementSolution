using System.Data;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class ClassDAO : IClassDAO
    {
        public async Task<List<ClassDTO>> GetAllAsync()
        {
            const string sql = @"
SELECT c.class_id, c.class_name, c.grade, c.homeroom_teacher_id,
       t.full_name as teacher_name
FROM classes c
LEFT JOIN teachers t ON t.teacher_id = c.homeroom_teacher_id
ORDER BY c.grade, c.class_name;";

            var dt = await DbHelper.QueryAsync(sql);
            return ToList(dt);
        }

        public async Task<List<ClassItemDTO>> GetItemsAsync()
        {
            const string sql = "SELECT class_id, class_name FROM classes ORDER BY grade, class_name;";

            var dt = await DbHelper.QueryAsync(sql);
            var list = new List<ClassItemDTO>();
            
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ClassItemDTO
                {
                    ClassId = Convert.ToInt32(r["class_id"]),
                    ClassName = Convert.ToString(r["class_name"]) ?? string.Empty
                });
            }

            return list;
        }

        public async Task<int> InsertAsync(ClassDTO dto)
        {
            const string sql = @"
INSERT INTO classes(class_name, grade, homeroom_teacher_id)
VALUES(@class_name, @grade, @homeroom_teacher_id);
SELECT LAST_INSERT_ID();";

            var obj = await DbHelper.ScalarAsync(sql,
                new MySqlParameter("@class_name", dto.ClassName),
                new MySqlParameter("@grade", dto.Grade),
                new MySqlParameter("@homeroom_teacher_id", (object?)dto.HomeroomTeacherId ?? DBNull.Value)
            );

            return Convert.ToInt32(obj);
        }

        public async Task<int> UpdateAsync(ClassDTO dto)
        {
            const string sql = @"
UPDATE classes
SET class_name=@class_name, grade=@grade, homeroom_teacher_id=@homeroom_teacher_id
WHERE class_id=@class_id;";

            return await DbHelper.ExecuteAsync(sql,
                new MySqlParameter("@class_name", dto.ClassName),
                new MySqlParameter("@grade", dto.Grade),
                new MySqlParameter("@homeroom_teacher_id", (object?)dto.HomeroomTeacherId ?? DBNull.Value),
                new MySqlParameter("@class_id", dto.ClassId)
            );
        }

        public async Task<int> DeleteAsync(int classId)
        {
            const string sql = "DELETE FROM classes WHERE class_id=@id;";
            return await DbHelper.ExecuteAsync(sql, new MySqlParameter("@id", classId));
        }

        private static List<ClassDTO> ToList(DataTable dt)
        {
            var list = new List<ClassDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new ClassDTO
                {
                    ClassId = Convert.ToInt32(r["class_id"]),
                    ClassName = Convert.ToString(r["class_name"]) ?? string.Empty,
                    Grade = Convert.ToString(r["grade"]) ?? string.Empty,
                    HomeroomTeacherId = r["homeroom_teacher_id"] == DBNull.Value ? null : Convert.ToInt32(r["homeroom_teacher_id"]),
                    HomeroomTeacherName = r["teacher_name"] == DBNull.Value ? string.Empty : Convert.ToString(r["teacher_name"]) ?? string.Empty
                });
            }
            return list;
        }
    }
}
