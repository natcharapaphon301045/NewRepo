namespace Week5.Domain_Layer.Entity
{
    public class Student
    {
        public int StudentID { get; set; }
        public required string StudentName { get; set; }
        public required string StudentSurname { get; set; }

        public int ProfessorID { get; set; }
        public required Professor Professor { get; set; }

        public int MajorID { get; set; }
        public required Major Major { get; set; }

        public required ICollection<StudentClass> StudentClass { get; set; }
        public required ICollection<BehaviorScore> BehaviorScore { get; set; }

    }
}
