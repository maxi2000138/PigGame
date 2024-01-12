using System;
using System.Collections.Generic;

public class ReactiveProperty<T> : IReactiveProperty<T>
{
    public event Action OnChanged;

    private static readonly IEqualityComparer<T> EqualityComparer = EqualityComparer<T>.Default;

    private T _value;


    public ReactiveProperty(T value = default(T))
    {
        _value = value;
    }

    public void Dispose()
    {
        OnChanged = null;
    }

    public T Value
    {
        get => _value;
        set
        {
            if (EqualityComparer.Equals(value, _value))
            {
                return;
            }

            _value = value;
            OnChanged?.Invoke();
        }
    }

    public void SetWithForceUpdate(T value)
    {
        _value = value;
        OnChanged?.Invoke();
    }
}
