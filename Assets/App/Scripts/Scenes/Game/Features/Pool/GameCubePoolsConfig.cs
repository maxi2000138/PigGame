using System;
using System.Collections.Generic;
using UnityEngine;

public class GameCubePoolsConfig : MonoConfig
{
    [SerializeField] public List<PoolData> Pools;
}

[Serializable]
public class PoolData
{
    public CubeType CubeType;
    public ViewGameCubeUnit Prefab;
    public int PoolSize;
    public Transform ActiveItemParent;
    public Transform DisabledItemParent;
}
