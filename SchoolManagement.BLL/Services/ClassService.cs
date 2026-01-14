using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.BLL.Services
{
    public class ClassService
    {
        private readonly ClassDAO _dao;

        public ClassService(string connectionString)
        {
            _dao = new ClassDAO();
        }

        public async Task<List<ClassDTO>> GetAllAsync() => await _dao.GetAllAsync();
        public async Task<List<ClassItemDTO>> GetItemsAsync() => await _dao.GetItemsAsync();

        public async Task<int> InsertAsync(ClassDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.ClassName))
                throw new ArgumentException("Tên lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.Grade))
                throw new ArgumentException("Khối không được để trống.");

            return await _dao.InsertAsync(dto);
        }

        public async Task<int> UpdateAsync(ClassDTO dto)
        {
            if (dto.ClassId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(dto.ClassName))
                throw new ArgumentException("Tên lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.Grade))
                throw new ArgumentException("Khối không được để trống.");

            return await _dao.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int classId)
        {
            if (classId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            return await _dao.DeleteAsync(classId);
        }

        public async Task<int> CreateAsync(string className, string grade, int? homeroomTeacherId)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Tên lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(grade))
                throw new ArgumentException("Khối không được để trống.");

            return await _dao.InsertAsync(new ClassDTO
            {
                ClassName = className.Trim(),
                Grade = grade.Trim(),
                HomeroomTeacherId = homeroomTeacherId
            });
        }

        public async Task<int> UpdateAsync(int classId, string className, string grade, int? homeroomTeacherId)
        {
            if (classId <= 0) throw new ArgumentException("ClassId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(className))
                throw new ArgumentException("Tên lớp không được để trống.");
            if (string.IsNullOrWhiteSpace(grade))
                throw new ArgumentException("Khối không được để trống.");

            return await _dao.UpdateAsync(new ClassDTO
            {
                ClassId = classId,
                ClassName = className.Trim(),
                Grade = grade.Trim(),
                HomeroomTeacherId = homeroomTeacherId
            });
        }
    }
}
