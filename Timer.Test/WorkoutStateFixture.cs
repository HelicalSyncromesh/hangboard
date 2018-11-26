using System;
using System.Collections.Generic;
using FluentAssertions;
using Timer.Events;
using Timer.Models;
using Timer.Services;
using Xunit;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

namespace Timer.Test.WorkoutStateFixture
{
    public class given
    {
        private static WorkoutStateService _sut = new WorkoutStateService();

        public class no_events
        {
            private readonly Guid InstanceId = Guid.NewGuid();

            [Fact]
            public void the_workout_is_not_started()
            {
                _sut.StateOf(InstanceId).Should().Be(WorkoutState.NotStarted);
            }
        }
        
        public class a_start_event
        {
            private readonly Guid InstanceId = Guid.NewGuid();

            public a_start_event()
            {
                _sut.Save(new WorkoutStarted
                {
                    InstanceId = InstanceId,
                    Timestamp = DateTime.Now
                });
            }

            [Fact]
            public void the_workout_is_InProgress()
            {
                _sut.StateOf(InstanceId).Should().Be(WorkoutState.InProgress);
            }
        }

        public class a_start_and_end_event
        {
            private readonly Guid InstanceId = Guid.NewGuid();

            public a_start_and_end_event()
            {
                _sut.Save(new WorkoutStarted
                {
                    InstanceId = InstanceId,
                    Timestamp = DateTime.Now
                });
                _sut.Save(new ExerciseScored
                {
                    ExerciseId = 1,
                    InstanceId = InstanceId,
                    Score = 10,
                    Timestamp = DateTime.Now
                });
                _sut.Save(new WorkoutCompleted
                {
                    InstanceId = InstanceId,
                    Timestamp = DateTime.Now
                });
            }

            [Fact]
            public void the_workout_is_completed()
            {
                _sut.StateOf(InstanceId).Should().Be(WorkoutState.Completed);
            }
        }

       
    }
}