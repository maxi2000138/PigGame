using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

public class LooseState : IEnterState
{
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        Debug.Log("Loose");
        
        return UniTask.CompletedTask;
    }
}
