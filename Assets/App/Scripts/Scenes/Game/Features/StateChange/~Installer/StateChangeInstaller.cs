using Zenject;

public class StateChangeInstaller : MonoInstaller
{

    public override void InstallBindings()
    {
        Container.Bind<ContainerStateChange>().AsSingle();
    }
}
