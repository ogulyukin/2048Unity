using JetBrains.Annotations;
using UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [UsedImplicitly]
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private ButtonView _startGameButton;
        [SerializeField] private ButtonView _scoreButton;
        [SerializeField] private ButtonView _exitGameButton;
        [SerializeField] private ButtonView _exitGameButton2;

        public ButtonView ExitGameButton2 => _exitGameButton2;

        public ButtonView StartGameButton => _startGameButton;

        public ButtonView ScoreButton => _scoreButton;

        public ButtonView ExitGameButton => _exitGameButton;

        public void SetMainMenuActiveness(bool activeness)
        {
            _mainMenu.SetActive(activeness);
            _exitGameButton2.gameObject.SetActive(!activeness);
        }
        
        private void OnEnable()
        {
            SetMainMenuActiveness(true);
        }
    }
}
