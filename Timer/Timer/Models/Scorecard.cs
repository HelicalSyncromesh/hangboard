using System;
using System.Collections.Generic;
using System.Text;

namespace Timer.Models
{
    public class Scorecard
    {
        public int WorkoutId { get; set; }
        public Guid InstanceId { get; set; }
        public DateTime WorkoutStarted { get; set; }
        public DateTime WorkoutEnded { get; set; }
        public Dictionary<int,Result> Scores { get; set; }

        public override string ToString()
        {
            var s = new StringBuilder()
                .AppendLine(WorkoutId.ToString())
                .AppendLine(InstanceId.ToString())
                .AppendLine(WorkoutStarted.ToString())
                .AppendLine(WorkoutEnded.ToString());
            foreach (var score in Scores)
            {
                s.AppendLine(score.ToString());
            }

            return s.ToString();
        }
    }
}
