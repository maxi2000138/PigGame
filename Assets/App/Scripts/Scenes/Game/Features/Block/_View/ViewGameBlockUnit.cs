using UnityEngine;

public class ViewGameBlockUnit : MonoView
{
    public Vector3 Size => Transform.localScale;
    public Vector2Int CellPosition { get; set; }
}
