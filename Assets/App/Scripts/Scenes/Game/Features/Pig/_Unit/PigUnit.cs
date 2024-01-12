using UnityEngine;

public class PigUnit
{ 
    public ViewPigUnit View { get; private set; }
    public Vector2Int CellPosition { get; set; }
    
    public void UpdateView(ViewPigUnit viewPigUnit)
    {
        View = viewPigUnit;
    }
}