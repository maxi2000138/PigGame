using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameCubesSpawner : IInitializable
{
    private Dictionary<CubeType, MonoSpawnableObjectPool<ViewGameCubeUnit>> _cubePools;
    
    private readonly GameCubePoolsConfig _gameCubePoolsConfig;

    public GameCubesSpawner(GameCubePoolsConfig gameCubePoolsConfig)
    {
        _gameCubePoolsConfig = gameCubePoolsConfig;
    }

    
    public void Initialize()
    {
        _cubePools = new();
        
        foreach (var poolItem in _gameCubePoolsConfig.Pools)
        {
            var objectPool = new MonoSpawnableObjectPool<ViewGameCubeUnit>(() 
                => Object.Instantiate(poolItem.Prefab), poolItem.PoolSize, poolItem.DisabledItemParent, poolItem.ActiveItemParent);
            objectPool.Initialize();
            
            _cubePools.Add(poolItem.CubeType, objectPool);
        }   
    }

    public ViewGameCubeUnit SpawnCube(CubeType cubeType) => _cubePools[cubeType].GetItem();
}
