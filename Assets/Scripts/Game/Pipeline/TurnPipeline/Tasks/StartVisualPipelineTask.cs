using Assets.Scripts.Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline;
using JetBrains.Annotations;
using UnityEngine;

namespace Assets.Scripts.Game.Pipeline.TurnPipeline.Tasks
{
    [UsedImplicitly]
    public class StartVisualPipelineTask : PipelineTask
    {
        private readonly VisualPipeline _visualPipeline;

        public StartVisualPipelineTask(VisualPipeline visualPipeline)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void OnRun()
        {
            Debug.Log("Start visual pipeline task");
            _visualPipeline.OnFinished += OnVisualPipelineFinished;
            _visualPipeline.Run();
        }

        protected override void OnFinish()
        {
            _visualPipeline.OnFinished -= OnVisualPipelineFinished;
        }

        private void OnVisualPipelineFinished()
        {
            _visualPipeline.Clear();
            Finish();
        }
    }
}
