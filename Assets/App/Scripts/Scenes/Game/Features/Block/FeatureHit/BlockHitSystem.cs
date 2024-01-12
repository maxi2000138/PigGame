using Infrastructure.StateMachine;
using UnityEngine;

public class BlockHitSystem : ISystem
{
    private readonly ContainerHitBlocks _containerHitBlocks;
    private readonly BlocksHitOrderConfig _blocksHitOrderConfig;
    private readonly GameBlocksViewFactory _gameBlocksViewFactory;
    private readonly GameCubesGrid _gameCubesGrid;

    public BlockHitSystem(ContainerHitBlocks containerHitBlocks, BlocksHitOrderConfig blocksHitOrderConfig
        , GameBlocksViewFactory gameBlocksViewFactory, GameCubesGrid gameCubesGrid)
    {
        _containerHitBlocks = containerHitBlocks;
        _blocksHitOrderConfig = blocksHitOrderConfig;
        _gameBlocksViewFactory = gameBlocksViewFactory;
        _gameCubesGrid = gameCubesGrid;
    }
    
    public void Init()
    { }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    {
        for(int i = 0; i < _containerHitBlocks.Items.Count; i++)
        {
            var cubeUnit = _containerHitBlocks.Items[i];
            
            if(TryGetNextBlockType(cubeUnit.CubeType,out var nextType))
            {
                ViewGameBlockUnit newGameBlock = _gameBlocksViewFactory.CreateCubeView(nextType);
                newGameBlock.Transform.position = cubeUnit.View.Transform.position;
                cubeUnit.View.Remove();
                cubeUnit.UpdateView(newGameBlock, nextType);
            }
            else
            {
                cubeUnit.View.Remove();
                _gameCubesGrid.RemoveAt(cubeUnit.CellPosition);
            }
        }
        
        _containerHitBlocks.Clear();
    }

    private bool TryGetNextBlockType(CubeType cubeType, out CubeType nextCubeType)
    {
        for (int i = 0; i < _blocksHitOrderConfig.HitOrder.Count; i++)
        {
            if (_blocksHitOrderConfig.HitOrder[i] == cubeType && i+1 < _blocksHitOrderConfig.HitOrder.Count)
            {
                nextCubeType = _blocksHitOrderConfig.HitOrder[i + 1];
                return true;
            }
        }

        nextCubeType = default;
        return false;
    }

    public void Cleanup()
    { }
}
