namespace Algorithme.Tests;

public class LnkListNodeTests
{
    [Fact]
    public void Constructor()
    {
        var l = new LnkListNode(10, null);
        
        Assert.Equal(10, l.Value);
        Assert.Null(l.Next);
    }
    
    [Fact]
    public void Constructor_TwoElements()
    {
        var n2 = new LnkListNode(30, null);
        var n1 = new LnkListNode(20, n2);
        
        Assert.Equal(20, n1.Value);

        var next = n1.Next;
        Assert.NotNull(next);
        Assert.Equal(30, next.Value);
    }
    
    [Fact]
    public void Prepend()
    {
        var l = new LnkListNode(10, null);

        l.Prepend(5);
        
        Assert.Equal(new[] { 5, 10 }, l.ToArray());
    }
}