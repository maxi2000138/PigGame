using Infrastructure.StateMachine;

public class DragEnableTrackSystem : IUpdateSystem
{
    private readonly DragTracker _dragTracker;

    public DragEnableTrackSystem(DragTracker dragTracker)
    {
        _dragTracker = dragTracker;
    }
    
    public void Init()
    {
        _dragTracker.Enable();
    }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    { }

    public void Cleanup()
    {
        _dragTracker.Disable();
    }
}
