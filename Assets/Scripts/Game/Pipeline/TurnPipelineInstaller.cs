using System;
using Assets.Scripts.Game.Pipeline.TurnPipeline.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace Assets.Scripts.Game.Pipeline
{
    [UsedImplicitly]
    public sealed class TurnPipelineInstaller: IInitializable, IDisposable
    {
        private readonly TurnPipeline.TurnPipeline _pipeline;

        private readonly DiContainer _container;

        public TurnPipelineInstaller(DiContainer container, TurnPipeline.TurnPipeline pipeline)
        {
            _container = container;
            _pipeline = pipeline;
        }

        public void Initialize()
        {
            _pipeline.AddTask(_container.Resolve<StartGameTask>());
            _pipeline.AddTask(_container.Resolve<PlayerControlTask>());
            _pipeline.AddTask(_container.Resolve<EndTurnTask>());
            _pipeline.AddTask(_container.Resolve<StartVisualPipelineTask>());
            _pipeline.AddTask(_container.Resolve<EndGameTask>());
        }

        public void Dispose()
        {
            _pipeline.Clear();
        }
    }
}
