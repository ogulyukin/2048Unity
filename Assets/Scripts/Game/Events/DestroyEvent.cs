using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct DestroyEvent : IEvent
    {
        public readonly int Position;

        public DestroyEvent(int position)
        {
            Position = position;
        }
    }
}
