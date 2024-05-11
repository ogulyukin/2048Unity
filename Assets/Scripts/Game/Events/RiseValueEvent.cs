using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct RiseValueEvent : IEvent
    {
        public readonly int Position;
        public readonly int Value;
        public readonly float ActionTimeout;

        public RiseValueEvent(int position, int value, float actionTimeout)
        {
            Position = position;
            Value = value;
            ActionTimeout = actionTimeout;
        }
    }
}
