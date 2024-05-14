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
    public sealed class RaiseValueAudioHandler : BaseHandler<RaiseValueEvent>
    {
        private readonly GameAudio _gameAudio;
        private readonly float _timeoutCoefficient;
        private readonly VisualPipeline _visualPipeline;
        
        public RaiseValueAudioHandler(EventBus eventBus, GameAudio gameAudio, GameObjectsStorageView gameObjectsStorageView, VisualPipeline visualPipeline) : base(eventBus)
        {
            _gameAudio = gameAudio;
            _timeoutCoefficient = gameObjectsStorageView.ActionCoefficient;
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(RaiseValueEvent evt)
        {
            _visualPipeline.AddTask(new RaiseCubeAudioVisualTask(_gameAudio, evt.ActionTimeout * _timeoutCoefficient));
        }
    }
}
