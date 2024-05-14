using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class ScoreHistoryView : MonoBehaviour
    {
        [SerializeField] private GameObject scoreEntryPrefab;
        [SerializeField] private Transform parentTransform;
        [SerializeField] private Button closeButton;

        public void RedrawScoreHistory(List<(string, string)> scoreEntries)
        {
            foreach (Transform child in parentTransform)
            {
                Destroy(child.gameObject);
            }

            foreach (var scoreEntry in scoreEntries)
            {
                var entry = Instantiate(scoreEntryPrefab, parentTransform);
                entry.GetComponent<ScoreEntryView>().SetEntryText(scoreEntry.Item1, scoreEntry.Item2);
            }
        }

        public void SetActiveness(bool activeness)
        {
            gameObject.SetActive(activeness);
        }
        
        public void AddListener(UnityAction callback)
        {
            closeButton.onClick.AddListener(callback);
        }
        
        public void RemoveListener(UnityAction callback)
        {
            closeButton.onClick.RemoveListener(callback);
        }
    }
}
