using Assets.Scripts.Game.Events;
using Game;
using Game.Pipeline;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public class StartGameTask : PipelineTask
    {
        private readonly GameState _gameState;
        private readonly EventBus _eventBus;

        public StartGameTask(GameState gameState, EventBus eventBus)
        {
            _gameState = gameState;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_gameState.CurrentState == States.Stopped)
            {
                _eventBus.RaiseEvent(new SetupGameFieldEvent());
                _gameState.CurrentState = States.JustStarted;
                _eventBus.RaiseEvent(new CreateNewActiveCubeEvent());
                Debug.Log("Game Started");
            }
            Finish();
        }
    }
}
