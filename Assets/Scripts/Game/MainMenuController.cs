using System;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using UnityEditor;

namespace Game
{
    [UsedImplicitly]
    public sealed class MainMenuController : IDisposable
    {
        private readonly MainMenuView _mainMenuView;
        public Action OnGameStart;
        public Action OnGameFinished;
        private readonly GameState _gameState;
        private readonly CurrentScoreView _currentScoreView;
        private readonly ButtonControllerView _buttonControllerView;

        public MainMenuController(MainMenuView mainMenuView, GameState gameState, CurrentScoreView currentScoreView, ButtonControllerView buttonControllerView)
        {
            _mainMenuView = mainMenuView;
            _gameState = gameState;
            _currentScoreView = currentScoreView;
            _buttonControllerView = buttonControllerView;
            _mainMenuView.StartGameButton.AddListener(BeginGame);
            _mainMenuView.ExitGameButton.AddListener(ExitGame);
            _mainMenuView.ExitGameButton2.AddListener(EndGame);
        }
        
        private void BeginGame()
        {
            _mainMenuView.SetMainMenuActiveness(false);
            _currentScoreView.SetActive(true);
            _buttonControllerView.SetActiveness(true);
            OnGameStart?.Invoke();
        }
        
        private void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit(0);
#endif
        }

        public void EndGame()
        {
            OnGameFinished?.Invoke();
            _gameState.CurrentState = States.Stopped;
            _mainMenuView.SetMainMenuActiveness(true);
            _currentScoreView.SetActive(false);
            _buttonControllerView.SetActiveness(false);
        }

        public void Dispose()
        {
            _mainMenuView.StartGameButton.RemoveListener(BeginGame);
            _mainMenuView.ExitGameButton.RemoveListener(ExitGame);
            _mainMenuView.ExitGameButton2.RemoveListener(ExitGame);
        }
    }
}
