using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public sealed class ButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public void AddListener(UnityAction callback)
        {
            _button.onClick.AddListener(callback);
        }
        
        public void RemoveListener(UnityAction callback)
        {
            _button.onClick.RemoveListener(callback);
        }
    }
}
