using System.Collections.Generic;
using App.Scripts.Features.Cube;
using UnityEngine;
using Zenject;

public class GameBlocksViewFactory : IInitializable
{
    private Dictionary<CubeType, MonoSpawnableObjectPool<ViewGameBlockUnit>> _cubePools;
    
    private readonly GameBlocksPoolsConfig _gameBlocksPoolsConfig;

    public GameBlocksViewFactory(GameBlocksPoolsConfig gameBlocksPoolsConfig)
    {
        _gameBlocksPoolsConfig = gameBlocksPoolsConfig;
    }

    
    public void Initialize()
    {
        _cubePools = new();
        
        foreach (var poolItem in _gameBlocksPoolsConfig.Pools)
        {
            var objectPool = new MonoSpawnableObjectPool<ViewGameBlockUnit>(() 
                => Object.Instantiate(poolItem.Prefab), poolItem.PoolSize, poolItem.DisabledItemParent, poolItem.ActiveItemParent);
            objectPool.Initialize();
            
            _cubePools.Add(poolItem.CubeType, objectPool);
        }   
    }

    public ViewGameBlockUnit CreateCubeView(CubeType cubeType) => _cubePools[cubeType].GetItem();
}
