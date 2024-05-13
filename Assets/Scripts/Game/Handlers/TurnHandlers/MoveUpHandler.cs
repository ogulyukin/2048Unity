using Game.Events;
using JetBrains.Annotations;

namespace Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveUpHandler : BaseHandler<MoveUpEvent>
    {
        private readonly ActiveCubesStorage _activeCubesStorage;
        
        public MoveUpHandler(EventBus eventBus, ActiveCubesStorage activeCubesStorage) : base(eventBus)
        {
            _activeCubesStorage = activeCubesStorage;
        }

        protected override void HandleEvent(MoveUpEvent evt)
        {
            var step = 1;
            for (var i = 4; i <= 12; i += 4)
            {
                var maxJ = i + 4;
                for (var j = i; j < maxJ; j += 1)
                {
                    var currentCubeValue = _activeCubesStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeUp(j, step);
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
        
        private (int, int) MoveActiveCubeUp(int position, int steps)
        {
            var checkedPos = position;
            for (var i = steps; i > 0; i--)
            {
                checkedPos -= 4;
                var upValue = _activeCubesStorage.GetFieldEntityValue(checkedPos);
                if (upValue != 0)
                {
                    return (checkedPos + 4, _activeCubesStorage.GetFieldEntityValue(position) == upValue ? checkedPos : -1);
                }
            }

            return (checkedPos, -1);
        }

        private void ProceedCollision(int source, int target, float timeout)
        {
            _activeCubesStorage.ClearEntity(source);
            EventBus.RaiseEvent(new DestroyEvent(source, timeout));
            EventBus.RaiseEvent(new RiseValueEvent(target, _activeCubesStorage.RiseEntityValue(target), timeout));
        }
    }
}
