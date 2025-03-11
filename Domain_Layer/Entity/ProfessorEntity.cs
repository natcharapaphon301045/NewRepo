namespace Week5.Domain_Layer.Entity
{
    public class Professor
    {
        public int ProfessorID { get; set; }
        public required string ProfessorName { get; set; }
        public required string ProfessorSurname { get; set; }
        public ICollection<Student> Student { get; set; } = [];
    }
}
