using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer.Events;
using Timer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExercisePage : ContentPage
	{
	    private ExerciseDefinition _definition;
	    private readonly Guid _workoutInstance;


	    
	    public ExercisePage(Guid workoutInstance, ExerciseDefinition def)
	    {
	        _definition = def;
	        _workoutInstance = workoutInstance;
	        var exerciseTitle = new Label
	        {
	            Text = ExerciseTitle(def)
	        };

	        var exercisePosition = new Label
	        {
	            Text = def.Hold
	        };

	        var exerciseStats = new Label
	        {
	            Text = "Last: x Best: x"
	        };

	        var clock = new Label
	        {
	            Text = "I AM CLOCK"
	        };

	        var grid = ResultsGrid(def);

	        Title = "Exercise Page in C#";

	        Content = new StackLayout
	        {
	            Children =
	            {
	                exerciseTitle,
	                exercisePosition,
	                exerciseStats,
	                clock,
	                grid
	            }
	        };
	    }

	    private Grid ResultsGrid(ExerciseDefinition exerciseDefinition)
	    {
	        var grid = GridUtility.MakeGrid(1, 5);

	        var currentResult = 1;
	        var currentRow = 0;
	        var currentColumn = 0;
            
	        for (int i = 0; i < exerciseDefinition.Quantity; i++)
	        {
	            if (currentColumn==5) //this row is full, create a new row to fill and set the column back to the left side.
	            {
	                grid.RowDefinitions.Add(GridUtility.StandardRow());
	                currentRow++;
	                currentColumn = 0;
	            }
	            grid.Children.Add(ResultButton(currentResult), currentColumn, currentRow);
	            
	            currentColumn++;
	            currentResult++;
	        }
	        
	        return grid;
	    }

	    private string ExerciseTitle(ExerciseDefinition exerciseDefinition)
	    {
	        var s = new StringBuilder()
	            .Append(exerciseDefinition.Quantity)
	            .Append(' ');
	        
	        if (exerciseDefinition.IsDuration) s.Append("second ");
	        
	        s.Append(exerciseDefinition.Exercise.ToLower());
	        
	        return s.ToString();
	    }



	    private Button ResultButton(int desiredResult)
	    {
	        var button = new Button
	        {
	            Text = desiredResult.ToString()
	        };
	        button.Clicked += async (sender, args) => await OnResultClicked(desiredResult);

	        return button;
	    }

        private async Task OnResultClicked(int result)
        {
            App.Scorecard.Score(new ExerciseScored
            {
                ExerciseId = _definition.Id,
                InstanceId = _workoutInstance,
                Score = result,
                Timestamp = DateTime.Now
            });
            await Navigation.PopModalAsync();
        }
	}


}