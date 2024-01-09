using Cysharp.Threading.Tasks;
using Infrastructure.StateMachine;
using UnityEngine;

public class SpawnPrefabsState : IEnterState
{
    private readonly ContainerCubesData _containerCubesData;

    public SpawnPrefabsState(ContainerCubesData containerCubesData)
    {
        _containerCubesData = containerCubesData;
    }
    
    public UniTask Enter(IGameStateMachine gameStateMachine)
    {
        foreach (var gridCubeData in _containerCubesData.CubesData)
        {
            
        }
        
        return UniTask.CompletedTask;
    }
}
