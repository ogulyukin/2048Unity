using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveRightHandler : BaseHandler<MoveRightEvent>
    {
        private readonly ActiveCubesStorage _activeCubesStorage;
        
        public MoveRightHandler(EventBus eventBus, ActiveCubesStorage activeCubesStorage) : base(eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
        }

        protected override void HandleEvent(MoveRightEvent evt)
        {
            for (var i = 2; i >= 0; i --)
            {
                var maxJ = i + 13;
                for (var j = i; j < maxJ; j += 4)
                {
                    var currentCubeValue = _activeCubesStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeRight(j, 3 - i);
                        if (moveResult.Item1 != j)
                        {
                            _activeCubesStorage.MoveEntity(j, moveResult.Item1);
                            EventBus.RaiseEvent(new MoveCubeVisualEvent(j, moveResult.Item1, 3 - 1));
                        }
                        if (moveResult.Item2 >= 0)
                        {
                            ProceedCollision(moveResult.Item1, moveResult.Item2, 3 - i);
                        }
                    }
                }
            }
        }
        
        private (int, int) MoveActiveCubeRight(int position, int steps)
        {
            var checkedPos = position;
            for (var i = steps; i > 0; i--)
            {
                checkedPos++;
                var rightValue = _activeCubesStorage.GetFieldEntityValue(checkedPos);
                if (rightValue != 0)
                {
                    return (checkedPos - 1, _activeCubesStorage.GetFieldEntityValue(position) == rightValue ? checkedPos : -1);
                }
            }

            return (checkedPos, -1);
        }
        
        private void ProceedCollision(int source, int target, float timeout)
        {
            _activeCubesStorage.ClearEntity(source);
            EventBus.RaiseEvent(new DestroyEvent(source, timeout));
            EventBus.RaiseEvent(new RaiseValueEvent(target, _activeCubesStorage.RiseEntityValue(target), timeout));
        }
    }
}
