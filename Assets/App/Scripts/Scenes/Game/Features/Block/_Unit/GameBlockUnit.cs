using UnityEngine;

namespace App.Scripts.Features.Cube
{
    public class GameBlockUnit
    {
        public CubeType CubeType { get; private set; }
        public ViewGameBlockUnit View { get; private set; }
        public Vector2Int CellPosition { get; set; }
        
        public void UpdateView(ViewGameBlockUnit viewGameBlockUnit, CubeType cubeType)
        {
            View = viewGameBlockUnit;
            CubeType = cubeType;
        }
    }
}