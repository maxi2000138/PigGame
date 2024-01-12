using Zenject;

public class PigInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PigFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<PigViewFactory>().AsSingle();

        Container.Bind<ContainerPigUnit>().AsSingle();
        
        Container.Bind<ContainerMoveRequest>().AsSingle();
    }
}
