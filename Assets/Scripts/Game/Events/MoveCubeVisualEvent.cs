using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct MoveCubeVisualEvent : IEvent
    {
        public readonly int CurrentEntity;
        public readonly int TargetEntity;
        public readonly float Duration;

        public MoveCubeVisualEvent(int currentEntity, int targetEntity, float duration)
        {
            CurrentEntity = currentEntity;
            TargetEntity = targetEntity;
            Duration = duration;
        }
    }
}
