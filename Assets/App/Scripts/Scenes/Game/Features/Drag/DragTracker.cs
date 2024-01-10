using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DragTracker : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private ContainerDragsEventData _containerDragsEventData;

    [Inject]
    private void Construct(ContainerDragsEventData containerDragsEventData)
    {
        _containerDragsEventData = containerDragsEventData;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _containerDragsEventData.AddItem(eventData);
    }
    
    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }
}