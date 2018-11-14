using System;
using System.Collections.Generic;
using System.Text;

namespace Timer.Models
{
    public class Score
    {
        public int ExerciseId { get; set; }
        public int QuantityCompleted { get; set; }
        public DateTime ScoredAt { get; set; }

        public override string ToString()
        {
            return $"- {ExerciseId}: {QuantityCompleted} ::{ScoredAt.ToShortDateString()}";
        }
    }
}
