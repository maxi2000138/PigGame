using Infrastructure.StateMachine;
using UnityEngine;

public class ConvertDragDataToSlideVectorSystem : ISystem
{
    private readonly ContainerDragsEventData _containerDragsEventData;
    private readonly ContainerDragVector _containerDragVector;
    private readonly ContainerMainCamera _containerMainCamera;

    public ConvertDragDataToSlideVectorSystem(ContainerDragsEventData containerDragsEventData, ContainerDragVector containerDragVector
        , ContainerMainCamera containerMainCamera)
    {
        _containerDragsEventData = containerDragsEventData;
        _containerDragVector = containerDragVector;
        _containerMainCamera = containerMainCamera;
    }
    
    public void Init() { }

    public void Update(float deltaTime, IGameStateMachine gameStateMachine)
    {
        foreach (var eventData in _containerDragsEventData.Items)
        {
            Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition);
            Vector3 projectedDirection = _containerMainCamera.Item.cameraToWorldMatrix * dragVectorDirection;
            projectedDirection.y = 0f;
            
            _containerDragVector.AddItem(new Vector3Data(projectedDirection.normalized));
        }
        
        _containerDragsEventData.Clear();
    }

    public void Cleanup() { }
    
    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        
        Debug.Log(draggedDir);
        return draggedDir;
    }
}
