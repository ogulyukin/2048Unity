using Assets.Scripts.Game.Events;
using Game;
using Game.Handlers.Turn;
using JetBrains.Annotations;

namespace Assets.Scripts.Game.Handlers.TurnHandlers
{
    [UsedImplicitly]
    public sealed class MoveRightHandler : BaseHandler<MoveRightEvent>
    {
        private readonly FieldsStorage _fieldsStorage;
        
        public MoveRightHandler(EventBus eventBus, FieldsStorage fieldsStorage) : base(eventBus)
        {
            _fieldsStorage = fieldsStorage;
        }

        protected override void HandleEvent(MoveRightEvent evt)
        {
            for (var i = 2; i >= 0; i --)
            {
                var maxJ = i + 13;
                for (var j = i; j < maxJ; j += 4)
                {
                    var currentCubeValue = _fieldsStorage.GetFieldEntityValue(j);
                    if (currentCubeValue > 0)
                    {
                        var moveResult = MoveActiveCubeRight(j, 3 - i);
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
            }
        }
        
        private (int, int) MoveActiveCubeRight(int position, int steps)
        {
            var checkedPos = position;
            for (var i = steps; i > 0; i--)
            {
                checkedPos++;
                var rightValue = _fieldsStorage.GetFieldEntityValue(checkedPos);
                if (rightValue != 0)
                {
                    return (checkedPos - 1, _fieldsStorage.GetFieldEntityValue(position) == rightValue ? checkedPos : -1);
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
