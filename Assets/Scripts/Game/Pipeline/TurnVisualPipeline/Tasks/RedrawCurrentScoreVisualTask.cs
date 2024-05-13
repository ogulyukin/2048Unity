using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class RedrawCurrentScoreVisualTask : PipelineTask
    {
        private readonly CurrentScoreView _currentScoreView;
        private readonly int _currentScore;
        public RedrawCurrentScoreVisualTask(CurrentScoreView currentScoreView, int currentScore)
        {
            _currentScore = currentScore;
            _currentScoreView = currentScoreView;
        }

        protected override void OnRun()
        {
            _currentScoreView.SetScoreText($"{_currentScore}");
            _currentScoreView.PlayChangeAnimation();
            Finish();
        }
    }
}
