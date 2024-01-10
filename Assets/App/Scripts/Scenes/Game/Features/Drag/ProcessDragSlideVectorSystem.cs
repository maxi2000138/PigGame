using UnityEngine;

public class ProcessDragSlideVectorSystem : ISystem
{
    private readonly ContainerDragVector _containerDragVector;
    private readonly ContainerMoveRequest _containerMoveRequest;

    public ProcessDragSlideVectorSystem(ContainerDragVector containerDragVector, ContainerMoveRequest containerMoveRequest)
    {
        _containerDragVector = containerDragVector;
        _containerMoveRequest = containerMoveRequest;
    }
    
    public void Init()
    { }

    public void Update(float deltaTime)
    {
        foreach (var dragVectorData in _containerDragVector.Items)
        {
            Vector3 dragVector = dragVectorData.Vector;
            
            if (Mathf.Abs(dragVector.x) > Mathf.Abs(dragVector.z))
                dragVector.z = 0f;
            else
                dragVector.x = 0f;
            
            dragVector.Normalize();
            
            Vector2Int moveDirection = new Vector2Int((int)dragVector.x, (int)dragVector.z);
            
            Debug.Log(moveDirection);
            _containerMoveRequest.AddItem(new MoveRequest(moveDirection));
        }
        
        _containerDragVector.Clear();
    }

    public void Cleanup()
    { }
}
