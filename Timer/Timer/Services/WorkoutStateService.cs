using System;
using System.Collections.Generic;
using Timer.Events;

namespace Timer.Services
{
    public class WorkoutStateService
    {
        private readonly Dictionary<Guid, WorkoutState> _states = new Dictionary<Guid, WorkoutState>();

        public WorkoutState StateOf(Guid instanceId)
        {
            return _states.ContainsKey(instanceId) 
                ? _states[instanceId] 
                : WorkoutState.NotStarted;
        }

        public void Save(WorkoutStarted @event)
        {
            _states[@event.InstanceId] = WorkoutState.InProgress;
        }
        
        public void Save(ExerciseScored @event)
        {
            
        }

        public void Save(WorkoutCompleted @event)
        {
            _states[@event.InstanceId] = WorkoutState.Completed;
        }
    }
}