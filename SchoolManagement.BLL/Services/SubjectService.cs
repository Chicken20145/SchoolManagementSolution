using SchoolManagement.DAL.DAO.Implements;
using SchoolManagement.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.BLL.Services
{
    public class SubjectService
    {
        private readonly SubjectDAO _dao;

        public SubjectService(string connectionString)
        {
            _dao = new SubjectDAO();
        }

        public Task<List<SubjectDTO>> GetAllAsync() => _dao.GetAllAsync();

        public async Task<int> InsertAsync(SubjectDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.SubjectName))
                throw new ArgumentException("Tên môn học không được để trống.");
            if (dto.Credit <= 0)
                throw new ArgumentException("Credit phải là số nguyên dương.");

            return await _dao.InsertAsync(dto);
        }

        public async Task<int> UpdateAsync(SubjectDTO dto)
        {
            if (dto.SubjectId <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(dto.SubjectName))
                throw new ArgumentException("Tên môn học không được để trống.");
            if (dto.Credit <= 0)
                throw new ArgumentException("Credit phải là số nguyên dương.");

            return await _dao.UpdateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            return await _dao.DeleteAsync(id);
        }

        public async Task<int> CreateAsync(string name, int credit)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên môn học không được để trống.");
            if (credit <= 0)
                throw new ArgumentException("Credit phải là số nguyên dương.");

            return await _dao.InsertAsync(new SubjectDTO { SubjectName = name.Trim(), Credit = credit });
        }

        public async Task<bool> UpdateAsync(int id, string name, int credit)
        {
            if (id <= 0) throw new ArgumentException("SubjectId không hợp lệ.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên môn học không được để trống.");
            if (credit <= 0)
                throw new ArgumentException("Credit phải là số nguyên dương.");

            var result = await _dao.UpdateAsync(new SubjectDTO { SubjectId = id, SubjectName = name.Trim(), Credit = credit });
            return result > 0;
        }
    }
}
