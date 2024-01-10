using UnityEngine;
using Zenject;

public class GridLocator : IInitializable
{
    private Vector3 _cubesSize;
    private Vector3 _pigSize;
    
    private readonly ContainerLevelData _containerLevelData;
    private readonly GridConfig _gridConfig;


    public GridLocator(ContainerLevelData containerLevelData, GridConfig gridConfig)
    {
        _containerLevelData = containerLevelData;
        _gridConfig = gridConfig;
    }

    public void Initialize()
    {
        _cubesSize = _gridConfig.GridCubeSize;
        _pigSize = _gridConfig.GridPigSize;
    }

    public Vector3 GetCubePositionByCell(Vector2Int cellPosition)
    {
        Vector3 middlePoint = new Vector3(_containerLevelData.Size.x / 2f, 0f, _containerLevelData.Size.y / 2f);
        return new Vector3((cellPosition.x + 0.5f) * _cubesSize.x, 0f, ((cellPosition.y + 0.5f)) * _cubesSize.y) - middlePoint * _cubesSize.x;
    }

    public Vector3 GetPigPositionByCell(Vector2Int cellPosition)
    {
        var pigPosition = GetCubePositionByCell(cellPosition);
        pigPosition.y += _pigSize.y / 2 + _cubesSize.y / 2;
        return pigPosition;
    }
    
}
