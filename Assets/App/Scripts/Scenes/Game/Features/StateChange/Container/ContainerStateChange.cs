public class ContainerStateChange : MultipleContainer<StateChangeData>
{ }

public class StateChangeData
{
    public readonly ChangeState State;

    public StateChangeData(ChangeState state)
    {
        State = state;
    }
    
    public enum ChangeState
    {
        Loose,
        Win,
    }
}