using Assets.Scripts.Game.Events;
using Assets.Scripts.Game.Pipeline.TurnVisualPipeline;
using Assets.Scripts.Game.Pipeline.TurnVisualPipeline.Tasks;
using Assets.Scripts.UI;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public DestroyVisualHandler(EventBus eventBus, FieldStorageView fieldStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _fieldStorageView = fieldStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyActiveCubeVisualTask(_fieldStorageView, evt.Position, evt.DestroyTimeout));
        }
    }
}
