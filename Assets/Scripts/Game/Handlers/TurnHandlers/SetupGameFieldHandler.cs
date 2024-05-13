using Game.Events;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
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
