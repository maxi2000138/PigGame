using System;
using UnityEngine;

public static class ReactiveExtensions
{
    private static readonly EventChangedHandlersPool Pool = new EventChangedHandlersPool();
    private static readonly DisposeOnDestroyLifetimeController LifetimeController = new DisposeOnDestroyLifetimeController();

    /// <summary>
    /// Subscribes handler to eventProvider using gameObject lifecycle
    /// The handler will only be called if an event fires
    /// </summary>
    public static void Subscribe(this GameObject gameObject, IEventProvider eventProvider, Action handler)
    {
        SubscribeInternal(gameObject, eventProvider, handler, false, false);
    }
    
    /// <summary>
    /// Subscribes handler to eventProvider using gameObject lifecycle
    /// The handler will only be called if an event fires
    /// </summary>
    public static void Subscribe<T>(this GameObject gameObject, IEventProvider<T> eventProvider, Action<T> handler)
    {
        SubscribeInternal(gameObject, eventProvider, () => handler(eventProvider.Value), false, false);
    }

    /// <summary>
    /// Subscribe handler to property using gameObject lifecycle
    /// The property always has a value so the value will be set immediately
    /// </summary>
    public static void Subscribe<T>(this GameObject gameObject, IReactiveProperty<T> property, Action<T> handler)
    {
        SubscribeInternal(gameObject, property, () => handler(property.Value), false, true);
    }

    /// <summary>
    /// Manual lifecycle management is awful
    /// Don't use it, private is ok
    /// </summary>
    // ReSharper disable once UnusedMethodReturnValue.Local
    private static IDisposable SubscribeInternal(GameObject gameObject, IEventProvider eventProvider, Action handler, bool once, bool callImmediately)
    {
        var propertyHandler = Pool.Get(eventProvider, handler, once, gameObject);
        DisposeOnDestroy(propertyHandler, gameObject);
        if (callImmediately)
        {
            handler();
        }

        return propertyHandler;
    }

    /// <summary>
    /// Subscribes IDisposable to gameObject lifecycle
    /// Dispose is called when OnDestroy is called
    /// </summary>
    public static void DisposeOnDestroy(this IDisposable disposable, GameObject gameObject)
    {
        if (gameObject == null)
        {
            Debug.LogError("DisposeOnDestroy gameObject is null");
            return;
        }

        var component = gameObject.GetComponent<DisposeOnDestroy>();
        if (component == null)
        {
            component = gameObject.AddComponent<DisposeOnDestroy>();
            component.SetLifetimeController(LifetimeController);
        }

        component.AddDisposableOnDestroy(disposable);
    }
    
    /// <summary>
    /// Unsubscribes from everything
    /// </summary>
    private static void UnsubscribeDisposables(this GameObject gameObject)
    {
        var component = gameObject.GetComponent<DisposeOnDestroy>();
        if (component == null)
        {
            return;
        }

        component.Clear();
    }
    
    /// <summary>
    /// Sets disposable viewModel
    /// </summary>
    public static void UpdateDisposableViewModel<TViewModel>(this GameObject gameObject, ref TViewModel currentValue, TViewModel newValue) where TViewModel : class, IDisposable
    {
        if (currentValue != null)
        {
            currentValue.Dispose();
        }

        currentValue = newValue;
        gameObject.UnsubscribeDisposables();
        currentValue.DisposeOnDestroy(gameObject);
    }
    
    /// <summary>
    /// Sets non-disposable viewModel
    /// </summary>
    // ReSharper disable once RedundantAssignment
    public static void UpdateSimpleViewModel<TViewModel>(this GameObject gameObject, ref TViewModel currentValue, TViewModel newValue, bool checkDisposable = true) where TViewModel : class
    {
        if (checkDisposable && newValue is IDisposable)
        {
            Debug.LogWarning("Use UpdateDisposableViewModel for " + typeof(TViewModel));
        }
        gameObject.UnsubscribeDisposables();
        currentValue = newValue;
    }
}
