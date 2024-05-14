namespace Game.Events
{
    public struct RaiseValueEvent : IEvent
    {
        public readonly int Position;
        public readonly int Value;
        public readonly float ActionTimeout;

        public RaiseValueEvent(int position, int value, float actionTimeout)
        {
            Position = position;
            Value = value;
            ActionTimeout = actionTimeout;
        }
    }
}
