using System;
using System.Collections.Generic;
using System.Globalization;
using Game;
using JetBrains.Annotations;
using SaveSystem.Core;
using Unity.VisualScripting;
using UnityEngine;

namespace SaveSystem.Data
{
    [UsedImplicitly]
    public sealed class ScoreSavingManager : ISaveAble
    {
        
        private readonly ScoreHistory _scoreHistory;
        
        public ScoreSavingManager(ScoreHistory scoreHistory)
        {
            _scoreHistory = scoreHistory;
        }
        
        
        public List<Dictionary<string, string>> CaptureState()
        {
            var scores = new List<Dictionary<string, string>>();
            var scoreHistory = _scoreHistory.GetScoreHistory();
            var data = new Dictionary<string, string> {{"SavableType", "ScoreHistory"}};
            foreach (var entry in scoreHistory)
            {
                data.Add(entry.ScoreDateTime, $"{entry.ScoreValue}");
            }
            scores.Add(data);
            return scores;
        }

        public void RestoreState(List<Dictionary<string, string>> loadedData)
        {
            foreach (var data in loadedData)
            {
                if (data["SavableType"] == "ScoreHistory")
                {
                    Debug.Log($"Loaded: {data.Count} entries");
                    foreach (var entry in data)
                    {
                        Debug.Log($"Loaded: {entry.Key} {entry.Value}");
                        if(entry.Key == "SavableType") continue;
                        _scoreHistory.AddResult(Int32.Parse(entry.Value), entry.Key);
                    }
                }
            }
        }
    }
}
