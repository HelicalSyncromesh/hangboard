using Timer.Models;

namespace Timer.Data
{
    public interface IWorkout
    {
        WorkoutDefinition Load(int id);
    }
}