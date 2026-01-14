namespace SchoolManagement.DTO
{
    public class ScoreDTO
    {
        public int ScoreId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Semester { get; set; }
        public string SchoolYear { get; set; } = string.Empty;
        
        public float? Score15 { get; set; }
        public float? Score45 { get; set; }
        public float? ScoreFinal { get; set; }

        public string StudentName { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
    }
}
