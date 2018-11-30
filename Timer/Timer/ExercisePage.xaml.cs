using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer.Events;
using Timer.Forms;
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

	    public Clock Clock = new Clock();
        
        public ExercisePage(Guid workoutInstance, ExerciseDefinition def)
	    {
	        _definition = def;
	        _workoutInstance = workoutInstance;
	        
	        var exercisePosition = new Label
	        {
	            Text = def.Hold
	        };

            Title = "Exercise Page in C#";

	        Content = new StackLayout
	        {
	            Children =
	            {
	                new ExerciseTitle(def),
	                new Label{ Text = def.Hold },
	                new PreviousResults(App.TopScores.Load(def.Id)),
	                Clock,
	                ResultsGrid(def)}
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
            App.Handle(new ExerciseScored
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