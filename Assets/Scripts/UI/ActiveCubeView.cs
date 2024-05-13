using DG.Tweening;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    [UsedImplicitly]
    public sealed class ActiveCubeView : MonoBehaviour
    {
        [FormerlySerializedAs("_cubeText")] [SerializeField] private TextMeshProUGUI cubeText;
        [FormerlySerializedAs("_panel")] [SerializeField] private UnityEngine.UI.Image panel;
        private Vector3 _originalScale;

        private void OnEnable()
        {
            _originalScale = transform.localScale;
        }
        public void SetCubeText(string newText)
        {
            cubeText.text = newText;
        }

        public void SetPanelColor(Color color)
        {
            panel.color = color;
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
