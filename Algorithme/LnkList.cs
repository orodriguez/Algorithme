public class LnkList<T>
{
    private LnkListNode<T>? _head;

    public LnkList() => _head = null;

    // O(1)
    public void Prepend(T value)
    {
        _head = new LnkListNode<T>(value, next: _head);
    }

    // O(n)
    public void Add(T value)
    {
        if (_head == null)
        {
            _head = new LnkListNode<T>(value);
            return;
        }

        var current = _head;
        while (current.Next != null)
            current = current.Next;

        current.Next = new LnkListNode<T>(value);
    }

    // O(n)
    public void Insert(int index, T value)
    {
        if (_head == null || index == 0)
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
        var current = _head;
        var count = 0;

        while (current != null)
        {
            count++;
            current = current.Next;
        }

        return count;
    }

    // O(n) 
    public bool Remove(T value)
    {
        if (_head == null)
            return false;

        if (_head.Value!.Equals(value))
        {
            _head = _head.Next;
            return true;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value!.Equals(value))
            {
                current.Next = current.Next.Next;
                return true;
            }
            current = current.Next;
        }

        return false;
    }

    public IEnumerable<T> ToReversedEnumerable()
    {
        throw new NotImplementedException();
    }

    // O(n)
    public bool Contains(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Value!.Equals(value))
                return true;
            current = current.Next;
        }
        return false;
    }

    // O(n)
    public void RemoveFirst(T value)
    {
        if (_head == null)
            return;

        if (_head.Value!.Equals(value))
        {
            _head = _head.Next;
            return;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value!.Equals(value))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }

    // O(n)
    public void RemoveLast(T value)
    {
        if (_head == null)
            return;

        LnkListNode<T>? lastMatch = null;
        LnkListNode<T>? beforeLastMatch = null;
        LnkListNode<T>? current = _head;
        LnkListNode<T>? prev = null;

        while (current != null)
        {
            if (current.Value!.Equals(value))
            {
                lastMatch = current;
                beforeLastMatch = prev;
            }

            prev = current;
            current = current.Next;
        }

        if (lastMatch == null)
            return;

        if (beforeLastMatch == null)
        {
            // Está en la cabeza
            _head = _head.Next;
        }
        else
        {
            beforeLastMatch.Next = lastMatch.Next;
        }
    }
}
