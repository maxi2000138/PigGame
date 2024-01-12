using UnityEngine;
using Zenject;

public class DragInstaller : MonoInstaller
{
    [SerializeField] private DragTracker _dragTracker;
    
    public override void InstallBindings()
    {
        Container.Bind<DragTracker>().FromInstance(_dragTracker).AsSingle();

        Container.Bind<ContainerDragsEventData>().AsSingle();
        Container.Bind<ContainerDragVector>().AsSingle();
    }
}
