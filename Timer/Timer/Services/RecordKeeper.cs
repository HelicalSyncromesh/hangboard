using System;
using System.Collections.Generic;
using Timer.Events;
using Timer.Models;

namespace Timer.Services
{
    public class RecordKeeper
    {
        private const string AccessKey = "exercise_best_last_scores";

        private readonly Dictionary<int, History> _recordBook;

        public RecordKeeper(IDictionary<string, object> properties)
        {
            if (!properties.ContainsKey(AccessKey))
            {
                properties.Add(AccessKey, new Dictionary<int,History>(80));
            }

            _recordBook = (Dictionary<int, History>)properties[AccessKey];
        }
        public History Load(int exerciseId)
        {
            return _recordBook.ContainsKey(exerciseId) ?
                _recordBook[exerciseId]
                    : new History(0,DateTime.MinValue,0,DateTime.MinValue);
        }

        public void Save(ExerciseScored e)
        {
            if (!_recordBook.ContainsKey(e.ExerciseId))
            {
                _recordBook.Add(e.ExerciseId, new History(
                    e.Score,
                    e.Timestamp,
                    e.Score,
                    e.Timestamp));
                return;
            }

            var currentHistory = _recordBook[e.ExerciseId];
            if (e.Score>currentHistory.Best)
            {
                _recordBook[e.ExerciseId] = new History(
                    e.Score,
                    e.Timestamp,
                    e.Score,
                    e.Timestamp);
            }
            else
            {
                _recordBook[e.ExerciseId] = new History(
                    e.Score,
                    e.Timestamp,
                    currentHistory.Best,
                    currentHistory.DateOfBest);
            }
        }
    }
}