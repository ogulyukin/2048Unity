using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class MoveCubeVisualHandler : BaseHandler<MoveCubeVisualEvent>
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public MoveCubeVisualHandler(EventBus eventBus, GameObjectsStorageView gameObjectsStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(MoveCubeVisualEvent evt)
        {
            _visualPipeline.AddTask(new MoveActiveCubeVisualTask(_gameObjectsStorageView, evt.CurrentEntity, evt.TargetEntity, evt.Duration));
        }
    }
}
