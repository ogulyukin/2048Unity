using UI;

namespace Game.Pipeline.TurnVisualPipeline.Tasks
{
    public sealed class CreateNewActiveCubeVisualTask : PipelineTask
    {
        private readonly FieldStorageView _fieldStorageView;
        private readonly int _index;
        private readonly int _value;

        public CreateNewActiveCubeVisualTask(FieldStorageView fieldStorageView, int index, int value)
        {
            _fieldStorageView = fieldStorageView;
            _index = index;
            _value = value;
        }

        protected override void OnRun()
        {
            _fieldStorageView.InstantiateNewActiveCube(_index, _value);
            Finish();
        }
    }
}
