using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public sealed class CurrentScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private float animationDuration = 0.15f;
        [SerializeField] private float animationAttitude = 1.5f;

        private Vector3 _originalScale;

        private void OnEnable()
        {
            _originalScale = transform.localScale;
        }

        public void SetScoreText(string score)
        {
            this.scoreText.text = score;
        }

        public void PlayChangeAnimation()
        {
            transform.DOScale(_originalScale * animationAttitude, animationDuration).OnComplete(()=> transform.DOScale(_originalScale, animationDuration));
        }

        public void SetActive(bool activeness)
        {
            gameObject.SetActive(activeness);
        }
    }
}
