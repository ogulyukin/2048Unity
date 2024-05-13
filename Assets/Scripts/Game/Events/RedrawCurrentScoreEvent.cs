namespace Game.Events
{
    public struct RedrawCurrentScoreEvent : IEvent
    {
        public readonly int CurrentScore;

        public RedrawCurrentScoreEvent(int currentScore)
        {
            CurrentScore = currentScore;
        }
    }
}
