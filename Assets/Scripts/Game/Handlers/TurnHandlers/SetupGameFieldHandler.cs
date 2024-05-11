using Assets.Scripts.Game.Events;
using Assets.Scripts.UI;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public class SetupGameFieldHandler : BaseHandler<SetupGameFieldEvent>
    {
        private readonly FieldStorageView _fieldStorageView;

        public SetupGameFieldHandler(EventBus eventBus, FieldStorageView fieldStorageView) : base(eventBus)
        {
            _fieldStorageView = fieldStorageView;
        }

        protected override void HandleEvent(SetupGameFieldEvent evt)
        {
            _fieldStorageView.Setup();
        }
    }
}
