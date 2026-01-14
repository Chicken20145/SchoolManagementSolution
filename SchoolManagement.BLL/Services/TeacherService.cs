using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.BLL.Services
{
    public class TeacherService
    {
        private readonly TeacherDAO _dao;

        public TeacherService(string connectionString)
        {
            _dao = new TeacherDAO();
        }

        public Task<List<TeacherDTO>> GetAllAsync() => _dao.GetAllAsync();
        public Task<List<TeacherItemDTO>> GetAllItemsAsync() => _dao.GetItemsAsync();

        public async Task<int> InsertAsync(TeacherDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Họ và tên giáo viên không được để trống.");

            return await _dao.InsertAsync(dto);
        }

        public async Task<int> UpdateAsync(TeacherDTO dto)
        {
            if (dto.TeacherId <= 0) throw new ArgumentException("TeacherId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(dto.FullName))
                throw new ArgumentException("Họ và tên giáo viên không được để trống.");

            return await _dao.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("TeacherId không hợp lệ.");
            return await _dao.DeleteAsync(id);
        }

        public async Task<int> CreateAsync(string fullName, string? email, string? phone)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Họ và tên giáo viên không được để trống.");

            return await _dao.InsertAsync(new TeacherDTO
            {
                FullName = fullName.Trim(),
                Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim(),
                Phone = string.IsNullOrWhiteSpace(phone) ? null : phone.Trim()
            });
        }

        public async Task<bool> UpdateAsync(int id, string fullName, string? email, string? phone)
        {
            if (id <= 0) throw new ArgumentException("TeacherId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Họ và tên giáo viên không được để trống.");

            var result = await _dao.UpdateAsync(new TeacherDTO
            {
                TeacherId = id,
                FullName = fullName.Trim(),
                Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim(),
                Phone = string.IsNullOrWhiteSpace(phone) ? null : phone.Trim()
            });
            return result > 0;
        }
    }
}
