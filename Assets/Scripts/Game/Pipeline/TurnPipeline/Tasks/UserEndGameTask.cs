using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public class UserEndGameTask : PipelineTask
    {
        private readonly GameState _gameState;
        private readonly EventBus _eventBus;

        public UserEndGameTask(GameState gameState, EventBus eventBus)
        {
            _gameState = gameState;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_gameState.CurrentState == States.Stopped || _gameState.CurrentState == States.GameOver)
            {
                _eventBus.RaiseEvent(new EndGameEvent());
                Debug.Log("Game Ended");
            }
            Finish();
        }
    }
}
