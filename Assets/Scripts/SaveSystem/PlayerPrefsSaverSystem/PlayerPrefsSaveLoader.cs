using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using SaveSystem.Core;
using UnityEngine;

namespace SaveSystem.PlayerPrefsSaverSystem
{
    [UsedImplicitly]
    public class PlayerPrefsSaveLoader : ISaverLoader
    {
        public void Save(List<Dictionary<string, string>> data, string filename)
        {
            PlayerPrefs.SetInt("204801Saves", data.Count);
            for (var i = 0; i < data.Count; i++)
            {
                PlayerPrefs.SetString($"204801{i}", JsonConvert.SerializeObject(data[i]));
            }
            PlayerPrefs.Save();
        }

        public List<Dictionary<string, string>> Load(string filename)
        {
            var resultList = new List<Dictionary<string, string>>();
            var saveCapacity = PlayerPrefs.GetInt("204801Saves");
            for (int i = 0; i < saveCapacity; i++)
            {
                var dataEntry = PlayerPrefs.GetString($"204801{i}");
                resultList.Add(JsonConvert.DeserializeObject<Dictionary<string, string>>(dataEntry));
            }

            return resultList;
        }
    }
}
