namespace Algorithme;

public class LnkListNode<T>
{
    public T Value { get; }
    public LnkListNode<T>? Next { get; set; }
    public LnkListNode<T>? Previous { get; set; }
    public LnkListNode(T value, LnkListNode<T>? previous = null, LnkListNode<T>? next = null)
    {
        Value = value;
        Previous = previous;
        Next = next;
    }

    public void Link(LnkListNode<T> node)
    {
        Next = node;
        node.Previous = this;
    }
}