public class MoveSystem : ISystem
{
    private readonly ContainerMoveRequest _containerMoveRequest;

    public MoveSystem(ContainerMoveRequest containerMoveRequest)
    {
        _containerMoveRequest = containerMoveRequest;
    }
    
    public void Init()
    { }

    public void Update(float deltaTime)
    {
        foreach (var moveRequest in _containerMoveRequest.Items)
        {
            
        }
    }

    public void Cleanup()
    { }
}
