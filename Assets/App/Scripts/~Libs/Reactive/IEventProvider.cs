using System;

public interface IEventProvider<out T> : IEventProvider
{
    T Value { get; }
}

public interface IEventProvider
{
    event Action OnChanged;
}