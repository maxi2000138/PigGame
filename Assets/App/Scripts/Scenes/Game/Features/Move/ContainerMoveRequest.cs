using UnityEngine;

public class ContainerMoveRequest : MultipleContainer<MoveRequest>
{ }

public class MoveRequest
{
    public readonly Vector2Int MoveDirection;

    public MoveRequest(Vector2Int moveDirection)
    {
        MoveDirection = moveDirection;
    }
}
