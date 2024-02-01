using App.Scripts.Features.Cube;
using Infrastructure.StateMachine;
using UnityEngine;

public class PigMoveSystem : IUpdateSystem
{
    private readonly ContainerMoveRequest _containerMoveRequest;
    private readonly ContainerPigUnit _containerPigUnit;
    private readonly GameCubesGrid _gameCubesGrid;
    private readonly ContainerHitBlocks _containerHitBlocks;
    private readonly ContainerStateChange _containerStateChange;

    public PigMoveSystem(ContainerMoveRequest containerMoveRequest, ContainerPigUnit containerPigUnit, GameCubesGrid gameCubesGrid,
        ContainerHitBlocks containerHitBlocks, ContainerStateChange containerStateChange)
    {
        _containerMoveRequest = containerMoveRequest;
        _containerHitBlocks = containerHitBlocks;
        _containerStateChange = containerStateChange;
        _containerPigUnit = containerPigUnit;
        _gameCubesGrid = gameCubesGrid;
    }

    public void Init()
    { }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    {
        foreach (var moveRequest in _containerMoveRequest.Items)
        {
            Vector2Int newPosition = _containerPigUnit.Item.CellPosition + moveRequest.MoveDirection;
            
            if (_gameCubesGrid.IsValidPosition(newPosition) 
                && _gameCubesGrid.TryGeteAt(newPosition, out var nextCube) 
                && _gameCubesGrid.TryGeteAt(_containerPigUnit.Item.CellPosition, out var currentCube))
            {
                    if (nextCube.CubeType == CubeType.Exit) 
                        _containerStateChange.AddItem(new StateChangeData(StateChangeData.ChangeState.Win));
                    
                    _containerPigUnit.Item.CellPosition = newPosition;
                    _containerHitBlocks.AddItem(currentCube);
                    continue;
            }
            
            _containerMoveRequest.MarkAsDelayedRemove(moveRequest);
        }
        
        _containerMoveRequest.RemoveDelayedItems();
    }

    public void Cleanup()
    { }
}
