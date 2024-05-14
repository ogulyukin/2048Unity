using System;
using JetBrains.Annotations;
using UI;

namespace Game.Control
{
    public enum UserCommands
    {
        Left, Right, Up, Down
    }
    [UsedImplicitly]
    public sealed class InputController : IDisposable
    {
        private readonly GameState _gameState;
        private readonly ButtonControllerView _buttonControllerView;
        public Action<UserCommands> OnUserCommand;

        public InputController(GameState gameState, ButtonControllerView buttonControllerView)
        {
            _gameState = gameState;
            _buttonControllerView = buttonControllerView;
            _buttonControllerView.ButtonUp.AddListener(OnUPButtonPressed);
            _buttonControllerView.ButtonDown.AddListener(OnDownButtonPressed);
            _buttonControllerView.ButtonRight.AddListener(OnRightButtonPressed);
            _buttonControllerView.ButtonLeft.AddListener(OnLeftButtonPressed);
        }


        private void OnUPButtonPressed()
        {
            if (_gameState.CurrentState == States.Started) OnUserCommand?.Invoke(UserCommands.Up);
        }

        private void OnDownButtonPressed()
        {
            if (_gameState.CurrentState == States.Started) OnUserCommand?.Invoke(UserCommands.Down);
        }

        private void OnRightButtonPressed()
        {
            if (_gameState.CurrentState == States.Started) OnUserCommand?.Invoke(UserCommands.Right);
        }

        private void OnLeftButtonPressed()
        {
            if (_gameState.CurrentState == States.Started) OnUserCommand?.Invoke(UserCommands.Left);
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
