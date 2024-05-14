using Audio;
using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public sealed class StartGameVisualHandler : BaseHandler<StartGameEvent>
    {
        private readonly GameAudio _gameAudio;
        private readonly VisualPipeline _visualPipeline;
        
        public StartGameVisualHandler(EventBus eventBus, VisualPipeline visualPipeline, GameAudio gameAudio) : base(eventBus)
        {
            _gameAudio = gameAudio;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(StartGameEvent evt)
        {
            _visualPipeline.AddTask(new StartGameVisualTask(_gameAudio));
        }
    }
}
