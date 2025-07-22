namespace Algorithme.Tests;

public class ArrayTests
{
    [Fact]
    public void Access()
    {
        var a = new[] { 1, 2, 3, 4, 5 };
        
        Assert.Equal(1, a[0]);
        Assert.Equal(2, a[1]);
    }
}