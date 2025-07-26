namespace Algorithme;

public class LnkList<T>
{
    private LnkListNode<T>? _head;
    private LnkListNode<T>? _last;
    private int _count = 0;

    public LnkList() => 
        _head = _last = null;

    // O (1)
    public void Prepend(T value)
    {
        // O (1)
        if (_head == null)
        {
            _head = _last = new LnkListNode<T>(value);
            _count++;
            return;
        }
        
        // O (1)
        var newNode = new LnkListNode<T>(value);
        newNode.Link(_head);
        _head = newNode;
        _count++;
    }
    
    // O(1)
    public void Add(T value)
    {
        // O(1)
        if (_last == null)
        {
            _head = _last = new LnkListNode<T>(value);
            _count++;
            return;
        }

        var newNode = new LnkListNode<T>(value);
        _last.Link(newNode);
        _last = newNode;
        _count++;
    }
    
    // O(n)
    public void Insert(int index, T value)
    {
        if (index < 0 || index > Count())
            throw new ArgumentOutOfRangeException(nameof(index));
        
        if (_head == null)
        {
            _head = _last = new LnkListNode<T>(value);
            _count++;
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
                _count++;
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
    
    // O(1)
    public int Count() => _count;

    public bool Remove(T value)
    {
        if (_head == null)
            return false;

        if (_head.Value.Equals(value))
        {
            _head = _last= null;
            _count = 0;
            return true;
        }

        var current = _head;
        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                current.Previous.Link(current.Next);
                _count--;
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