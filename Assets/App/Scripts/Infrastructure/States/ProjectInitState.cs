using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

public class ProjectInitState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        SetupGameFps();
        
        return UniTask.CompletedTask;
    }

    private void SetupGameFps()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }
}
