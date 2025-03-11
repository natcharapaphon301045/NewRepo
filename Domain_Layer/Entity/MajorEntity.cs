namespace Week5.Domain_Layer.Entity
{
    public class Major
    {
        public int MajorID { get; set; }
        public required string MajorName { get; set; }
        public ICollection<Student> Students { get; set; } = [];
    }
}
