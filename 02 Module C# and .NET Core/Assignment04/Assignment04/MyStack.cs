namespace Assignment04;

public class MyStack<T>
{
    private List<T> stack = new List<T>();

    // Method to get the count of elements in the stack
    public int Count()
    {
        return stack.Count;
    }

    // Method to pop an element from the stack (remove and return the top element)
    public T Pop()
    {
        if (stack.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty");
        }

        T item = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        return item;
    }

    // Method to push an element onto the stack
    public void Push(T item)
    {
        stack.Add(item);
    }
}

public class MyList<T>
{
    private List<T> list = new List<T>();

    // Add an element to the list
    public void Add(T element)
    {
        list.Add(element);
    }

    // Remove an element at a specific index
    public T Remove(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
        }

        T item = list[index];
        list.RemoveAt(index);
        return item;
    }

    // Check if the list contains a specific element
    public bool Contains(T element)
    {
        return list.Contains(element);
    }

    // Clear the list
    public void Clear()
    {
        list.Clear();
    }

    // Insert an element at a specific index
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
        }

        list.Insert(index, element);
    }

    // Delete an element at a specific index
    public void DeleteAt(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
        }

        list.RemoveAt(index);
    }

    // Find an element at a specific index
    public T Find(int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid index");
        }

        return list[index];
    }
}


public class Entity
{
    public int Id { get; set; }
}

// Interface for repository
public interface IRepository<T> where T : Entity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

// Generic repository implementing IRepository<T>
public class GenericRepository<T> : IRepository<T> where T : Entity
{
    private List<T> items = new List<T>();

    // Add an item to the repository
    public void Add(T item)
    {
        items.Add(item);
    }

    // Remove an item from the repository
    public void Remove(T item)
    {
        items.Remove(item);
    }

    // Save changes (in-memory implementation)
    public void Save()
    {
        // In-memory, so nothing to persist here
        Console.WriteLine("Changes saved.");
    }

    // Get all items
    public IEnumerable<T> GetAll()
    {
        return items;
    }

    // Get an item by its Id
    public T GetById(int id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }
}