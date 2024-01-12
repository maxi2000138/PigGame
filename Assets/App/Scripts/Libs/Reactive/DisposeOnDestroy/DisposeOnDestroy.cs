using System;
using System.Collections.Generic;
using UnityEngine;

public class DisposeOnDestroy : MonoBehaviour
{
#if DEBUG
    public string debugName;
#endif

    private readonly List<IDisposable> _disposables = new List<IDisposable>();
    private DisposeOnDestroyLifetimeController _lifetimeController;
    private bool _awakened;

    protected void Awake()
    {
        _awakened = true;
        RemoveFromLifetimeController();
    }

    public void AddDisposableOnDestroy(IDisposable disposable)
    {
        _disposables.Add(disposable);
    }

    protected void OnDestroy()
    {
        Clear();
        RemoveFromLifetimeController();
    }

    public void Clear()
    {
        for (var i = 0; i < _disposables.Count; i++)
        {
            var disposable = _disposables[i];
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        _disposables.Clear();
    }

    public void SetLifetimeController(DisposeOnDestroyLifetimeController value)
    {
        if (_lifetimeController != null)
        {
            Debug.LogError("SetLifetimeController lifetime controller already exists");
        }

        if (_awakened)
        {
            return;
        }

        _lifetimeController = value;
        _lifetimeController.AddNotAwakened(this);
#if DEBUG
        debugName = gameObject.name;
#endif
    }

    private void RemoveFromLifetimeController()
    {
        if (_lifetimeController == null)
        {
            return;
        }

        _lifetimeController.Remove(this);
        _lifetimeController = null;
    }
}
