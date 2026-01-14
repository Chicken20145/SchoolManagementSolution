using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using SchoolManagement.DAL.Core;
using SchoolManagement.DAL.DAO.Interfaces;
using SchoolManagement.DTO;

namespace SchoolManagement.DAL.DAO.Implements
{
    public class StudentDAO : IStudentDAO
    {

        public async Task<List<StudentDTO>> GetAllAsync()
        {
            const string sql = @"
SELECT s.student_id, s.full_name, s.dob, s.gender, s.class_id, s.phone, s.address, s.status,
       c.class_name, c.grade
FROM students s
JOIN classes c ON c.class_id = s.class_id
WHERE s.status = 1
ORDER BY s.full_name;";

            var dt = await DbHelper.QueryAsync(sql);
            return ToList(dt);
        }

        public async Task<List<StudentDTO>> GetByClassAsync(int classId)
        {
            const string sql = @"
SELECT s.student_id, s.full_name, s.dob, s.gender, s.class_id, s.phone, s.address, s.status,
       c.class_name, c.grade
FROM students s
JOIN classes c ON c.class_id = s.class_id
WHERE s.class_id = @class_id AND s.status = 1
ORDER BY s.full_name;";

            var dt = await DbHelper.QueryAsync(sql, new MySqlParameter("@class_id", classId));
            return ToList(dt);
        }

        public async Task<int> InsertAsync(StudentDTO dto)
        {
            const string sql = @"
INSERT INTO students(full_name, dob, gender, class_id, phone, address, status)
VALUES(@full_name, @dob, @gender, @class_id, @phone, @address, @status);
SELECT LAST_INSERT_ID();";

            var obj = await DbHelper.ScalarAsync(sql,
                new MySqlParameter("@full_name", dto.FullName),
                new MySqlParameter("@dob", (object?)dto.Dob ?? DBNull.Value),
                new MySqlParameter("@gender", (object?)dto.Gender ?? DBNull.Value),
                new MySqlParameter("@class_id", dto.ClassId),
                new MySqlParameter("@phone", (object?)dto.Phone ?? DBNull.Value),
                new MySqlParameter("@address", (object?)dto.Address ?? DBNull.Value),
                new MySqlParameter("@status", dto.Status)
            );

            return Convert.ToInt32(obj);
        }

        public async Task<int> UpdateAsync(StudentDTO dto)
        {
            const string sql = @"
UPDATE students
SET full_name=@full_name, dob=@dob, gender=@gender, class_id=@class_id,
    phone=@phone, address=@address, status=@status
WHERE student_id=@student_id;";

            return await DbHelper.ExecuteAsync(sql,
                new MySqlParameter("@full_name", dto.FullName),
                new MySqlParameter("@dob", (object?)dto.Dob ?? DBNull.Value),
                new MySqlParameter("@gender", (object?)dto.Gender ?? DBNull.Value),
                new MySqlParameter("@class_id", dto.ClassId),
                new MySqlParameter("@phone", (object?)dto.Phone ?? DBNull.Value),
                new MySqlParameter("@address", (object?)dto.Address ?? DBNull.Value),
                new MySqlParameter("@status", dto.Status),
                new MySqlParameter("@student_id", dto.StudentId)
            );
        }

        public async Task<int> DeleteAsync(int studentId)
        {
            const string sql = "UPDATE students SET status=0 WHERE student_id=@id;";
            return await DbHelper.ExecuteAsync(sql, new MySqlParameter("@id", studentId));
        }

        private static List<StudentDTO> ToList(DataTable dt)
        {
            var list = new List<StudentDTO>();
            foreach (DataRow r in dt.Rows)
            {
                list.Add(new StudentDTO
                {
                    StudentId = Convert.ToInt32(r["student_id"]),
                    FullName = Convert.ToString(r["full_name"]) ?? string.Empty,
                    Dob = r["dob"] == DBNull.Value ? null : Convert.ToDateTime(r["dob"]),
                    Gender = r["gender"] == DBNull.Value ? null : Convert.ToString(r["gender"]),
                    ClassId = Convert.ToInt32(r["class_id"]),
                    Phone = r["phone"] == DBNull.Value ? null : Convert.ToString(r["phone"]),
                    Address = r["address"] == DBNull.Value ? null : Convert.ToString(r["address"]),
                    Status = r["status"] == DBNull.Value ? (byte)1 : Convert.ToByte(r["status"]),
                    ClassName = Convert.ToString(r["class_name"]) ?? string.Empty,
                    Grade = Convert.ToString(r["grade"]) ?? string.Empty
                });
            }
            return list;
        }
    }
}
