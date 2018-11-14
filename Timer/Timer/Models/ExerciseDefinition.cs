namespace Timer.Models
{
    public class ExerciseDefinition
    {
        public ExerciseDefinition(){}
        public ExerciseDefinition(int id,int quantity, bool isDuration, string exercise, string hold)
        {
            Id = id;
            Quantity = quantity;
            IsDuration = isDuration;
            Exercise = exercise;
            Hold = hold;
        }
        public int Quantity { get; set; }
        public bool IsDuration { get; set; }
        public string Exercise { get; set; }
        public string Hold { get; set; }
        public int Id { get; set; }
    }
}