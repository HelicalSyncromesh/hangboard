using Timer.Events;
using Timer.Models;

namespace Timer.Data
{
    public interface IExerciseRecords
    {
        History Load(int exerciseId);
        void Save(ExerciseScored e);
    }
}