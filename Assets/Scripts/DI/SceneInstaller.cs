using Assets.Scripts.Game;
using Assets.Scripts.Game.Control;
using Assets.Scripts.Game.Handlers.TurnHandlers;
using Assets.Scripts.Game.Handlers.VisualHandlers;
using Assets.Scripts.Game.Pipeline;
using Assets.Scripts.Game.Pipeline.TurnPipeline;
using Assets.Scripts.Game.Pipeline.TurnPipeline.Tasks;
using Assets.Scripts.Game.Pipeline.TurnVisualPipeline;
using Assets.Scripts.Game.Pipeline.TurnVisualPipeline.Tasks;
using Assets.Scripts.UI;
using Game;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.DI
{
    [UsedImplicitly]
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private FieldStorageView _fieldStorageView;
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<MainMenuView>().FromInstance(_mainMenuView);
            Container.Bind<FieldStorageView>().FromInstance(_fieldStorageView);
            Container.Bind<FieldsStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameRunner>().AsSingle();
            Container.Bind<GameState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            HandlersBinding();
            PipelineTasksBinding();
            VisualPipelineBinding();
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
        }

        private void PipelineTasksBinding()
        {
            Container.Bind<TurnPipeline>().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().AsSingle();
            Container.Bind<StartGameTask>().AsSingle();
            Container.Bind<EndGameTask>().AsSingle();
            Container.Bind<EndTurnTask>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerControlTask>().AsSingle();
            Container.Bind<StartVisualPipelineTask>().AsSingle();
        }

        private void VisualPipelineBinding()
        {
            Container.Bind<VisualPipeline>().AsSingle();
            Container.Bind<CreateNewActiveCubeVisualTask>().AsSingle();
        }
    }
}