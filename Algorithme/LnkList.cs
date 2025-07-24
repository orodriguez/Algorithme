namespace Algorithme;

public class LnkList
{
    private LnkListNode? _head;

    public LnkList() => 
        _head = null;
    
    // O (1)
    public void Prepend(int value)
    {
        // O (1)
        if (_head == null)
        {
            _head = new LnkListNode(value);
            return;
        }
        
        // O (1)
        _head = new LnkListNode(value, next: _head);
    }
    
    // O(n)
    public void Add(int value)
    {
        // O(1)
        if (_head == null)
        {
            _head = new LnkListNode(value);
            return;
        }
        
        // O(n)
        var current = _head;
        while (current.Next != null) 
            current = current.Next;

        current.Next = new LnkListNode(value);
    }
    
    // O(n)
    public void Insert(int index, int value)
    {
        if (_head == null)
        {
            _head = new LnkListNode(value);
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
                current.Next = new LnkListNode(value, current.Next);
                return;
            }

            i++;
            current = current.Next;
        }
    }

    // O(n)
    public IEnumerable<int> ToArray()
    {
        if (_head == null)
            return Array.Empty<int>();
        
        var result = new List<int>();

        var current = _head;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result;
    }

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
    
    // TODO: Generic
}