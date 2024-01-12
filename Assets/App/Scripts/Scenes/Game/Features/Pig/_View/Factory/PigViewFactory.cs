using UnityEngine;
using Zenject;

public class PigViewFactory : IInitializable
{
    private MonoSpawnableObjectPool<ViewPigUnit> _pigPool;
    
    private readonly PigPoolConfig _pigPoolConfig;

    public PigViewFactory(PigPoolConfig pigPoolConfig)
    {
        _pigPoolConfig = pigPoolConfig;
    }
    
    public void Initialize()
    {
        _pigPool = new MonoSpawnableObjectPool<ViewPigUnit>(() => Object.Instantiate(_pigPoolConfig.Prefab), _pigPoolConfig.PoolStartSize, _pigPoolConfig.DisabledItemParent, _pigPoolConfig.ActiveItemParent);
        _pigPool.Initialize();
    }

    public ViewPigUnit CreatePigView() => _pigPool.GetItem();
}
