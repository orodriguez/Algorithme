namespace Algorithme.Tests;

public class LnkNodeTests
{
    [Fact]
    public void Constructor()
    {
        var l = new LnkNode(10, null);
        
        Assert.Equal(10, l.Value);
        Assert.Null(l.Next);
    }
    
    [Fact]
    public void Constructor_TwoElements()
    {
        var n2 = new LnkNode(30, null);
        var n1 = new LnkNode(20, n2);
        
        Assert.Equal(20, n1.Value);

        var next = n1.Next;
        Assert.NotNull(next);
        Assert.Equal(30, next.Value);
    }
}