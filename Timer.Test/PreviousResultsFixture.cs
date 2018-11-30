using System;
using System.Collections.Generic;
using FluentAssertions;
using Timer.Forms;
using Timer.Models;
using Xunit;

namespace Timer.Test.PreviousResultsFixture
{
    public class given
    {
        private PreviousResults _sut;

        private static DateTime _dayOne = new DateTime(2018,1,1);

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {new HistoryNeverCompleted(),"Previous Result: N/A | Best: N/A" };
            yield return new object[] {new History(1,_dayOne,1,_dayOne),"Previous Result: 1 | Best: 1 | Date of Best: 1/1/2018" };
        }

        [Theory, MemberData(nameof(TestData))]
        public void a_history(History history, string correctlyFormatted)
        {
            _sut = new PreviousResults(history);
                
            _sut.Text.Should().Be(correctlyFormatted);
        }
    }
}