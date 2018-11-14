namespace Timer.Events
{
    public class ExerciseScored : WorkoutEvent
    {
        public int ExerciseId { get; set; }
        public int Score { get; set; }
    }
}