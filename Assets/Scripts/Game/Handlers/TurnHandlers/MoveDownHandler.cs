using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveDownHandler : BaseHandler<MoveDownEvent>
    {
        private readonly ActiveCubesStorage _activeCubesStorage;
        
        public MoveDownHandler(EventBus eventBus, ActiveCubesStorage activeCubesStorage) : base(eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
        }

        protected override void HandleEvent(MoveDownEvent evt)
        {
            var step = 1;
            for (var i = 8; i >= 0 ; i -= 4)
            {
                var maxJ = i + 4;
                for (var j = i; j < maxJ; j += 1)
                {
                    var currentCubeValue = _activeCubesStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeDown(j, step);
                        if (moveResult.Item1 != j)
                        {
                            _activeCubesStorage.MoveEntity(j, moveResult.Item1);
                            EventBus.RaiseEvent(new MoveCubeVisualEvent(j, moveResult.Item1, step));
                        }
                        if (moveResult.Item2 >= 0)
                        {
                            ProceedCollision(moveResult.Item1, moveResult.Item2, step);
                        }
                    }
                }
                step++;
            }
        }
        
        private (int, int) MoveActiveCubeDown(int position, int steps)
        {
            var checkedPos = position;
            for (var i = steps; i > 0; i--)
            {
                checkedPos += 4;
                var downValue = _activeCubesStorage.GetFieldEntityValue(checkedPos);
                if (downValue != 0)
                {
                    return (checkedPos - 4, _activeCubesStorage.GetFieldEntityValue(position) == downValue ? checkedPos : -1);
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
