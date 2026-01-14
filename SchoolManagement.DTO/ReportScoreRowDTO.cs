namespace SchoolManagement.DTO
{
    public class ReportScoreRowDTO
    {
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

        public float? Average
        {
            get
            {
                float sum = 0;
                int cnt = 0;
                if (Score15.HasValue) { sum += Score15.Value; cnt++; }
                if (Score45.HasValue) { sum += Score45.Value; cnt++; }
                if (ScoreFinal.HasValue) { sum += ScoreFinal.Value; cnt++; }
                return cnt == 0 ? null : (float)Math.Round(sum / cnt, 2);
            }
        }
    }
}
