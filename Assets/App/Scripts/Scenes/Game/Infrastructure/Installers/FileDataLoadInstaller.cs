using Zenject;

public class FileDataLoadInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ILevelParser>().To<LevelParser>().AsSingle();
        Container.Bind<ICubesParser>().To<CubesParser>().AsSingle();
        Container.Bind<ContainerCubesData>().AsSingle();
    }
}
