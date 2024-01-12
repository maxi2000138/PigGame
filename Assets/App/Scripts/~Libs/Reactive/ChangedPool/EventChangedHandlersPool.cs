using System;
using System.Collections.Generic;
using UnityEngine;

public class EventChangedHandlersPool
{
    private readonly List<EventChangedHandler> _pool = new List<EventChangedHandler>();
    private readonly List<EventChangedHandler> _poolItemsToRemove = new List<EventChangedHandler>();
    private IDisposable _emptyHandler;

    public IDisposable Get(IEventProvider eventProvider, Action handler, bool once, GameObject gameObject)
    {
        if (gameObject == null)
        {
            Debug.LogError("Get gameObject is null");
            return _emptyHandler ??= new EventChangedHandler();
        }

        EventChangedHandler result = null;

        for (int i = 0; i < _pool.Count; i++)
        {
            var poolItem = _pool[i];
            _poolItemsToRemove.Add(poolItem);

            if (!poolItem.CheckGameObjectIsDestroyed())
            {
                result = poolItem;
                break;
            }
        }

        for (var i = 0; i < _poolItemsToRemove.Count; i++)
        {
            _pool.Remove(_poolItemsToRemove[i]);
        }
        _poolItemsToRemove.Clear();

        result ??= new EventChangedHandler();
        result.Arm(eventProvider, once
            ? () =>
            {
                handler();
                result.Dispose();
                _pool.Add(result);
            }
            : handler, gameObject);

        return result;
    }
}
