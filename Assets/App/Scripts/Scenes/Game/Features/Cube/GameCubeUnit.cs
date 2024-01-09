using UnityEngine;

namespace App.Scripts.Features.Cube
{
    public class GameCubeUnit
    {
        public ModelGameCube CubeModel { get; }
        public ViewGameCubeUnit View { get; private set; }
        public Vector2Int CellPosition { get; set; }

        public GameCubeUnit(ModelGameCube cubeModel)
        {
            CubeModel = cubeModel;
        }

        public void UpdateView(ViewGameCubeUnit viewGameCubeUnit)
        {
            View = viewGameCubeUnit;
        }
    }
}