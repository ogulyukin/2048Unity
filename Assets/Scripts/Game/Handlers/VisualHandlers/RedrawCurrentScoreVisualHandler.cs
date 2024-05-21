using Audio;
using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class RedrawCurrentScoreVisualHandler : BaseHandler<RedrawCurrentScoreEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly CurrentScoreView _currentScoreView;
        private readonly GameAudio _gameAudio;
        
        public RedrawCurrentScoreVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, CurrentScoreView currentScoreView, GameAudio gameAudio) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _currentScoreView = currentScoreView;
            _gameAudio = gameAudio;
        }

        protected override void HandleEvent(RedrawCurrentScoreEvent evt)
        {
            _visualPipeline.AddTask(new RedrawCurrentScoreVisualTask(_currentScoreView, evt.CurrentScore, _gameAudio));
        }
    }
}
