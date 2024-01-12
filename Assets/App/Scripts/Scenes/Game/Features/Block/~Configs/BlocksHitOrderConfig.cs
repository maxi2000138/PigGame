using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CubesHitOrderConfig")]
public class BlocksHitOrderConfig : ScriptableObject
{
    public List<CubeType> HitOrder;
}
