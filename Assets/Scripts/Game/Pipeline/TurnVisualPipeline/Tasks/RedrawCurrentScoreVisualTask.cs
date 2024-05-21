using Audio;
using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class RedrawCurrentScoreVisualTask : PipelineTask
    {
        private readonly CurrentScoreView _currentScoreView;
        private readonly int _currentScore;
        private readonly GameAudio _gameAudio;
        public RedrawCurrentScoreVisualTask(CurrentScoreView currentScoreView, int currentScore, GameAudio gameAudio)
        {
            _currentScore = currentScore;
            _currentScoreView = currentScoreView;
            _gameAudio = gameAudio;
        }

        protected override void OnRun()
        {
            _currentScoreView.SetScoreText($"{_currentScore}");
            _currentScoreView.PlayChangeAnimation();
            _gameAudio.PlayRaiseScoreSound();
            Finish();
        }
    }
}
