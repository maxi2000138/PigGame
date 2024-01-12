using Infrastructure.StateMachine;
using UnityEngine;

public class PigAnimateMoveSystem : ISystem
{
    private readonly ContainerMoveRequest _containerMoveRequest;
    private readonly ContainerPigUnit _containerPigUnit;
    private readonly GridLocator _gridLocator;

    public PigAnimateMoveSystem(ContainerMoveRequest containerMoveRequest, ContainerPigUnit containerPigUnit
        , GridLocator gridLocator)
    {
        _containerMoveRequest = containerMoveRequest;
        _containerPigUnit = containerPigUnit;
        _gridLocator = gridLocator;
    }
    
    public void Init()
    { }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    {
        foreach (var moveRequest in _containerMoveRequest.Items)
        {
            Vector3 newPigPosition = _gridLocator.GetPigPositionByCell(_containerPigUnit.Item.CellPosition);
            _containerPigUnit.Item.View.AnimateJump(newPigPosition);
        }
        
        _containerMoveRequest.Clear();
    }

    public void Cleanup()
    { }
}
