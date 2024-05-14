using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveLeftHandler : BaseHandler<MoveLeftEvent>
    {
        private readonly ActiveCubesStorage _activeCubesStorage;

        public MoveLeftHandler(EventBus eventBus, ActiveCubesStorage activeCubesStorage) : base(eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
        }
        
        protected override void HandleEvent(MoveLeftEvent evt)
        {
            for (var i = 1; i < 4; i ++)
            {
                var maxJ = i + 13;
                for (var j = i; j < maxJ; j += 4)
                {
                    var currentCubeValue = _activeCubesStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeLeft(j, i);
                        if (moveResult.Item1 != j)
                        {
                            _activeCubesStorage.MoveEntity(j, moveResult.Item1);
                            EventBus.RaiseEvent(new MoveCubeVisualEvent(j, moveResult.Item1, i));
                        }

                        if (moveResult.Item2 >= 0)
                        {
                            ProceedCollision(moveResult.Item1, moveResult.Item2, i);
                        }
                    }
                }
            }
        }
        
        private void ProceedCollision(int source, int target, float timeout)
        {
            _activeCubesStorage.ClearEntity(source);
            EventBus.RaiseEvent(new DestroyEvent(source, timeout));
            EventBus.RaiseEvent(new RaiseValueEvent(target, _activeCubesStorage.RiseEntityValue(target), timeout));
        }

        private (int, int) MoveActiveCubeLeft(int position, int steps)
        {
            var checkedPos = position;
            for (var i = steps; i > 0; i--)
            {
                checkedPos--;
                var leftValue = _activeCubesStorage.GetFieldEntityValue(checkedPos);;
                if (leftValue != 0)
                {
                    return (checkedPos + 1, _activeCubesStorage.GetFieldEntityValue(position) == leftValue ? checkedPos : -1);
                }
            }

            return (checkedPos, -1);
        }
    }
}
