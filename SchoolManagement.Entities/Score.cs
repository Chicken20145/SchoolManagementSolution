namespace SchoolManagement.Entities
{
    public class Score
    {
        public int ScoreId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Semester { get; set; }
        public string SchoolYear { get; set; } = string.Empty;
        public float? Score15 { get; set; }
        public float? Score45 { get; set; }
        public float? ScoreFinal { get; set; }
    }
}
