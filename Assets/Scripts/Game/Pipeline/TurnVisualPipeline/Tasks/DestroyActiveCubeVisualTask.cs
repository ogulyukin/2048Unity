using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class DestroyActiveCubeVisualTask : PipelineTask
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly int _targetCube;
        private readonly float _destroyTimeout;

        public DestroyActiveCubeVisualTask(GameObjectsStorageView gameObjectsStorageView, int targetCube, float destroyTimeout)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _targetCube = targetCube;
            _destroyTimeout = destroyTimeout;
        }

        protected override void OnRun()
        {
            _gameObjectsStorageView.DestroyActiveCube(_targetCube, _destroyTimeout);
            Finish();
        }
    }
}
