using Assets.Scripts.UI;
using Game.Pipeline;

namespace Assets.Scripts.Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class DestroyActiveCubeVisualTask : PipelineTask
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly int _targetCube;

        public DestroyActiveCubeVisualTask(FieldStorageView fieldStorageView, int targetCube)
        {
            _fieldStorageView = fieldStorageView;
            _targetCube = targetCube;
        }

        protected override void OnRun()
        {
            _fieldStorageView.DestroyActiveCube(_targetCube);
            Finish();
        }
    }
}
