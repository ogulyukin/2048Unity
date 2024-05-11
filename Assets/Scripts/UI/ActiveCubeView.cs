using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [UsedImplicitly]
    public class ActiveCubeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cubeText;
        [SerializeField] private UnityEngine.UI.Image _panel;
        private Vector3 _originalScale;

        private void OnEnable()
        {
            _originalScale = transform.localScale;
        }
        public void SetCubeText(string newText)
        {
            _cubeText.text = newText;
        }

        public void SetPanelColor(Color color)
        {
            _panel.color = color;
        }

        public void Move(Vector3 position, float duration)
        {
            transform.DOMove(position, duration);
        }

        public void DestroyAnimation(float duration)
        {
            transform.DOScale(Vector3.zero, duration);
        }

        public void ChangeValueAnimation(float duration)
        {
            transform.DOScale(_originalScale * 1.5f, duration).OnComplete(()=> transform.DOScale(_originalScale, duration));
        }
    }
}
