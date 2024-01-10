using UnityEngine;
using Zenject;

public class PigSpawner : IInitializable
{
    private readonly PigPoolConfig _pigPoolConfig;
    private MonoSpawnableObjectPool<ViewPigUnit> _pigPool;

    public PigSpawner(PigPoolConfig pigPoolConfig)
    {
        _pigPoolConfig = pigPoolConfig;
    }
    
    public void Initialize()
    {
        _pigPool = new MonoSpawnableObjectPool<ViewPigUnit>(() => Object.Instantiate(_pigPoolConfig.Prefab), _pigPoolConfig.PoolStartSize, _pigPoolConfig.DisabledItemParent, _pigPoolConfig.ActiveItemParent);
        _pigPool.Initialize();
    }
    
    public ViewPigUnit SpawnPig() => _pigPool.GetItem();
}