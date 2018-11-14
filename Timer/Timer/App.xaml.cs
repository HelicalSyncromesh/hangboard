using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Timer.Models;
using Timer.Services;
using Xamarin.Forms;

namespace Timer
{
	public partial class App : Application
	{
	    public static ScorecardService Scorecard;
	    
	    public App ()
		{
			InitializeComponent();
            Scorecard = new ScorecardService();
			MainPage = new NavigationPage(new MainPage());
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
