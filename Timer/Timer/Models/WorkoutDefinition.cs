using System;
using System.Collections.Generic;
using System.Text;

namespace Timer.Models
{
    public class WorkoutDefinition
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ExerciseDefinition> ExerciseDefinitions { get; set; }
    }
}
