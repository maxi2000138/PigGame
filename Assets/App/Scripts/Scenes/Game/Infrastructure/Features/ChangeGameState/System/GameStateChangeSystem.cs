using Infrastructure.StateMachine;

public class GameStateChangeSystem : ISystem
{
    private readonly ContainerStateChange _containerStateChange;

    public GameStateChangeSystem(ContainerStateChange containerStateChange)
    {
        _containerStateChange = containerStateChange;
    }
    
    public void Init()
    { }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    {
        foreach (var changeData in _containerStateChange.Items)
        {
            switch (changeData.State)
            {
                case(StateChangeData.ChangeState.Loose):
                    gameStateMachine.Enter<LooseState>();
                    break;
                case(StateChangeData.ChangeState.Win):
                    gameStateMachine.Enter<WinState>();
                    break;
            }
        }
    }

    public void Cleanup()
    { }
}
