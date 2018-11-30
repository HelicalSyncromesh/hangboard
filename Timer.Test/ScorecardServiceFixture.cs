using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using FluentAssertions;
using Timer.Events;
using Timer.Models;
using Timer.Services;
using Xunit;

namespace Timer.Test.ScorecardServiceFixture
{
    public class given
    {
        private ScorecardService _scorecardService { get; set; }
        private Guid _instanceId = Guid.NewGuid();

        public given()
        {
            _scorecardService = new ScorecardService();
            _scorecardService.Save(new WorkoutStarted
            {
                InstanceId = _instanceId,
                WorkoutId = 1,
                Timestamp = new DateTime(2018, 1, 1, 12, 0, 0)
            });
            _scorecardService.Save(new ExerciseScored
            {
                ExerciseId = 1,
                InstanceId = _instanceId,
                Score = 4,
                Timestamp = new DateTime(2018, 1, 1, 12, 1, 0)
            });
            _scorecardService.Save(new WorkoutCompleted
            {
                InstanceId = _instanceId,
                Timestamp = new DateTime(2018, 1, 1, 12, 2, 0)
            });
        }

        [Fact]
        public void Test1()
        {
            var result = _scorecardService.Load(_instanceId);

            result.Should().BeEquivalentTo(new Scorecard
            {
                InstanceId = _instanceId,
                WorkoutId = 1,
                WorkoutStarted = new DateTime(2018, 1, 1, 12, 0, 0),
                WorkoutEnded = new DateTime(2018, 1, 1, 12, 2, 0),
                Scores = new Dictionary<int, Score>
                {
                    {1, new Score {ExerciseId = 1, QuantityCompleted = 4, ScoredAt = new DateTime(2018, 1, 1, 12, 1, 0)}}
                }
            });
        }
    }
}
