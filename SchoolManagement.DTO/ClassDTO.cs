namespace SchoolManagement.DTO
{
    public class ClassDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string? Grade { get; set; }
        public int? HomeroomTeacherId { get; set; }
        public string? HomeroomTeacherName { get; set; }
    }
}
