namespace SchoolManagement.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        
        public int? SubjectId { get; set; }
        public string? SubjectName { get; set; }
    }
}
