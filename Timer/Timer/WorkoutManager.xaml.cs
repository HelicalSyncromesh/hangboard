using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Timer.Events;
using Timer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Timer
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WorkoutManager : ContentPage
	{
	    private WorkoutDefinition _definition;
	    private int _currentExercise;
	    private int _timerValue;
	    private Guid _instanceId;

	    public event EventHandler<int> Tick;

	    public WorkoutManager(int workoutId)
	    {
	        _currentExercise = 0;
	        _timerValue = -20;
	        _definition = App.Workouts.Load(workoutId);
	        _instanceId = Guid.NewGuid();

            InitializeComponent();
	    }

        protected override async void OnAppearing()
	    {
	        if (App.WorkoutState.StateOf(_instanceId)==WorkoutState.NotStarted)
	        {
                Device.StartTimer(TimeSpan.FromSeconds(1),OnSystemTimerTick);
	            App.Handle(new WorkoutStarted
	            {
                    InstanceId = _instanceId,
                    Timestamp = DateTime.Now,
                    WorkoutId = _definition.Id
	            });

	            await PushNextExerciseModal();
	            return;
	        }

	        _currentExercise++;
	        
	        if (_currentExercise == _definition.ExerciseDefinitions.Count)
	        {
                App.Handle(new WorkoutCompleted
                {
                    InstanceId = _instanceId,
                    Timestamp = DateTime.Now
                });

	            DisplayResults(App.Scorecard.Load(_instanceId));
	            return;
	        }

	        await PushNextExerciseModal();
	    }

	    private async Task PushNextExerciseModal()
	    {
	        var page = new ExercisePage(_instanceId, _definition.ExerciseDefinitions[_currentExercise]);
	        page.Appearing += (sender, args) => Tick += page.Clock.Display;
	        page.Disappearing += (sender, args) => Tick -= page.Clock.Display;

	        await Navigation.PushModalAsync(page);
	    }

	    private void DisplayResults(Scorecard scorecard)
        {
            var button = new Button
            {
                Text = "Return to Home"
            };
            button.Clicked += async (sender, args) => await Navigation.PopModalAsync();
            
            Content = 
            new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = scorecard.ToString()
                    },
                    button
                }
            };
        }
        

	    public bool OnSystemTimerTick()
	    {
	        _timerValue++;
	        OnTick(_timerValue);

	        return App.WorkoutState.StateOf(_instanceId) != WorkoutState.Completed;
	    }

	    protected void OnTick(int arg)
	    {
	        var handler = Tick; //in this one specific scenario handler ends up being a copy of Tick, not a reference.

	        handler?.Invoke(this, arg); //we invoke our subscribers from the copy so we don't collide with subscribe/unsubscribe activity
	    }
	}
}