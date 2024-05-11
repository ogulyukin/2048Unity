
using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game.Control
{
    public enum UserCommands
    {
        Left, Right, Up, Down
    }
    [UsedImplicitly]
    public sealed class InputController : ITickable
    {
        private readonly GameState _gameState;
        public Action<UserCommands> OnUserCommand;

        public InputController(GameState gameState)
        {
            _gameState = gameState;
        }

        public void Tick()
        {
            if (_gameState.CurrentState == States.Started)
            {
                if(Input.GetKeyUp(KeyCode.LeftArrow)) OnUserCommand?.Invoke(UserCommands.Left);
                if(Input.GetKeyUp(KeyCode.RightArrow)) OnUserCommand?.Invoke(UserCommands.Right);
                if(Input.GetKeyUp(KeyCode.UpArrow)) OnUserCommand?.Invoke(UserCommands.Up);
                if(Input.GetKeyUp(KeyCode.DownArrow)) OnUserCommand?.Invoke(UserCommands.Down);
            }
        }
    }
}
