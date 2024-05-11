using Assets.Scripts.Game.Events;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveDownHandler : BaseHandler<MoveDownEvent>
    {
        private readonly FieldsStorage _fieldsStorage;
        
        public MoveDownHandler(EventBus eventBus, FieldsStorage fieldsStorage) : base(eventBus)
        {
            _fieldsStorage = fieldsStorage;
        }

        protected override void HandleEvent(MoveDownEvent evt)
        {
            var step = 1;
            for (var i = 8; i >= 0 ; i -= 4)
            {
                var maxJ = i + 4;
                for (var j = i; j < maxJ; j += 1)
                {
                    var currentCubeValue = _fieldsStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeDown(j, step);
                        if (moveResult.Item1 != j)
                        {
                            _fieldsStorage.MoveEntity(j, moveResult.Item1);
                            EventBus.RaiseEvent(new MoveCubeVisualEvent(j, moveResult.Item1));
                        }
                        if (moveResult.Item2 >= 0)
                        {
                            ProceedCollision(moveResult.Item1, moveResult.Item2);
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
                var downValue = _fieldsStorage.GetFieldEntityValue(checkedPos);
                if (downValue != 0)
                {
                    return (checkedPos - 4, _fieldsStorage.GetFieldEntityValue(position) == downValue ? checkedPos : -1);
                }
            }

            return (checkedPos, -1);
        }
        
        private void ProceedCollision(int source, int target)
        {
            _fieldsStorage.ClearEntity(source);
            EventBus.RaiseEvent(new DestroyEvent(source));
            EventBus.RaiseEvent(new RiseValueEvent(target, _fieldsStorage.RiseEntityValue(target)));
        }
    }
}
