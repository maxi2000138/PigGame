using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContainerLevelData
{
    public Dictionary<Vector2Int, GridCubeData> CubesData { get; private set; }
    public Dictionary<Vector2Int, PlayerData> PlayersData { get; private set; }
    public Vector2Int Size { get; private set; }


    public void SetupLevelData(LevelFileData levelFileData, CubesFileData cubesData)
    {
        int width = levelFileData.layers[0].width;
        int height = levelFileData.layers[0].height;
        
        Dictionary<int, CubeType> cubeTypes = cubesData.tiles.ToDictionary(tile => tile.id, tile 
            => EnumParseExtensions.EnumParse<CubeType>(tile.properties[0].value, true));

        Size = new Vector2Int(width,height);
    
        CubesData = new();
        PlayersData = new();
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                SetBlockItem(levelFileData, width, i,j, cubeTypes);
                SetPlayerItem(levelFileData, width, i,j);
            }
        }
        
    }

    private void SetBlockItem(LevelFileData levelFileData, int width, int i, int j, Dictionary<int, CubeType> cubeTypes)
    {
        int blockKey = levelFileData.layers[0].data[width * i + j];
                
        if(blockKey == 0)
            return;

        GridCubeData gridCubeData = new()
        {
            CubeType = cubeTypes[blockKey-1],
        };
                
        CubesData.Add(new Vector2Int(i,j), gridCubeData);
    }

    private void SetPlayerItem(LevelFileData levelFileData, int width, int i, int j)
    {
        int playerKey = levelFileData.layers[1].data[width * i + j];
                
        if(playerKey == 0)
            return;

        PlayerData playerData = new();
                
        PlayersData.Add(new Vector2Int(i,j), playerData);
    }
}

public class PlayerData
{
    
}

public class GridCubeData
{
    public CubeType CubeType;
}
