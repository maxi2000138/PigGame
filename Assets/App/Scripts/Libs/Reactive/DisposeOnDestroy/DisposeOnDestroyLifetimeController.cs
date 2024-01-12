using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeOnDestroyLifetimeController
{
    private readonly List<DisposeOnDestroy> _notAwakenedElements = new List<DisposeOnDestroy>();
    private IEnumerator _coroutine;
    private DisposeOnDestroyLifetimeControllerComponent _coroutineHolder;

    public void AddNotAwakened(DisposeOnDestroy disposeOnDestroy)
    {
        _notAwakenedElements.Add(disposeOnDestroy);
        if (_coroutine != null)
        {
            return;
        }

        if (_coroutineHolder == null)
        {
            var go = new GameObject("DisposeOnDestroyLifetimeController");
            _coroutineHolder = go.AddComponent<DisposeOnDestroyLifetimeControllerComponent>();
            Object.DontDestroyOnLoad(_coroutineHolder);
        }

        _coroutine = CheckEverySecondCoroutine();
        _coroutineHolder.StartCoroutine(_coroutine);
    }

    public void Remove(DisposeOnDestroy disposeOnDestroy)
    {
        _notAwakenedElements.Remove(disposeOnDestroy);
    }

    private IEnumerator CheckEverySecondCoroutine()
    {
        while (_notAwakenedElements.Count > 0)
        {
            var startWaitTime = Time.realtimeSinceStartup;
            const float updateIntervalSeconds = 1;
            while (Time.realtimeSinceStartup - startWaitTime < updateIntervalSeconds)
            {
                yield return null;
            }

            DisposeDeadDataBinders();
        }

        _coroutine = null;
    }

    private void DisposeDeadDataBinders()
    {
        for (var i = 0; i < _notAwakenedElements.Count; i++)
        {
            if (_notAwakenedElements[i] != null)
            {
                continue;
            }

            
#if DEBUG
            Debug.LogWarning("disposing dead dataBinder " + _notAwakenedElements[i].debugName);
#else
            Debug.LogWarning("disposing dead dataBinder");
#endif
            
            _notAwakenedElements[i].Clear();
            _notAwakenedElements.RemoveAt(i);
            i--;
        }
    }

    private class DisposeOnDestroyLifetimeControllerComponent : MonoBehaviour
    {
    }
}
