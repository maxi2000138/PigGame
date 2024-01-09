using System.Collections.Generic;

public class ContainerDrags
{
    private readonly List<DraggedDirection> _draggedDirections = new();
    
    public IEnumerable<DraggedDirection> DraggedDirections => _draggedDirections;

    public void AddDrag(DraggedDirection draggedDirection)
    {
        _draggedDirections.Add(draggedDirection);
    }

    public void Clear()
    {
        _draggedDirections.Clear();
    }
}
