using Assets.Scripts.Game.Events;
using Assets.Scripts.UI;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public class EndGameHandler : BaseHandler<EndGameEvent>
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly FieldsStorage _fieldsStorage;
        private readonly MainMenuController _mainMenuController;
        
        public EndGameHandler(EventBus eventBus, FieldStorageView fieldStorageView, FieldsStorage fieldsStorage, MainMenuController mainMenuController) : base(eventBus)
        {
            _fieldStorageView = fieldStorageView;
            _fieldsStorage = fieldsStorage;
            _mainMenuController = mainMenuController;
        }

        protected override void HandleEvent(EndGameEvent evt)
        {
            _fieldStorageView.Clear();
            _fieldsStorage.Clear();
            _mainMenuController.EndGame();
        }
    }
}
