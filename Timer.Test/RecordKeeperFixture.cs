using System;
using System.Collections.Generic;
using FluentAssertions;
using Timer.Events;
using Timer.Models;
using Timer.Services;
using Xunit;

namespace Timer.Test.RecordKeeperFixture
{
    public class given
    {
        private IDictionary<string, object> _properties;
        private RecordKeeper _sut;
        private readonly DateTime _dayOne = new DateTime(2018, 1, 1);
        private readonly DateTime _dayTwo = new DateTime(2018, 1, 2);
        private readonly DateTime _dayThree = new DateTime(2018, 1, 3);
        private readonly DateTime _dayFour = new DateTime(2018, 1, 4);
        
        public given()
        {
            _properties = new Dictionary<string, object>();
            _properties.Add("arbitrary","member for testing");

            _sut = new RecordKeeper(_properties);

            _sut.Save(new ExerciseScored
            {
                ExerciseId = 1,
                InstanceId = Guid.NewGuid(),
                Score = 5,
                Timestamp = _dayOne
            });

            _sut.Save(new ExerciseScored
            {
                ExerciseId = 2,
                InstanceId = Guid.NewGuid(),
                Score = 5,
                Timestamp = _dayOne
            });
            _sut.Save(new ExerciseScored
            {
                ExerciseId = 2,
                InstanceId = Guid.NewGuid(),
                Score = 10,
                Timestamp = _dayTwo
            });
            _sut.Save(new ExerciseScored
            {
                ExerciseId = 2,
                InstanceId = Guid.NewGuid(),
                Score = 7,
                Timestamp = _dayThree
            });
            _sut.Save(new ExerciseScored
            {
                ExerciseId = 2,
                InstanceId = Guid.NewGuid(),
                Score = 2,
                Timestamp = _dayFour
            });
        }

        [Fact]
        public void GetHistoryOfExerciseNeverFinished()
        {
            var history = _sut.Load(3);

            history.Should().BeEquivalentTo(new History(0, DateTime.MinValue, 0, DateTime.MinValue));
               
        }

        [Fact]
        public void GetHistoryOfExerciseOnceFinished()
        {
            var history = _sut.Load(1);

            history.Should().BeEquivalentTo(new History(5, _dayOne, 5, _dayOne));
        }

        [Fact]
        public void GetHistoryOfExerciseFinishedALot()
        {
            var history = _sut.Load(2);

            history.Should().BeEquivalentTo(new History(2, _dayFour, 10, _dayTwo));
        }

        [Fact]
        public void ExternalCollectionCorrectlyReferenced()
        {
            (_properties["exercise_best_last_scores"] as Dictionary<int, History>)?[1]
                .Should().NotBeNull();
        }
    }
}