using System;
using System.Collections.Generic;
using System.Linq;
using Timer.Events;
using Timer.Models;

namespace Timer.Services
{
    public class ScorecardService
    {
        private Dictionary<Guid, List<WorkoutEvent>> _events;

        public ScorecardService()
        {
            _events = new Dictionary<Guid, List<WorkoutEvent>>();
        }

        public void StartWorkout(WorkoutStarted @event)
        {
            _events.Add(@event.InstanceId,new List<WorkoutEvent>{@event});
        }

        public void Score(ExerciseScored @event)
        {
            _events[@event.InstanceId].Add(@event);
        }

        public void EndWorkout(WorkoutCompleted @event)
        {
            _events[@event.InstanceId].Add(@event);
        }

        public Scorecard GetScorecard(Guid instanceId)
        {
            var workoutEvents = _events[instanceId];

            var start = workoutEvents.OfType<WorkoutStarted>().First();

            var end = workoutEvents.OfType<WorkoutCompleted>().First();

            var scores = workoutEvents.OfType<ExerciseScored>();

            var result = new Scorecard
            {
                InstanceId = instanceId,
                WorkoutId = start.WorkoutId,
                WorkoutStarted = start.Timestamp,
                WorkoutEnded = end.Timestamp,
                Scores = scores.ToDictionary(x => x.ExerciseId, x => new Score {ExerciseId = x.ExerciseId, QuantityCompleted = x.Score, ScoredAt = x.Timestamp})
            };

            return result;
        }
    }
}