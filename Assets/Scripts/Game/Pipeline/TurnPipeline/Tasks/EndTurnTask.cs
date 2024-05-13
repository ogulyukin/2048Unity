using Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class EndTurnTask : PipelineTask
    {
        private readonly EventBus _eventBus;
        private readonly GameState _gameState;

        public EndTurnTask(EventBus eventBus, GameState gameState)
        {
            _eventBus = eventBus;
            _gameState = gameState;
        }

        protected override void OnRun()
        {
            Debug.Log("EndTurnTask");
            if (_gameState.CurrentState != States.Stopped)
            {
                _eventBus.RaiseEvent(new CreateNewActiveCubeEvent());
            }
            Finish();
        }
    }
}
