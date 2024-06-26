using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class RaiseValueHandler : BaseHandler<RaiseValueEvent>
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public RaiseValueHandler(EventBus eventBus, GameObjectsStorageView gameObjectsStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(RaiseValueEvent evt)
        {
            _visualPipeline.AddTask(new RaiseCubeValueVisualTask(_gameObjectsStorageView, evt.Position, evt.Value, evt.ActionTimeout));
        }
    }
}
