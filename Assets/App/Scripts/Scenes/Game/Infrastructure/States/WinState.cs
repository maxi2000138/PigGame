using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

public class WinState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        Debug.Log("Win");
        
        return UniTask.CompletedTask;
    }
}
