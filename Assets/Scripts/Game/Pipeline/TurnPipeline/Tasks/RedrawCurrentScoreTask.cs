using Game.Events;
using JetBrains.Annotations;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class RedrawCurrentScoreTask : PipelineTask
    {
        private readonly GameScore _gameScore;
        private readonly ActiveCubesStorage _activeCubesStorage;
        private readonly EventBus _eventBus;

        public RedrawCurrentScoreTask(GameScore gameScore, ActiveCubesStorage activeCubesStorage, EventBus eventBus)
        {
            _gameScore = gameScore;
            _activeCubesStorage = activeCubesStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            var currentMaxValue = _activeCubesStorage.GetMaxFieldValue();
            if (currentMaxValue != _gameScore.CurrentScore)
            {
                _gameScore.CurrentScore = currentMaxValue;
                _eventBus.RaiseEvent(new RedrawCurrentScoreEvent(currentMaxValue));
            }
            Finish();
        }
    }
}
