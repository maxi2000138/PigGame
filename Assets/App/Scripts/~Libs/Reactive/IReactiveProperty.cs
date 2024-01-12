public interface IReactiveProperty<out T> : IEventProvider
{
    T Value { get; }
}