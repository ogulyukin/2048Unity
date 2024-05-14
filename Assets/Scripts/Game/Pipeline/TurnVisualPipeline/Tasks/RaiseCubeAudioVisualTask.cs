using Audio;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class RaiseCubeAudioVisualTask : PipelineTask
    {
        private readonly GameAudio _gameAudio;
        private readonly float _playTimeout;

        public RaiseCubeAudioVisualTask(GameAudio gameAudio, float playTimeout)
        {
            _gameAudio = gameAudio;
            _playTimeout = playTimeout;
        }

        protected override void OnRun()
        {
            _gameAudio.PlayRaiseValueSound(_playTimeout);
            Finish();
        }
    }
}
