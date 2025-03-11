namespace Week5.Domain_Layer.Entity
{
    public class StudentClass
    {
        public int StudentID { get; set; }
        public required Student Student { get; set; }

        public int ClassID { get; set; }
        public required Class Class { get; set; }
    }
}
