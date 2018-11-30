using System;
using System.Text;
using Timer.Models;
using Xamarin.Forms;

namespace Timer.Forms
{
    public class ExerciseTitle : Label
    {
        public ExerciseTitle(ExerciseDefinition definition)
        {
            Display(definition);
        }

        public void Display(ExerciseDefinition definition)
        {
            var s = new StringBuilder()
                .Append(definition.Quantity)
                .Append(' ');
	        
            if (definition.IsDuration) s.Append("second ");
	        
            s.Append(definition.Exercise.ToLower());
	        
            Text = s.ToString();
        }
    }
}