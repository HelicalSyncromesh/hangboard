using System;
using System.Collections.Generic;
using System.Text;

namespace Timer.Events
{
    public class WorkoutStarted : WorkoutEvent
    {
        public int WorkoutId { get; set; }
    }
}
