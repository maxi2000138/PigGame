using System.Collections.Generic;
using System.Linq;
using App.Scripts.Features.Cube;
using Cysharp.Threading.Tasks;
using Infrastructure.Installers;
using Infrastructure.StateMachine;
using UnityEngine;

public class SpawnPrefabsState : IEnterState
{
    private readonly ContainerLevelData _containerLevelData;
    private readonly ContainerPigUnit _containerPigUnit;
    private readonly GameCubesSpawner _gameCubesSpawner;
    private readonly PigSpawner _pigSpawner;
    private readonly GameCubesGrid _gameCubesGrid;
    private readonly GridLocator _gridLocator;

    public SpawnPrefabsState(ContainerLevelData containerLevelData, ContainerPigUnit containerPigUnit, GameCubesSpawner gameCubesSpawner
        , PigSpawner pigSpawner, GameCubesGrid gameCubesGrid, GridLocator gridLocator)
    {
        _containerLevelData = containerLevelData;
        _containerPigUnit = containerPigUnit;
        _gameCubesSpawner = gameCubesSpawner;
        _pigSpawner = pigSpawner;
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
            var pigUnit = CreatePig();
            pigUnit.View.Transform.position = _gridLocator.GetPigPositionByCell(playerData.Key);
        }

    }

    private void SpawnCubes()
    {
        _gameCubesGrid.Resize(_containerLevelData.Size);
        
        foreach (var gridCubeData in _containerLevelData.CubesData)
        {
            var viewGameCubeUnit = CreateCube(gridCubeData);

            viewGameCubeUnit.Transform.position = _gridLocator.GetCubePositionByCell(gridCubeData.Key);
        }
    }

    private ViewGameCubeUnit CreateCube(KeyValuePair<Vector2Int, GridCubeData> gridCubeData)
    {
        ViewGameCubeUnit viewGameCube = _gameCubesSpawner.SpawnCube(gridCubeData.Value.CubeType);
        GameCubeUnit gameCube = new GameCubeUnit(gridCubeData.Value.CubeType);
        gameCube.UpdateView(viewGameCube);
        
        _gameCubesGrid.SetAt(gridCubeData.Key.x, gridCubeData.Key.y, gameCube);
        
        return viewGameCube;
    }

    private PigUnit CreatePig()
    {
        ViewPigUnit viewPigUnit = _pigSpawner.SpawnPig();
        PigUnit pigUnit = new PigUnit();
        pigUnit.UpdateView(viewPigUnit);
        
        _containerPigUnit.SetValue(pigUnit);
        return pigUnit;
    }
}
