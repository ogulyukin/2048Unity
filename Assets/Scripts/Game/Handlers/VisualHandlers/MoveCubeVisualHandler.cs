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
        private readonly FieldStorageView _fieldStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public MoveCubeVisualHandler(EventBus eventBus, FieldStorageView fieldStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _fieldStorageView = fieldStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(MoveCubeVisualEvent evt)
        {
            _visualPipeline.AddTask(new MoveActiveCubeVisualTask(_fieldStorageView, evt.CurrentEntity, evt.TargetEntity, evt.Duration));
        }
    }
}
