namespace Week5.Domain_Layer.Entity
{
    public class Class
    {
        public int ClassID { get; set; }
        public required string ClassName { get; set; }
        public ICollection<StudentClass> StudentClass { get; set; } = [];
    }
}
