public class SingleContainer<T> where T : class
{
    public T Item { get; private set; }

    public SingleContainer(T startItem)
    {
        Item = startItem;
    }
    
    public SingleContainer() { }

    public void SetValue(T item)
    {
        Item = item;
    }

    public void Clear()
    {
        Item = null;
    }
}
