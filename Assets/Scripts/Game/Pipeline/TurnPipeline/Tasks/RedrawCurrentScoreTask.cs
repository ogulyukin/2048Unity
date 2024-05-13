using Game.Events;
using JetBrains.Annotations;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class RedrawCurrentScoreTask : PipelineTask
    {
        private readonly GameScore _gameScore;
        private readonly FieldsStorage _fieldsStorage;
        private readonly EventBus _eventBus;

        public RedrawCurrentScoreTask(GameScore gameScore, FieldsStorage fieldsStorage, EventBus eventBus)
        {
            _gameScore = gameScore;
            _fieldsStorage = fieldsStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            var currentMaxValue = _fieldsStorage.GetMaxFieldValue();
            if (currentMaxValue != _gameScore.CurrentScore)
            {
                _gameScore.CurrentScore = currentMaxValue;
                _eventBus.RaiseEvent(new RedrawCurrentScoreEvent(currentMaxValue));
            }
            Finish();
        }
    }
}
