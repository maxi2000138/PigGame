using UnityEngine;

public class MonoView : MonoSpawnableItem
{
    [SerializeField] private Transform root;

    public Transform Transform => root;

    public Vector3 localPosition
    {
        get => transform.localPosition;
        set => transform.localPosition = value;
    }

    public Vector3 localScale
    {
        get => Transform.localScale;

        set => Transform.localScale = value;
    }

    private void Awake()
    {
        root ??= GetComponent<Transform>();
    }

    public void SetParent(Transform container)
    {
        transform.SetParent(container);
    }
}
