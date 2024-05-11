using Assets.Scripts.UI;
using Game.Pipeline;

namespace Assets.Scripts.Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class RiseCubeValueVisualTask : PipelineTask
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly int _targetCube;
        private readonly int _targetCubeValue;

        public RiseCubeValueVisualTask(FieldStorageView fieldStorageView, int targetCube, int targetCubeValue)
        {
            _fieldStorageView = fieldStorageView;
            _targetCube = targetCube;
            _targetCubeValue = targetCubeValue;
        }

        protected override void OnRun()
        {
            _fieldStorageView.RiseActiveCubeValue(_targetCube, _targetCubeValue);
            Finish();
        }
    }
}
