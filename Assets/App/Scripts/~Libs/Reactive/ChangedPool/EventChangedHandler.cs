using System;
using UnityEngine;

public class EventChangedHandler : IDisposable
{
    private IEventProvider _eventProvider;
    private Action _handler;
    private GameObject _gameObject;
#if DEBUG
    private string _gameObjectName;
#endif

    public void Arm(IEventProvider eventProvider, Action handler, GameObject gameObject)
    {
        _gameObject = gameObject;
        _eventProvider = eventProvider;
        _handler = handler;
        _eventProvider.OnChanged += OnChanged;
#if DEBUG
        _gameObjectName = gameObject.name;
#endif
    }

    private void OnChanged()
    {
        if (CheckGameObjectIsDestroyed())
        {
            return;
        }

        _handler();
    }

    public bool CheckGameObjectIsDestroyed()
    {
        if (_gameObject != null)
        {
            return false;
        }

        Debug.LogWarning("CheckGameObjectIsDestroyed object is destroyed");
#if DEBUG
        Debug.LogWarning("CheckGameObjectIsDestroyed object name is " + _gameObjectName);
#endif
        Dispose();
        return true;
    }

    public void Dispose()
    {
        if (_eventProvider != null)
        {
            _eventProvider.OnChanged -= OnChanged;
        }

        _gameObject = null;
        _eventProvider = null;
        _handler = null;
#if DEBUG
        _gameObjectName = null;
#endif
    }
}
