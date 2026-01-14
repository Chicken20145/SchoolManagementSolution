namespace SchoolManagement.DTO
{
    public class ClassItemDTO
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;

        public override string ToString() => ClassName;
    }
}
