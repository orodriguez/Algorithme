namespace Algorithme;

public class LnkList<T>
{
    private LnkListNode<T>? _head;
    private LnkListNode<T>? _last;

    public LnkList() => 
        _head = _last = null;

    // O (1)
    public void Prepend(T value)
    {
        // O (1)
        if (_head == null)
        {
            _head = _last = new LnkListNode<T>(value);
            return;
        }
        
        // O (1)
        var newNode = new LnkListNode<T>(value);
        newNode.Link(_head);
        _head = newNode;
    }
    
    // O(1)
    public void Add(T value)
    {
        // O(1)
        if (_last == null)
        {
            _head = _last = new LnkListNode<T>(value);
            return;
        }

        var newNode = new LnkListNode<T>(value);
        _last.Link(newNode);
        _last = newNode;
    }
    
    // O(n)
    public void Insert(int index, T value)
    {
        if (_head == null)
        {
            _head = _last = new LnkListNode<T>(value);
            return;
        }

        if (index == 0)
        {
            Prepend(value);
            return;
        }

        var i = 0;
        var current = _head;

        while (current != null)
        {
            if (i == index)
            {
                var newNode = new LnkListNode<T>(value);
                current.Previous!.Link(newNode);
                newNode.Link(current);
                return;
            }

            i++;
            current = current.Next;
        }
    }

    // O(n)
    public IEnumerable<T> ToEnumerable()
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

    public bool Remove(T value)
    {
        if (_head == null)
            return false;

        if (_head.Value.Equals(value))
        {
            _head = _last= null;
            return true;
        }

        var current = _head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                current.Previous.Link(current.Next);
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public IEnumerable<T> ToReversedEnumerable()
    {
        if (_last == null)
            return Array.Empty<T>();
        
        var result = new List<T>();
        var current = _last;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Previous;
        }

        return result;
    }
}