using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [UsedImplicitly]
    public class ActiveCubeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _cubeText;
        [SerializeField] private GameObject _panel;

        public void SetCubeText(string newText)
        {
            _cubeText.text = newText;
        }

        public void SetPanelColor(Color color)
        {
            _panel.GetComponent<Image>().tintColor = color;
        }
    }
}
