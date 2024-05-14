using Audio;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class StartGameVisualTask : PipelineTask
    {
        private readonly GameAudio _gameAudio;

        public StartGameVisualTask(GameAudio gameAudio)
        {
            _gameAudio = gameAudio;
        }

        protected override void OnRun()
        {
            _gameAudio.PlayStartGameSound();
            Finish();
        }
    }
}
