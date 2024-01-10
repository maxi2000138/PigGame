using UnityEngine;

namespace App.Scripts.Features.Cube
{
    public class GameCubeUnit
    {
        public CubeType CubeType { get; }
        public ViewGameCubeUnit View { get; private set; }
        public Vector2Int CellPosition { get; set; }

        public GameCubeUnit(CubeType cubeType)
        {
            CubeType = cubeType;
        }

        public void UpdateView(ViewGameCubeUnit viewGameCubeUnit)
        {
            View = viewGameCubeUnit;
        }
    }
}