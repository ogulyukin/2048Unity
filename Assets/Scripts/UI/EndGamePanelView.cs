using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class EndGamePanelView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gameOverText;
        [SerializeField] private TextMeshProUGUI youWinText;

        private string _originalScore;

        private void OnEnable()
        {
            _originalScore = scoreText.text;
        }

        public void SetActiveness(bool activeness)
        {
            gameObject.SetActive(activeness);
        }

        public void SetGameOverText(bool activeness)
        {
            gameOverText.gameObject.SetActive(activeness);
        }

        public void SetYouWinText(bool activeness)
        {
            youWinText.gameObject.SetActive(activeness);
        }

        public void SetFinalScore(string score)
        {
            scoreText.text = $"{_originalScore} {score}";
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
