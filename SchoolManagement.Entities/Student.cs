using System;

namespace SchoolManagement.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime? Dob { get; set; }
        public string? Gender { get; set; }
        public int ClassId { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public byte Status { get; set; } = 1;
    }
}
