using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private DragTracker _dragTracker;
    public override void InstallBindings()
    {
        Container.Bind<DragTracker>().FromInstance(_dragTracker).AsSingle();
        Container.Bind<ContainerMainCamera>().AsSingle().WithArguments(_mainCamera);
        Container.Bind<ContainerMoveRequest>().AsSingle();
        Container.Bind<GameCubesGrid>().AsSingle();
        Container.BindInterfacesAndSelfTo<GridLocator>().AsSingle();
        Container.Bind<ContainerPigUnit>().AsSingle();
        Container.Bind<ContainerHitBlocks>().AsSingle();
        Container.Bind<ContainerStateChange>().AsSingle();
    }
}
