using UnityEngine;

public class CubesParser : ICubesParser
{
    public CubesFileData ParseCubes(string blocksString)
    {
        return JsonUtility.FromJson<CubesFileData>(blocksString);
    }
}