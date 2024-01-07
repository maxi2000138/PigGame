using UnityEngine;

public class LevelParser : ILevelParser
{
    public LevelFileData ParseLevel(string fileText)
    {
        LevelFileData levelFileData = JsonUtility.FromJson<LevelFileData>(fileText);
        return levelFileData;
    }
}