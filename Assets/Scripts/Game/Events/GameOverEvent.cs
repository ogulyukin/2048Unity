namespace Game.Events
{
    public struct GameOverEvent : IEvent
    {
        public readonly bool IsWin;

        public GameOverEvent(bool isWin)
        {
            IsWin = isWin;
        }
    }
}
