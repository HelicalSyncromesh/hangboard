using System;

namespace Timer.Events
{
    public abstract class WorkoutEvent
    {
        public Guid InstanceId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}