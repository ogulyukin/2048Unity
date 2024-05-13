namespace Game.Events
{
    public struct DestroyEvent : IEvent
    {
        public readonly int Position;
        public readonly float DestroyTimeout;

        public DestroyEvent(int position, float destroyTimeout)
        {
            Position = position;
            DestroyTimeout = destroyTimeout;
        }
    }
}
