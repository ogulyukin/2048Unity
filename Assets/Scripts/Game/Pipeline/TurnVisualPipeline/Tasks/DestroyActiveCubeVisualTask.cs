using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class DestroyActiveCubeVisualTask : PipelineTask
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly int _targetCube;
        private readonly float _destroyTimeout;

        public DestroyActiveCubeVisualTask(FieldStorageView fieldStorageView, int targetCube, float destroyTimeout)
        {
            _fieldStorageView = fieldStorageView;
            _targetCube = targetCube;
            _destroyTimeout = destroyTimeout;
        }

        protected override void OnRun()
        {
            _fieldStorageView.DestroyActiveCube(_targetCube, _destroyTimeout);
            Finish();
        }
    }
}
