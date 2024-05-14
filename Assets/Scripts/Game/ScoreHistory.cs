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

        public List<(string, string)> GetScoreHistory()
        {
            if (_score.Count <= 10) return GetStringScoreResults(_score);
            var resultList = new List<ScoreEntry>();
            for(var i = 0; i <= 10; i++)
                resultList.Add(_score[i]);
            return GetStringScoreResults(resultList);
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

        private List<(string, string)> GetStringScoreResults(List<ScoreEntry> scores)
        {
            var result = new List<(string, string)>();
            foreach (var score in scores)
            {
                result.Add((score.ScoreValue.ToString(), score.ScoreDateTime));
            }

            return result;
        }
    }
}
