using Cysharp.Threading.Tasks;
using Infrastructure.Installers;
using Infrastructure.StateMachine;
using UnityEngine;

public class FileDataLoadState : IEnterState
{
    private readonly ILevelParser _levelParser;
    private readonly ICubesParser _cubesParser;
    private readonly CubesDataContainer _cubesDataContainer;
    
    private readonly FilePathesConfig _filePathesConfig;

    public FileDataLoadState(ILevelParser levelParser, ICubesParser cubesParser, CubesDataContainer cubesDataContainer
        , FilePathesConfig filePathesConfig)
    {
        _levelParser = levelParser;
        _cubesParser = cubesParser;
        _cubesDataContainer = cubesDataContainer;
        _filePathesConfig = filePathesConfig;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        LoadFileData(1);
        
        gameStateMachine.Enter<GameplayState>();
        return UniTask.CompletedTask;
    }

    public void LoadFileData(int lvl)
    {
        string levelStringData = Resources.Load<TextAsset>(GetLevelPath(lvl)).text;
        string cubesStringData = Resources.Load<TextAsset>(GetCubesPath()).text;

        LevelFileData levelFileData = _levelParser.ParseLevel(levelStringData);
        CubesFileData cubesFileData = _cubesParser.ParseCubes(cubesStringData);
        
        _cubesDataContainer.SetupLevelData(levelFileData, cubesFileData);
    }

    private string GetLevelPath(int lvl) => string.Format(_filePathesConfig.LevelsDataPath, lvl);
    private string GetCubesPath() => _filePathesConfig.CubesDataPath;
}
