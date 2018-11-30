using System;
using System.Collections.Generic;
using FluentAssertions;
using Timer.Forms;
using Timer.Models;
using Xunit;

namespace Timer.Test.ExerciseTitleFixture
{
    public class given
    {
        private ExerciseTitle _sut;

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {new ExerciseDefinition(1,1,true,"hang","Jug (1)"), "1 second hang" };
            yield return new object[] {new ExerciseDefinition(1,10,true,"hang","Jug (1)"),"10 second hang" };
            yield return new object[] {new ExerciseDefinition(1,7,false,"knee raises","Jug (1)"),"7 knee raises" };
            yield return new object[] {new ExerciseDefinition(1,15,false,"pull-ups","Jug (1)"),"15 pull-ups" };
        }

        [Theory, MemberData(nameof(TestData))]
        public void a_history(ExerciseDefinition definition, string correctlyFormatted)
        {
            _sut = new ExerciseTitle(definition);
                
            _sut.Text.Should().Be(correctlyFormatted);
        }
    }
}