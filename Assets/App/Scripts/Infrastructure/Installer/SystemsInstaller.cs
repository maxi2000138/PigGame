using UnityEngine;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpdateSystemGroup>().AsSingle();
        Container.Bind<FixedUpdateSystemGroup>().AsSingle();
        
        BindSystem<ConvertDragDataToSlideVectorSystem>();
        BindSystem<ProcessDragSlideVectorSystem>();
        BindSystem<MoveSystem>();
    }

    private void BindSystem<T>() where T : ISystem => Container.Bind<ISystem>().To<T>().AsSingle();
}
