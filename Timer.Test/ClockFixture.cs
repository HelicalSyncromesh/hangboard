using System.Collections.Generic;
using FluentAssertions;
using Timer.Forms;
using Xunit;

namespace Timer.Test.ClockFixture
{
    public class given
    {
        private Clock _sut = new Clock();

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {-15,"-0:15" };
            yield return new object[] {0,"0:00" };
            yield return new object[] {15,"0:15" };
            yield return new object[] {65,"1:05" };
            yield return new object[] {605,"10:05" };
        }

        [Theory, MemberData(nameof(TestData))]
        public void an_integer_count_of_seconds(int currentTime, string correctlyFormatted)
        {
            _sut.Display(currentTime);
                
            _sut.Text.Should().Be(correctlyFormatted);
        }
    }
}