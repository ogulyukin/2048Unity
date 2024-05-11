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
    public sealed class RiseValueHandler : BaseHandler<RiseValueEvent>
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly VisualPipeline _visualPipeline;
        
        public RiseValueHandler(EventBus eventBus, FieldStorageView fieldStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _fieldStorageView = fieldStorageView;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(RiseValueEvent evt)
        {
            _visualPipeline.AddTask(new RiseCubeValueVisualTask(_fieldStorageView, evt.Position, evt.Value));
        }
    }
}
