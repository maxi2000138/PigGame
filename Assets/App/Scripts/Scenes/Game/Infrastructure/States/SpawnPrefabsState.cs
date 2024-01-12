using Cysharp.Threading.Tasks;
using Infrastructure.Installers;
using Infrastructure.StateMachine;

public class SpawnPrefabsState : IEnterState
{
    private readonly ContainerLevelData _containerLevelData;
    private readonly GameBlocksFactory _gameBlocksFactory;
    private readonly PigFactory _pigFactory;
    private readonly GameCubesGrid _gameCubesGrid;
    private readonly GridLocator _gridLocator;

    public SpawnPrefabsState(ContainerLevelData containerLevelData, GameBlocksFactory gameBlocksFactory
        , PigFactory pigFactory, GameCubesGrid gameCubesGrid, GridLocator gridLocator)
    {
        _containerLevelData = containerLevelData;
        _gameBlocksFactory = gameBlocksFactory;
        _pigFactory = pigFactory;
        _gameCubesGrid = gameCubesGrid;
        _gridLocator = gridLocator;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        SpawnCubes();
        SpawnPlayer();

        gameStateMachine.Enter<GameplayState>();
        return UniTask.CompletedTask;
    }

    private void SpawnPlayer()
    {
        foreach (var playerData in _containerLevelData.PlayersData)
        {
            var pigUnit = _pigFactory.CreatePig();
            
            pigUnit.CellPosition = playerData.Key;
            pigUnit.View.Transform.position = _gridLocator.GetPigPositionByCell(playerData.Key);
        }

    }

    private void SpawnCubes()
    {
        _gameCubesGrid.Resize(_containerLevelData.Size);
        
        foreach (var gridCubeData in _containerLevelData.CubesData)
        {
            var gameCubeUnit = _gameBlocksFactory.CreateCube(gridCubeData.Value.CubeType, gridCubeData.Key);

            gameCubeUnit.View.Transform.position = _gridLocator.GetCubePositionByCell(gridCubeData.Key);
            gameCubeUnit.CellPosition = gridCubeData.Key;
        }
    }
}
