using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct RiseValueEvent : IEvent
    {
        public readonly int Position;
        public readonly int Value;

        public RiseValueEvent(int position, int value)
        {
            Position = position;
            Value = value;
        }
    }
}
