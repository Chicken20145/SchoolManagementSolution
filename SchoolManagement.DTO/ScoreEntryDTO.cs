namespace SchoolManagement.DTO
{
    public class ScoreEntryDTO
    {
        public int? ScoreId { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;

        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;

        public int Semester { get; set; }
        public string SchoolYear { get; set; } = string.Empty;

        public float? Score15 { get; set; }
        public float? Score45 { get; set; }
        public float? ScoreFinal { get; set; }
        
        // Điểm trung bình và xếp loại (tính toán)
        public decimal? AverageScore { get; set; }
        public string? Rank { get; set; }
    }
}
