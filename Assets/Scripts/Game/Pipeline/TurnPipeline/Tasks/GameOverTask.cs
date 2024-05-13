using Game.Events;
using JetBrains.Annotations;

namespace Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public sealed class GameOverTask : PipelineTask
    {
        private readonly ActiveCubesStorage _activeCubesStorage;
        private readonly EventBus _eventBus;

        public GameOverTask(ActiveCubesStorage activeCubesStorage, EventBus eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_activeCubesStorage.GetMaxFieldValue() == 2048)
            {
                _eventBus.RaiseEvent(new GameOverEvent());
            }
            Finish();
        }
    }
}
