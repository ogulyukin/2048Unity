using Assets.Scripts.Game.Events;
using Assets.Scripts.UI;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public class CreateNewActiveCubeHandler : BaseHandler<CreateNewActiveCubeEvent>
    {
        private readonly FieldsStorage _fieldsStorage;
        private readonly FieldStorageView _fieldStorageView;

        public CreateNewActiveCubeHandler(EventBus eventBus, FieldsStorage fieldsStorage, FieldStorageView fieldStorageView) : base(eventBus)
        {
            _fieldsStorage = fieldsStorage;
            _fieldStorageView = fieldStorageView;
        }

        protected override void HandleEvent(CreateNewActiveCubeEvent evt)
        {
            var fieldIndex = _fieldsStorage.AddNewRandomValue();
            if (fieldIndex < 0)
            {
                EventBus.RaiseEvent(new EndGameEvent());
            }
            else
            {
                EventBus.RaiseEvent(new CreateNewActiveCubeVisualEvent(fieldIndex, _fieldsStorage.GetFieldEntityValue(fieldIndex), _fieldStorageView));
            }
        }
    }
}
