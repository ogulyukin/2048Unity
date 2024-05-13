using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class CreateNewActiveCubeVisualTask : PipelineTask
    {
        private readonly GameObjectsStorageView _gameObjectsStorageView;
        private readonly int _index;
        private readonly int _value;

        public CreateNewActiveCubeVisualTask(GameObjectsStorageView gameObjectsStorageView, int index, int value)
        {
            _gameObjectsStorageView = gameObjectsStorageView;
            _index = index;
            _value = value;
        }

        protected override void OnRun()
        {
            _gameObjectsStorageView.InstantiateNewActiveCube(_index, _value);
            Finish();
        }
    }
}
