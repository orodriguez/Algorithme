namespace Algorithme;

public class LnkList
{
    private LnkListNode? _head;

    public LnkList() => 
        _head = null;

    public void Prepend(int value)
    {
        if (_head == null)
        {
            _head = new LnkListNode(value);
            return;
        }

        _head = new LnkListNode(value, _head);
    }

    public void Add(int value)
    {
        if (_head == null)
        {
            _head = new LnkListNode(value);
            return;
        }

        var current = _head;
        while (current.Next != null) 
            current = current.Next;

        current.Next = new LnkListNode(value);
    }

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
}