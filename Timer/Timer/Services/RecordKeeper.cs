using System;
using System.Collections.Generic;
using Timer.Data;
using Timer.Events;
using Timer.Models;

namespace Timer.Services
{
    public class RecordKeeper : IExerciseRecords
    {
        private const string RecordsId = "exercise_records";

        private Dictionary<int, History> _recordBook;

        public RecordKeeper(Dictionary<string,object> properties)
        {
            if (!properties.ContainsKey(RecordsId))
            {
                properties.Add(RecordsId, new Dictionary<int,History>(80));
            }

            _recordBook = (Dictionary<int, History>)properties[RecordsId];
        }
        public History Load(int exerciseId)
        {
            try
            {
                return _recordBook[exerciseId];
            }
            catch (KeyNotFoundException e)
            {
                return new History(0,DateTime.MinValue,0,DateTime.MinValue);
            }
            
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