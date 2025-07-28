namespace Algorithme;

public class LnkList<T>
{
    private LnkListNode<T>? _head;
    private LnkListNode<T>? _last;

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
        var newNode = new LnkListNode<T>(value);

        if (_head == null)
        {
            _head = newNode;
            _last = newNode;
            return;
        }

        var current = _head;
        while (current.Next != null)
            current = current.Next;

        current.Next = newNode;
        newNode.Previous = current;
        _last = newNode;
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

        if (_head.Value != null && _head.Value.Equals(value))
        {
            _head = null;
            return true;
        }

        var current = _head;
        while (current.Next != null)
        {
            if (current.Next.Value != null && current.Next.Value.Equals(value))
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
        var current = _last;
        while (current != null)
        {
            yield return current.Value;
            current = current.Previous;
        }
    }
    // O(n)
    public bool Contains(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Value != null && current.Value.Equals(value))
                return true;

            current = current.Next;
        }
        return false;
    }

// O(n)
    public void RemoveFirst(T value)
    {
        var current = _head;

        while (current != null)
        {
            if (current.Value != null && current.Value.Equals(value))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    _last = current.Previous;

                return;
            }

            current = current.Next;
        }
    }

// O(n)
    public void RemoveLast(T value)
    {
        var current = _last;

        while (current != null)
        {
            if (current.Value != null && current.Value.Equals(value))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    _last = current.Previous;

                return; 
            }

            current = current.Previous;
        }
    }
} //Dorley El Roi Tessa