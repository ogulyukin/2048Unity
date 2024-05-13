using Game.Events;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class EndGameHandler : BaseHandler<EndGameEvent>
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly ActiveCubesStorage _activeCubesStorage;
        private readonly MainMenuController _mainMenuController;

        public EndGameHandler(EventBus eventBus, GameObjectsStorageView gameObjectsStorageView, ActiveCubesStorage activeCubesStorage, MainMenuController mainMenuController,
            ScoreHistory scoreHistory) : base(eventBus)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _activeCubesStorage = activeCubesStorage;
            _mainMenuController = mainMenuController;
        }

        protected override void HandleEvent(EndGameEvent evt)
        {
            _gameObjectsStorageView.Clear();
            _activeCubesStorage.Clear();
            _mainMenuController.EndGame();
        }
    }
}
