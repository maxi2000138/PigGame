using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    [SerializeField] private Camera _mainCamera;
    public override void InstallBindings()
    {
        Container.Bind<ContainerMainCamera>().AsSingle().WithArguments(_mainCamera);
        Container.Bind<ContainerMoveRequest>().AsSingle();
        Container.Bind<GameCubesGrid>().AsSingle();
        Container.BindInterfacesAndSelfTo<GridLocator>().AsSingle();
        Container.Bind<ContainerPigUnit>().AsSingle();
    }
}
