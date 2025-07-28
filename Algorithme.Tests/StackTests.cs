namespace Algorithme.Tests;

public class StackTests
{
    [Fact]
    public void PushAndPop()
    {
        var s = new Stack<string>();
        
        s.Push("a");
        s.Push("b");
        s.Push("c");
        
        Assert.Equal(new[] { "c", "b", "a" }, s);
        Assert.Equal("c", s.Pop());
        Assert.Equal(new[] { "b", "a" }, s);
        Assert.Equal("b", s.Pop());
        Assert.Equal(new[] { "a" }, s);
    }
    
    [Fact]
    public void Peek()
    {
        var s = new Stack<string>();
        
        s.Push("a");
        s.Push("b");
        s.Push("c");
        
        Assert.Equal(new[] { "c", "b", "a" }, s);
        Assert.Equal("c", s.Peek());
        Assert.Equal(new[] { "c", "b", "a" }, s);
    }
}