namespace Algorithme;

public class LnkListNode<T>
{
    public T Value { get; }

    public LnkListNode<T>? Next { get; set; }
    public LnkListNode<T>? Previous { get; set; }

    public LnkListNode(T value, LnkListNode<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}