using System;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using Zenject;

namespace Game.Control
{
    public enum UserCommands
    {
        Left, Right, Up, Down
    }
    [UsedImplicitly]
    public sealed class InputController : ITickable, IDisposable
    {
        private readonly GameState _gameState;
        private readonly ButtonControllerView _buttonControllerView;
        public Action<UserCommands> OnUserCommand;
        
        private const float CommandTimeout  = 0.5f;
        private float _currentTimeout;

        public InputController(GameState gameState, ButtonControllerView buttonControllerView)
        {
            _gameState = gameState;
            _buttonControllerView = buttonControllerView;
            _buttonControllerView.ButtonUp.AddListener(OnUPButtonPressed);
            _buttonControllerView.ButtonDown.AddListener(OnDownButtonPressed);
            _buttonControllerView.ButtonRight.AddListener(OnRightButtonPressed);
            _buttonControllerView.ButtonLeft.AddListener(OnLeftButtonPressed);
        }
        
        public void Tick()
        {
            if (_currentTimeout > 0)
            {
                _currentTimeout -= Time.deltaTime;
            }
        }

        private void OnUPButtonPressed()
        {
            if (_gameState.CurrentState == States.Started && _currentTimeout <= 0)
            {
                OnUserCommand?.Invoke(UserCommands.Up);
                _currentTimeout = CommandTimeout;
            }
        }

        private void OnDownButtonPressed()
        {
            if (_gameState.CurrentState == States.Started && _currentTimeout <= 0)
            {
                OnUserCommand?.Invoke(UserCommands.Down);
                _currentTimeout = CommandTimeout;
            }
        }

        private void OnRightButtonPressed()
        {
            if (_gameState.CurrentState == States.Started && _currentTimeout <= 0)
            {
                OnUserCommand?.Invoke(UserCommands.Right);
                _currentTimeout = CommandTimeout;
            }
        }

        private void OnLeftButtonPressed()
        {
            if (_gameState.CurrentState == States.Started && _currentTimeout <= 0)
            {
                OnUserCommand?.Invoke(UserCommands.Left);
                _currentTimeout = CommandTimeout;
            }
        }
        public void Dispose()
        {
            _buttonControllerView.ButtonUp.RemoveListener(OnUPButtonPressed);
            _buttonControllerView.ButtonDown.RemoveListener(OnDownButtonPressed);
            _buttonControllerView.ButtonRight.RemoveListener(OnRightButtonPressed);
            _buttonControllerView.ButtonLeft.RemoveListener(OnLeftButtonPressed);
        }
    }
}
