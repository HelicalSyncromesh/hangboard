using System;
using System.Collections.Generic;
using System.Linq;
using Timer.Events;
using Timer.Models;

namespace Timer.Services
{
    public class ScorecardService
    {
        private readonly Dictionary<Guid, List<WorkoutEvent>> _events;

        public ScorecardService()
        {
            _events = new Dictionary<Guid, List<WorkoutEvent>>();
        }

        public void Save(WorkoutStarted @event)
        {
            _events.Add(@event.InstanceId,new List<WorkoutEvent>{@event});
        }

        public void Save(ExerciseScored @event)
        {
            _events[@event.InstanceId].Add(@event);
        }

        public void Save(WorkoutCompleted @event)
        {
            _events[@event.InstanceId].Add(@event);
        }

        public Scorecard Load(Guid instanceId)
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
                Scores = scores.ToDictionary(x => x.ExerciseId, x => new Result {ExerciseId = x.ExerciseId, QuantityCompleted = x.Score, ScoredAt = x.Timestamp})
            };

            return result;
        }
    }
}