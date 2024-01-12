using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DragTracker : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private ContainerDragsEventData _containerDragsEventData;
    private bool _isEnabled = false;

    [Inject]
    private void Construct(ContainerDragsEventData containerDragsEventData)
    {
        _containerDragsEventData = containerDragsEventData;
    }

    public void Enable()
    {
        _isEnabled = true;
    }

    public void Disable()
    {
        _isEnabled = false;
    }
    
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if(_isEnabled)
            _containerDragsEventData.AddItem(eventData);
    }
    
    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }
}