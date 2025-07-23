namespace Algorithme;

public class LnkListNode
{
    public int Value { get; private set; }

    public LnkListNode? Next { get; private set; }

    public LnkListNode(int value, LnkListNode? next)
    {
        Value = value;
        Next = next;
    }

    public void Prepend(int value)
    {
        Next = new LnkListNode(Value, null);
        Value = value;
    }

    public int[] ToArray()
    {
        var result = new List<int>();

        LnkListNode? current = this;
        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result.ToArray();
    }
}