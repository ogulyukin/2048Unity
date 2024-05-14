using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class RaiseCubeValueVisualTask : PipelineTask
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly int _targetCube;
        private readonly int _targetCubeValue;
        private readonly float _actionTimeout;

        public RaiseCubeValueVisualTask(GameObjectsStorageView gameObjectsStorageView, int targetCube, int targetCubeValue, float actionTimeout)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _targetCube = targetCube;
            _targetCubeValue = targetCubeValue;
            _actionTimeout = actionTimeout;
        }

        protected override void OnRun()
        {
            _gameObjectsStorageView.RaiseActiveCubeValue(_targetCube, _targetCubeValue, _actionTimeout);
            Finish();
        }
    }
}
