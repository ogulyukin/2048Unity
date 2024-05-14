
using Audio;
using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class GameOverVisualTask : PipelineTask
    {
        private readonly EndGamePanelView _endGamePanelView;
        private readonly GameScore _gameScore;
        private readonly GameAudio _gameAudio;

        public GameOverVisualTask(EndGamePanelView endGamePanelView, GameScore gameScore, GameAudio gameAudio)
        {
            _endGamePanelView = endGamePanelView;
            _gameScore = gameScore;
            _gameAudio = gameAudio;
        }

        protected override void OnRun()
        {
            _endGamePanelView.SetActiveness(true);
           _endGamePanelView.SetFinalScore($" {_gameScore.CurrentScore}"); 
           _gameAudio.PlayGameOverSound();
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
