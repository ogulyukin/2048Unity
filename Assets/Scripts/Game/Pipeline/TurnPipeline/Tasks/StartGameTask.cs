using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class StartGameTask : PipelineTask
    {
        private readonly GameState _gameState;
        private readonly EventBus _eventBus;
        private readonly GameScore _gameScore;

        public StartGameTask(GameState gameState, EventBus eventBus, GameScore gameScore)
        {
            _gameState = gameState;
            _eventBus = eventBus;
            _gameScore = gameScore;
        }

        protected override void OnRun()
        {
            if (_gameState.CurrentState == States.Stopped)
            {
                _eventBus.RaiseEvent(new SetupGameFieldEvent());
                _gameState.CurrentState = States.JustStarted;
                _eventBus.RaiseEvent(new CreateNewActiveCubeEvent());
                _gameScore.CurrentScore = -1;
                Debug.Log("Game Started");
            }
            Finish();
        }
    }
}
