using UnityEngine;

public class ContainerDragVector : MultipleContainer<Vector3Data>
{ }

public class Vector3Data
{
    public readonly Vector3 Vector;

    public Vector3Data(Vector3 vector)
    {
        Vector = vector;
    }
}
