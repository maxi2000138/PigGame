using Zenject;

public class SystemsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpdateSystemGroup>().AsSingle();
        Container.Bind<FixedUpdateSystemGroup>().AsSingle();
        
        
        BindSystem<DragEnableTrackSystem>();
        BindSystem<ConvertDragDataToSlideVectorSystem>();
        BindSystem<ProcessDragSlideVectorSystem>();
        
        BindSystem<PigMoveSystem>();
        BindSystem<BlockHitSystem>();
        
        BindSystem<PigAnimateMoveSystem>();
        BindSystem<BlockAnimateHitSystem>();
        
        BindSystem<GameStateChangeSystem>();
    }

    private void BindSystem<T>() where T : ISystem => Container.Bind<ISystem>().To<T>().AsSingle();
}
