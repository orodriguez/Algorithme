namespace Algorithme.Tests;

public class QueueTests
{
    [Fact]
    public void QueueAndDequeue()
    {
        var q = new Queue<string>();
        
        Assert.Empty(q);
        
        q.Enqueue("a");
        q.Enqueue("b");
        q.Enqueue("c");
        
        Assert.Equal(new[] { "a", "b", "c"}, q);
        
        Assert.Equal("a", q.Dequeue());
        
        Assert.Equal(new[] { "b", "c"}, q);
    }
}