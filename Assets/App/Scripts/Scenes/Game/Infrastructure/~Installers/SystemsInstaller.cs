using Infrastructure.Installers;
using Zenject;

public class SystemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpdateSystemGroup>().AsSingle();
        Container.Bind<FixedUpdateSystemGroup>().AsSingle();
        Container.Bind<LateUpdateSystemGroup>().AsSingle();
        
        BindUpdateSystem<DragEnableTrackSystem>();
        BindUpdateSystem<ConvertDragDataToSlideVectorSystem>();
        BindUpdateSystem<ProcessDragSlideVectorSystem>();
        
        BindUpdateSystem<PigMoveSystem>();
        BindUpdateSystem<BlockHitSystem>();
        
        BindUpdateSystem<PigAnimateMoveSystem>();
        BindUpdateSystem<BlockAnimateHitSystem>();
        
        BindUpdateSystem<GameStateChangeSystem>();
    }

    private void BindUpdateSystem<T>() where T : IUpdateSystem => Container.Bind<IUpdateSystem>().To<T>().AsSingle();
}
