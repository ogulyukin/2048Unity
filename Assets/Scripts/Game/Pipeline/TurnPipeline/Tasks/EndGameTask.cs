using Assets.Scripts.Game.Events;
using Game;
using Game.Pipeline;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public class EndGameTask : PipelineTask
    {
        private readonly GameState _gameState;
        private readonly EventBus _eventBus;

        public EndGameTask(GameState gameState, EventBus eventBus)
        {
            _gameState = gameState;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_gameState.CurrentState == States.Stopped)
            {
                _eventBus.RaiseEvent(new EndGameEvent());
                Debug.Log("Game Ended");
            }
            Finish();
        }
    }
}
