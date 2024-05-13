using Game.Control;
using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class PlayerControlTask : PipelineTask
    {
        private readonly GameState _gameState;
        private readonly InputController _inputController;
        private readonly EventBus _eventBus;

        public PlayerControlTask(GameState gameState, InputController inputController, EventBus eventBus)
        {
            _gameState = gameState;
            _inputController = inputController;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_gameState.CurrentState == States.JustStarted)
            {
                _gameState.CurrentState = States.Started;
                Debug.Log($"PlayerControlTask: skipped");
                Finish();
                return;
            }

            _inputController.OnUserCommand += PlayerKeyPressedListener;
            _gameState.OnValueChanged += AbortTask;
            Debug.Log($"PlayerControlTask: proceed");
        }

        private void AbortTask()
        {
            if (_gameState.CurrentState == States.Stopped)
            {
                _inputController.OnUserCommand -= PlayerKeyPressedListener;
                _gameState.OnValueChanged -= AbortTask;
                Finish();
            }
        }

        private void PlayerKeyPressedListener(UserCommands userCommand)
        {
            if(userCommand == UserCommands.Left)_eventBus.RaiseEvent(new MoveLeftEvent());
            if(userCommand == UserCommands.Right)_eventBus.RaiseEvent(new MoveRightEvent());
            if(userCommand == UserCommands.Up)_eventBus.RaiseEvent(new MoveUpEvent());
            if(userCommand == UserCommands.Down)_eventBus.RaiseEvent(new MoveDownEvent());
            _inputController.OnUserCommand -= PlayerKeyPressedListener;
            Finish();
        }
    }
}
