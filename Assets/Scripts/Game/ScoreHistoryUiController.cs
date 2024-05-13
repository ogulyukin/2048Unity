using System;
using JetBrains.Annotations;
using UI;

namespace Game
{
    [UsedImplicitly]
    public sealed class ScoreHistoryUiController : IDisposable
    {
        private readonly MainMenuView _mainMenuView;
        private readonly ScoreHistoryView _scoreHistoryView;
        private readonly ScoreHistory _scoreHistory;

        public ScoreHistoryUiController(MainMenuView mainMenuView, ScoreHistoryView scoreHistoryView, ScoreHistory scoreHistory)
        {
            _mainMenuView = mainMenuView;
            _scoreHistoryView = scoreHistoryView;
            _scoreHistory = scoreHistory;
            _mainMenuView.ScoreButton.AddListener(ShowScoreHistory);
        }

        private void ShowScoreHistory()
        {
            _mainMenuView.SetMainMenuActiveness(false);
            _scoreHistoryView.SetActiveness(true);
            _scoreHistoryView.RedrawScoreHistory(_scoreHistory.GetScoreHistory());
            _scoreHistoryView.AddListener(CloseScoreHistory);
        }

        private void CloseScoreHistory()
        {
            _scoreHistoryView.RemoveListener(CloseScoreHistory);
            _scoreHistoryView.SetActiveness(false);
            _mainMenuView.SetMainMenuActiveness(true);
        }

        public void Dispose()
        {
            _mainMenuView.ScoreButton.RemoveListener(ShowScoreHistory);
        }
    }
}
