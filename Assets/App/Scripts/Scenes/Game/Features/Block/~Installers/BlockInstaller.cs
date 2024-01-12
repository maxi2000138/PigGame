using Zenject;

public class BlockInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameBlocksViewFactory>().AsSingle();

        Container.Bind<ContainerHitBlocks>().AsSingle();
        Container.Bind<GameBlocksFactory>().AsSingle();
    }
}
