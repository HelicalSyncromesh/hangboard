using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Timer.Data;
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
	    public static IWorkout Workouts;
	    
	    public App ()
		{
			InitializeComponent();
            Scorecard = new ScorecardService();
            TopScores = new RecordKeeper(Properties);
            WorkoutState = new WorkoutStateService();
            Workouts = new WorkoutRepository();
			MainPage = new NavigationPage(new MainPage());
		}

	    public static void Handle(WorkoutEvent @event)
	    {
	        switch (@event)
	        {
	                case WorkoutStarted e:
	                    WorkoutState.Save(e);
                        Scorecard.Save(e);
	                    break;
                    case ExerciseScored e:
                        WorkoutState.Save(e);
                        Scorecard.Save(e);
                        TopScores.Save(e);
                        break;
                    case WorkoutCompleted e:
                        WorkoutState.Save(e);
                        Scorecard.Save(e);
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
