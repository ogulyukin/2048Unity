using Game;
using Game.Control;
using Game.Handlers.TurnHandlers;
using Game.Handlers.VisualHandlers;
using Game.Pipeline;
using Game.Pipeline.TurnPipeline;
using Game.Pipeline.TurnPipeline.Tasks;
using Game.Pipeline.TurnVisualPipeline;
using JetBrains.Annotations;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
    [UsedImplicitly]
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private FieldStorageView fieldStorageView;
        [SerializeField] private CurrentScoreView currentScoreView;
        [SerializeField] private EndGamePanelView endGamePanelView;
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<MainMenuView>().FromInstance(mainMenuView);
            Container.Bind<FieldStorageView>().FromInstance(fieldStorageView);
            Container.Bind<CurrentScoreView>().FromInstance(currentScoreView);
            Container.Bind<EndGamePanelView>().FromInstance(endGamePanelView);
            Container.Bind<FieldsStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameRunner>().AsSingle();
            Container.Bind<GameState>().AsSingle();
            Container.Bind<GameScore>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            HandlersBinding();
            PipelineTasksBinding();
        }

        private void HandlersBinding()
        {
            Container.BindInterfacesAndSelfTo<SetupGameFieldHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<EndGameHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreateNewActiveCubeVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreateNewActiveCubeHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveLeftHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveRightHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveUpHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveDownHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<DestroyVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RiseValueHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveCubeVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RedrawCurrentScoreHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverHandler>().AsSingle();
        }

        private void PipelineTasksBinding()
        {
            Container.Bind<TurnPipeline>().AsSingle();
            Container.Bind<VisualPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
            Container.Bind<StartGameTask>().AsSingle();
            Container.Bind<UserEndGameTask>().AsSingle();
            Container.Bind<EndTurnTask>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerControlTask>().AsSingle();
            Container.Bind<StartVisualPipelineTask>().AsSingle();
            Container.Bind<RedrawCurrentScoreTask>().AsSingle();
            Container.Bind<GameOverTask>().AsSingle();
        }
    }
}