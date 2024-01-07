using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubesDataContainer
{
    public Dictionary<Vector2Int, GridCubeData> CubesData { get; private set; }
    public Vector2Int Size { get; private set; }


    public void SetupLevelData(LevelFileData levelFileData, CubesFileData cubesData)
    {
        int width = levelFileData.layers[0].width;
        int height = levelFileData.layers[0].height;
        
        Dictionary<int, CubeType> cubeTypes = cubesData.tiles.ToDictionary(tile => tile.id, tile 
            => EnumParseExtensions.EnumParse<CubeType>(tile.properties[0].value, true));

        Size = new Vector2Int(width,height);
    
        CubesData = new();
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                int blockKey = levelFileData.layers[0].data[width * i + j];
                
                if(blockKey == 0)
                    continue;

                GridCubeData gridCubeData = new()
                {
                    CubeType = cubeTypes[blockKey-1],
                };
                
                CubesData.Add(new Vector2Int(j,i), gridCubeData);
            }
        }
    }
}

public class GridCubeData
{
    public CubeType CubeType;
}
