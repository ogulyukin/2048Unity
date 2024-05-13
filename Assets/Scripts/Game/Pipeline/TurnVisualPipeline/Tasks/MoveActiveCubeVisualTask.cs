using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class MoveActiveCubeVisualTask : PipelineTask
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly int _currentCube;
        private readonly int _targetCube;
        private readonly float _duration;

        public MoveActiveCubeVisualTask(GameObjectsStorageView gameObjectsStorageView, int currentCube, int targetCube, float duration)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _currentCube = currentCube;
            _targetCube = targetCube;
            _duration = duration;
        }

        protected override void OnRun()
        {
            _gameObjectsStorageView.MoveActiveCube(_currentCube, _targetCube, _duration);
            Finish();
        }
    }
}
