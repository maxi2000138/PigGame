using Zenject;

public class SpawnObjectsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<GameBlocksFactory>().AsSingle();
        Container.Bind<PigFactory>().AsSingle();
        
        Container.BindInterfacesAndSelfTo<GameBlocksViewFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<PigViewFactory>().AsSingle();
    }
}
