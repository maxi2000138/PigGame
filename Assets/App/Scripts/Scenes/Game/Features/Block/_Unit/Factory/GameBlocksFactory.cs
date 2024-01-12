using App.Scripts.Features.Cube;
using UnityEngine;

public class GameBlocksFactory
{
    
    private readonly GameBlocksViewFactory _gameBlocksViewFactory;
    private readonly GameCubesGrid _gameCubesGrid;

    public GameBlocksFactory(GameBlocksViewFactory gameBlocksViewFactory, GameCubesGrid gameCubesGrid)
    {
        _gameBlocksViewFactory = gameBlocksViewFactory;
        _gameCubesGrid = gameCubesGrid;
    }

    
   
    public GameBlockUnit CreateCube(CubeType cubeType, Vector2Int position)
    {
        ViewGameBlockUnit viewGameBlock = _gameBlocksViewFactory.CreateCubeView(cubeType);
        GameBlockUnit gameBlock = new GameBlockUnit();
        gameBlock.UpdateView(viewGameBlock, cubeType);
        
        _gameCubesGrid.SetAt(position.x, position.y, gameBlock);
        
        return gameBlock;
    }
}
