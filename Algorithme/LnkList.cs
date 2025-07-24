namespace Algorithme;

public class LnkList<T>
{
    private LnkListNode<T>? _head;

    public LnkList() => 
        _head = null;
    
    // O (1)
    public void Prepend(T value)
    {
        // O (1)
        if (_head == null)
        {
            _head = new LnkListNode<T>(value);
            return;
        }
        
        // O (1)
        _head = new LnkListNode<T>(value, next: _head);
    }
    
    // O(n)
    public void Add(T value)
    {
        // O(1)
        if (_head == null)
        {
            _head = new LnkListNode<T>(value);
            return;
        }
        
        // O(n)
        var current = _head;
        while (current.Next != null) 
            current = current.Next;

        current.Next = new LnkListNode<T>(value);
    }
    
    // O(n)
    public void Insert(int index, T value)
    {
        if (_head == null)
        {
            _head = new LnkListNode<T>(value);
            return;
        }

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        var i = 0;
        var current = _head;

        while (current.Next != null)
        {
            if (i == index - 1)
            {
                current.Next = new LnkListNode<T>(value, current.Next);
                return;
            }

            i++;
            current = current.Next;
        }
    }

    // O(n)
    public IEnumerable<T> ToArray()
    {
        if (_head == null)
            return Array.Empty<T>();
        
        var result = new List<T>();

        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result;
    }
    
    // O(n)
    public int Count()
    {
        if (_head == null)
            return 0;

        var current = _head;
        var count = 0;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}