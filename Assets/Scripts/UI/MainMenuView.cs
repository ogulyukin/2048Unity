using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    [UsedImplicitly]
    public sealed class MainMenuView : MonoBehaviour
    {
        [FormerlySerializedAs("_mainMenu")] [SerializeField] private GameObject mainMenu;
        [FormerlySerializedAs("_startGameButton")] [SerializeField] private ButtonView startGameButton;
        [FormerlySerializedAs("_scoreButton")] [SerializeField] private ButtonView scoreButton;
        [FormerlySerializedAs("_exitGameButton")] [SerializeField] private ButtonView exitGameButton;
        [FormerlySerializedAs("_exitGameButton2")] [SerializeField] private ButtonView exitGameButton2;

        public ButtonView ExitGameButton2 => exitGameButton2;

        public ButtonView StartGameButton => startGameButton;

        public ButtonView ScoreButton => scoreButton;

        public ButtonView ExitGameButton => exitGameButton;

        public void SetMainMenuActiveness(bool activeness)
        {
            mainMenu.SetActive(activeness);
            exitGameButton2.gameObject.SetActive(!activeness);
        }
        
        private void OnEnable()
        {
            SetMainMenuActiveness(true);
        }
    }
}
