namespace Week5.Domain_Layer.Entity
{
    public class BehaviorScore
    {
        public int ScoreID { get; set; }
        public int StudentID { get; set; }
        public int Score { get; set; }

        public required Student Student { get; set; }


    }
}
