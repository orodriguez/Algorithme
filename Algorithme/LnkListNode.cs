namespace Algorithme;

public class LnkListNode
{
    public int Value { get; }

    public LnkListNode? Next { get; set; }

    public LnkListNode(int value, LnkListNode? next = null)
    {
        Value = value;
        Next = next;
    }
}