using Game.Events;
using JetBrains.Annotations;
using UI;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class SetupGameFieldHandler : BaseHandler<SetupGameEvent>
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;

        public SetupGameFieldHandler(EventBus eventBus, GameObjectsStorageView gameObjectsStorageView) : base(eventBus)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
        }

        protected override void HandleEvent(SetupGameEvent evt)
        {
            _gameObjectsStorageView.Setup();
        }
    }
}
