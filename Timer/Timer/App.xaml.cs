using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Timer.Events;
using Timer.Models;
using Timer.Services;
using Xamarin.Forms;

namespace Timer
{
	public partial class App : Application
	{
	    public static ScorecardService Scorecard;
	    public static RecordKeeper TopScores;
	    public static WorkoutStateService WorkoutState;
	    
	    public App ()
		{
			InitializeComponent();
            Scorecard = new ScorecardService();
            TopScores = new RecordKeeper(Properties);
            WorkoutState = new WorkoutStateService();
			MainPage = new NavigationPage(new MainPage());
		}

	    public static void Handle(WorkoutEvent e)
	    {
	        switch (e)
	        {
	                case WorkoutStarted @event:
	                    WorkoutState.Save(@event);
                        Scorecard.StartWorkout(@event);
	                    break;
                    case ExerciseScored @event:
                        WorkoutState.Save(@event);
                        Scorecard.Score(@event);
                        TopScores.Save(@event);
                        break;
                    case WorkoutCompleted @event:
                        WorkoutState.Save(@event);
                        Scorecard.EndWorkout(@event);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
	        }
	    }

	    protected override void OnStart ()
		{


        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
