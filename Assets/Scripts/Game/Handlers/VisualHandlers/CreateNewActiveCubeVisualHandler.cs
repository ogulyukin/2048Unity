using Game.Events;
using Game.Handlers.TurnHandlers;
using Game.Pipeline.TurnVisualPipeline;
using Game.Pipeline.TurnVisualPipeline.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Handlers.VisualHandlers
{
    [UsedImplicitly]
    public class CreateNewActiveCubeVisualHandler : BaseHandler<CreateNewActiveCubeVisualEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public CreateNewActiveCubeVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(CreateNewActiveCubeVisualEvent evt)
        {
            Debug.Log($"Visual handler: {evt.Index}, {evt.Value}");
            _visualPipeline.AddTask(new CreateNewActiveCubeVisualTask(evt.FieldStorageView, evt.Index, evt.Value));
        }
    }
}
