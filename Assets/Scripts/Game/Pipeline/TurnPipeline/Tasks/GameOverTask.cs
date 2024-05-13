using Game.Events;
using JetBrains.Annotations;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public class GameOverTask : PipelineTask
    {
        private readonly FieldsStorage _fieldsStorage;
        private readonly EventBus _eventBus;

        public GameOverTask(FieldsStorage fieldsStorage, EventBus eventBus)
        {
            _fieldsStorage = fieldsStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_fieldsStorage.GetMaxFieldValue() == 2048)
            {
                _eventBus.RaiseEvent(new GameOverEvent());
            }
            Finish();
        }
    }
}
