namespace SchoolManagement.DTO
{
    public class ReportSummaryDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;

        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;

        public int Semester { get; set; }
        public string SchoolYear { get; set; } = string.Empty;

        public int TotalStudents { get; set; }
        public int TotalScoreRows { get; set; }

        public float? Avg15 { get; set; }
        public float? Avg45 { get; set; }
        public float? AvgFinal { get; set; }

        public float? AvgOverall { get; set; }
    }
}
