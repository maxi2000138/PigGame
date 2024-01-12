using Zenject;

public class LevelInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelParser>().To<LevelParser>().AsSingle();
        Container.Bind<ICubesParser>().To<CubesParser>().AsSingle();
        Container.Bind<ContainerLevelData>().AsSingle();
        
        Container.Bind<GameCubesGrid>().AsSingle();
        Container.BindInterfacesAndSelfTo<GridLocator>().AsSingle();
    }
}
