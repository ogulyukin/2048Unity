using Assets.Scripts.UI;
using Game.Pipeline;

namespace Assets.Scripts.Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class MoveActiveCubeVisualTask : PipelineTask
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly int _currentCube;
        private readonly int _targetCube;
        private readonly float _duration;

        public MoveActiveCubeVisualTask(FieldStorageView fieldStorageView, int currentCube, int targetCube, float duration)
        {
            _fieldStorageView = fieldStorageView;
            _currentCube = currentCube;
            _targetCube = targetCube;
            _duration = duration;
        }

        protected override void OnRun()
        {
            _fieldStorageView.MoveActiveCube(_currentCube, _targetCube, _duration);
            Finish();
        }
    }
}
