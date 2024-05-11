using System;
using Assets.Scripts.UI;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Pipeline
{
    [UsedImplicitly]
    public sealed class GameRunner: IDisposable
    {

        private readonly TurnPipeline.TurnPipeline _turnPipeline;
        private readonly MainMenuController _mainMenuController;
        private readonly GameState _gameState;
        
        private GameRunner(TurnPipeline.TurnPipeline pipeline, MainMenuController controller, GameState gameState)
        {
            _gameState = gameState;
            _turnPipeline = pipeline;
            _turnPipeline.OnFinished += OnTurnPipelineFinished;
            _mainMenuController = controller;
            _mainMenuController.OnGameStart += StartTurnPipeline;
            _mainMenuController.OnGameFinished += StopTurnPipeline;
        }

        private void StopTurnPipeline()
        {
            _gameState.CurrentState = States.Stopped;
        }

        private void StartTurnPipeline()
        {
            _turnPipeline.Run();
        }

        private void OnTurnPipelineFinished()
        {
            if(_gameState.CurrentState == States.Started) {_turnPipeline.Run();}
        }
        

        public void Dispose()
        {
            _turnPipeline.OnFinished -= OnTurnPipelineFinished;
            _mainMenuController.OnGameStart -= StartTurnPipeline;
            _mainMenuController.OnGameFinished -= StopTurnPipeline;
        }
    }
}
