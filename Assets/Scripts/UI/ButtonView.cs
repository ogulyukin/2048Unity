using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public sealed class ButtonView : MonoBehaviour
    {
        [FormerlySerializedAs("_button")] [SerializeField] private Button button;

        public void AddListener(UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }
        
        public void RemoveListener(UnityAction callback)
        {
            button.onClick.RemoveListener(callback);
        }
    }
}
