using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class ScoreEntryView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dateTimeText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void SetEntryText(string dateTime, string score)
        {
            dateTimeText.text = dateTime;
            scoreText.text = score;
        }
    }
}
