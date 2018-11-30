using System;
using System.Text;
using Timer.Models;
using Xamarin.Forms;

namespace Timer.Forms
{
    public class PreviousResults : Label
    {
        public PreviousResults(History history)
        {
            Display(history);
        }

        public void Display(History history)
        {
            var s = new StringBuilder();

            switch (history)
            {
                case HistoryNeverCompleted h:
                    s.Append("Previous Result: ")
                        .Append("N/A")
                        .Append(" | Best: ")
                        .Append("N/A");
                    break;
                case History h:
                    s.Append("Previous Result: ")
                        .Append(history.Last)
                        .Append(" | Best: ")
                        .Append(history.Best)
                        .Append(" | Date of Best: ")
                        .Append(history.DateOfBest.ToShortDateString());
                    break;
            }


            Text = s.ToString();
        }
    }
}