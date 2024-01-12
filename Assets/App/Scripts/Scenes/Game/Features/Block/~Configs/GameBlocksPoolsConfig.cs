using System;
using System.Collections.Generic;
using UnityEngine;

public class GameBlocksPoolsConfig : MonoConfig
{
    [SerializeField] public List<PoolData> Pools;
}

[Serializable]
public class PoolData
{
    public CubeType CubeType;
    public ViewGameBlockUnit Prefab;
    public int PoolSize;
    public Transform ActiveItemParent;
    public Transform DisabledItemParent;
}
