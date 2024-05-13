using Game.Events;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class RedrawCurrentScoreHandler : BaseHandler<RedrawCurrentScoreEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly CurrentScoreView _currentScoreView;
        
        public RedrawCurrentScoreHandler(EventBus eventBus, VisualPipeline visualPipeline, CurrentScoreView currentScoreView) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _currentScoreView = currentScoreView;
        }

        protected override void HandleEvent(RedrawCurrentScoreEvent evt)
        {
            _visualPipeline.AddTask(new RedrawCurrentScoreVisualTask(_currentScoreView, evt.CurrentScore));
        }
    }
}
