using Assets.Scripts.UI;
using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct CreateNewActiveCubeVisualEvent : IEvent
    {
        public readonly int Index;
        public readonly int Value;
        public readonly FieldStorageView FieldStorageView;

        public CreateNewActiveCubeVisualEvent(int index, int value, FieldStorageView fieldStorageView)
        {
            Index = index;
            FieldStorageView = fieldStorageView;
            Value = value;
        }
    }
}
