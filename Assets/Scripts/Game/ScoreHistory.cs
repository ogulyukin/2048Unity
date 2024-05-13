using System;
using System.Collections.Generic;
using System.Globalization;
using JetBrains.Annotations;

namespace Game
{
    [UsedImplicitly]
    public sealed class ScoreEntry
    {
        public int ScoreValue;
        public string ScoreDateTime;
    }
    
    [UsedImplicitly]
    public sealed class ScoreHistory
    {
        private readonly List<ScoreEntry> _score = new();

        public List<ScoreEntry> GetScoreHistory()
        {
            if (_score.Count <= 10) return _score;
            var resultList = new List<ScoreEntry>();
            for(var i = 0; i <= 10; i++)
                resultList.Add(_score[i]);
            return resultList;
        }

        public void AddResult(int score, string dateTime)
        {
            for (var i = 0; i < _score.Count; i++)
            {
                if(_score[i].ScoreValue > score)
                    continue;
                _score.Insert(i, new ScoreEntry(){ScoreDateTime = dateTime, ScoreValue = score});
                return;
            }
            _score.Add(new ScoreEntry(){ScoreDateTime = dateTime, ScoreValue = score});
        }
        public void AddResult(int score)
        {
            AddResult(score, DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }
    }
}
