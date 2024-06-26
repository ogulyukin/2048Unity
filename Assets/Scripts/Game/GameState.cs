using System;
using JetBrains.Annotations;

namespace Game
{
    public enum States
    {
        Started, Stopped, JustStarted, GameOver
    }
    
    [UsedImplicitly]
    public sealed class GameState
    {
        private States _currentState;
        public Action OnValueChanged;

        public States CurrentState
        {
            get => _currentState;
            set {
                    _currentState = value;
                    OnValueChanged?.Invoke();
                }
        }

        public GameState()
        {
            CurrentState = States.Stopped;
        }
    }
}
