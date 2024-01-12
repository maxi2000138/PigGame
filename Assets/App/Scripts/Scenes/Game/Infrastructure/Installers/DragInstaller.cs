using Zenject;

public class DragInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ContainerDragsEventData>().AsSingle();
        Container.Bind<ContainerDragVector>().AsSingle();
    }
}
