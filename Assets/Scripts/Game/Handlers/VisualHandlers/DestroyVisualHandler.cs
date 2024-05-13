using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public DestroyVisualHandler(EventBus eventBus, GameObjectsStorageView gameObjectsStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyActiveCubeVisualTask(_gameObjectsStorageView, evt.Position, evt.DestroyTimeout));
        }
    }
}
