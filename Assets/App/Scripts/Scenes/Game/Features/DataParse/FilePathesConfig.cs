using UnityEngine;

[CreateAssetMenu(menuName = "Configs/FilePathesConfig")]
public class FilePathesConfig : ScriptableObject
{
    [Multiline]
    public string CubesDataPath;
    [Multiline]
    public string LevelsDataPath;
}
