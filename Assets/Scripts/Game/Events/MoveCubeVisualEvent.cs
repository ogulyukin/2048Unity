using Game.Events;

namespace Assets.Scripts.Game.Events
{
    public struct MoveCubeVisualEvent : IEvent
    {
        public readonly int CurrentEntity;
        public readonly int TargetEntity;

        public MoveCubeVisualEvent(int currentEntity, int targetEntity)
        {
            CurrentEntity = currentEntity;
            TargetEntity = targetEntity;
        }
    }
}
