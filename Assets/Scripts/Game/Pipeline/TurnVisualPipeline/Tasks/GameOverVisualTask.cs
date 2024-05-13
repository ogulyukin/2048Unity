
using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class GameOverVisualTask : PipelineTask
    {
        private readonly EndGamePanelView _endGamePanelView;
        private readonly GameScore _gameScore;

        public GameOverVisualTask(EndGamePanelView endGamePanelView, GameScore gameScore)
        {
            _endGamePanelView = endGamePanelView;
            _gameScore = gameScore;
        }

        protected override void OnRun()
        {
            _endGamePanelView.SetActiveness(true);
           _endGamePanelView.SetFinalScore($" {_gameScore.CurrentScore}"); 
           _endGamePanelView.AddListener(Finish);
        }

        protected override void OnFinish()
        {
            _endGamePanelView.RemoveListener(Finish);
            _endGamePanelView.SetActiveness(false);
            base.OnFinish();
        }
    }
}
