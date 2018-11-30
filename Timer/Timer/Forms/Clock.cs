using System;
using System.Text;
using Xamarin.Forms;

namespace Timer.Forms
{
    public class Clock : Label
    {
        public void Display(int elapsedTime)
        {
            var time = TimeSpan.FromSeconds(elapsedTime);
            var s = new StringBuilder();
            if (elapsedTime < 0) s.Append('-');
            s.Append(time.ToString(@"m\:ss"));
            Text = s.ToString();
        }

        public void Display(object sender, int elapsedTime)
        {
            Display(elapsedTime);
        }
    }
}