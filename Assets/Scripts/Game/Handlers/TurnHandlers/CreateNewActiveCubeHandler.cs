using Game.Events;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class CreateNewActiveCubeHandler : BaseHandler<CreateNewActiveCubeEvent>
    {
        private readonly ActiveCubesStorage _activeCubesStorage;
        private readonly GameObjectsStorageView _gameObjectsStorageView;

        public CreateNewActiveCubeHandler(EventBus eventBus, ActiveCubesStorage activeCubesStorage, GameObjectsStorageView gameObjectsStorageView) : base(eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
            _gameObjectsStorageView = gameObjectsStorageView;
        }

        protected override void HandleEvent(CreateNewActiveCubeEvent evt)
        {
            var fieldIndex = _activeCubesStorage.AddNewRandomValue();
            if (fieldIndex < 0)
            {
                EventBus.RaiseEvent(new GameOverEvent());
            }
            else
            {
                EventBus.RaiseEvent(new CreateNewActiveCubeVisualEvent(fieldIndex, _activeCubesStorage.GetFieldEntityValue(fieldIndex), _gameObjectsStorageView));
            }
        }
    }
}
