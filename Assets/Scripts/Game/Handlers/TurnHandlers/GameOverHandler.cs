using Game.Events;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public class GameOverHandler : BaseHandler<GameOverEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        private readonly EndGamePanelView _endGamePanelView;
        private readonly GameScore _gameScore;
        private readonly GameState _gameState;
        private readonly ScoreHistory _scoreHistory;
        
        public GameOverHandler(EventBus eventBus, VisualPipeline visualPipeline, EndGamePanelView endGamePanelView, GameScore gameScore, GameState gameState, 
        ScoreHistory scoreHistory) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _endGamePanelView = endGamePanelView;
            _gameScore = gameScore;
            _gameState = gameState;
            _scoreHistory = scoreHistory;
        }

        protected override void HandleEvent(GameOverEvent evt)
        {
            _visualPipeline.AddTask(new GameOverVisualTask(_endGamePanelView, _gameScore));
            _gameState.CurrentState = States.GameOver;
            _scoreHistory.AddResult(_gameScore.CurrentScore);
        }
    }
}
