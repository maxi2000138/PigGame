using System.Collections.Generic;

public class MultipleContainer<T> where T : class
{
    public List<T> Items { get; private set; }

    public MultipleContainer(List<T> startItems)
    {
        Items = startItems;
    }

    public MultipleContainer()
    {
        Items = new List<T>();
    }
    
    public void AddItem(T item)
    {
        if (Items.Contains(item))
            throw new ExceptionContainer($"Container already contains item {item}");
            
        Items.Add(item);
    }

    public void RemoveItem(T item)
    {
        if (!Items.Contains(item))
            throw new ExceptionContainer($"Container doesn't contain item {item}");
        
        Items.Remove(item);
    }

    public void Clear()
    {
        Items.Clear();
    }
}
