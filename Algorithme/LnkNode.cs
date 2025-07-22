namespace Algorithme;

public class LnkNode
{
    public int Value { get; }

    public LnkNode? Next { get; }

    public LnkNode(int value, LnkNode? next)
    {
        Value = value;
        Next = next;
    }
}