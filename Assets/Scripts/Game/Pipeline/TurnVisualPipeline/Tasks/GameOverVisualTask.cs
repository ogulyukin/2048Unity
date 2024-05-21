
using Audio;
using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class GameOverVisualTask : PipelineTask
    {
        private readonly EndGamePanelView _endGamePanelView;
        private readonly GameScore _gameScore;
        private readonly GameAudio _gameAudio;
        private readonly bool _isPlayerWin;

        public GameOverVisualTask(EndGamePanelView endGamePanelView, GameScore gameScore, GameAudio gameAudio, bool isPlayerWin)
        {
            _endGamePanelView = endGamePanelView;
            _gameScore = gameScore;
            _gameAudio = gameAudio;
            _isPlayerWin = isPlayerWin;
        }

        protected override void OnRun()
        {
            _endGamePanelView.SetActiveness(true);
            _endGamePanelView.SetYouWinText(_isPlayerWin);
            _endGamePanelView.SetGameOverText(!_isPlayerWin);
           _endGamePanelView.SetFinalScore($" {_gameScore.CurrentScore}");
           if (!_isPlayerWin)
           {
               _gameAudio.PlayGameOverSound();
           }
           else
           {
               _gameAudio.PlayWinSound();
           }
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
