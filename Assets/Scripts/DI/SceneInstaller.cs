using Audio;
using Game;
using Game.Control;
using Game.Handlers.TurnHandlers;
using Game.Handlers.VisualHandlers;
using Game.Pipeline;
using Game.Pipeline.TurnPipeline;
using Game.Pipeline.TurnPipeline.Tasks;
using Game.Pipeline.TurnVisualPipeline;
using JetBrains.Annotations;
using SaveSystem.Core;
using SaveSystem.Data;
using SaveSystem.FileSaverSystem;
using SaveSystem.Tools;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DI
{
    [UsedImplicitly]
    public sealed class SceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        [FormerlySerializedAs("fieldStorageView")] [SerializeField] private GameObjectsStorageView gameObjectsStorageView;
        [SerializeField] private CurrentScoreView currentScoreView;
        [SerializeField] private EndGamePanelView endGamePanelView;
        [SerializeField] private ScoreHistoryView scoreHistoryView;
        [SerializeField] private ButtonControllerView buttonControllerView;
        [FormerlySerializedAs("savingSystemHelper")] [SerializeField] private SavingSystemController savingSystemController;
        [SerializeField] private GameAudio gameAudio;
        public override void InstallBindings()
        {
            Container.Bind<EventBus>().AsSingle();
            Container.Bind<MainMenuView>().FromInstance(mainMenuView);
            Container.Bind<GameObjectsStorageView>().FromInstance(gameObjectsStorageView);
            Container.Bind<CurrentScoreView>().FromInstance(currentScoreView);
            Container.Bind<EndGamePanelView>().FromInstance(endGamePanelView);
            Container.Bind<ScoreHistoryView>().FromInstance(scoreHistoryView);
            Container.Bind<ButtonControllerView>().FromInstance(buttonControllerView);
            Container.Bind<GameAudio>().FromInstance(gameAudio);
            Container.Bind<SavingSystemController>().FromInstance(savingSystemController);
            Container.Bind<ActiveCubesStorage>().AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreHistoryUiController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameRunner>().AsSingle();
            Container.Bind<GameState>().AsSingle();
            Container.Bind<GameScore>().AsSingle();
            Container.Bind<ScoreHistory>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
            HandlersBinding();
            PipelineTasksBinding();
            SavingSystemBinding();
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
            Container.BindInterfacesAndSelfTo<RaiseValueHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveCubeVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RedrawCurrentScoreHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameOverHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartGameVisualHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<RaiseValueAudioHandler>().AsSingle();
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

        private void SavingSystemBinding()
        {
            Container.Bind<SavingSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<FileSystemSaverLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreSavingManager>().AsSingle();
        }
    }
}