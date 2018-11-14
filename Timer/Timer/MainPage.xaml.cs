using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Timer
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    
	    private async void OnStartSimpleClicked(object sender, EventArgs e)
	    {
	        await Navigation.PushModalAsync(new WorkoutManager(1));
	    }

	    private void OnHistorySimpleClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private async void OnHistoryBeginnerClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnStartBeginnerClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnStartIntermediateClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnHistoryIntermediateClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnStartAdvancedClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }

	    private void OnHistoryAdvancedClicked(object sender, EventArgs e)
	    {
	        throw new NotImplementedException();
	    }
	}
}
