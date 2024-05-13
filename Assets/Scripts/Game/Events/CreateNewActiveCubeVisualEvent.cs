using UI;

namespace Game.Events
{
    public struct CreateNewActiveCubeVisualEvent : IEvent
    {
        public readonly int Index;
        public readonly int Value;
        public readonly GameObjectsStorageView _gameObjectsStorageView;

        public CreateNewActiveCubeVisualEvent(int index, int value, GameObjectsStorageView gameObjectsStorageView)
        {
            Index = index;
            _gameObjectsStorageView = gameObjectsStorageView;
            Value = value;
        }
    }
}
