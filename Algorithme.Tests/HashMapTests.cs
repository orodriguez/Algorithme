namespace Algorithme.Tests;

public class HashMapTests
{
    [Fact]
    public void SetAndGet()
    {
        var d = new HashMap();

        d['a'] = 1;

        Assert.Equal(1, d['a']);
    }
    
    [Fact]
    public void Collision()
    {
        var d = new HashMap(3);

        d['a'] = 1;
        d['b'] = 2;
        d['c'] = 3;
        d['d'] = 4;

        Assert.Equal(1, d['a']);
        Assert.Equal(2, d['b']);
        Assert.Equal(3, d['c']);
        Assert.Equal(4, d['d']);
    }
    
    [Fact]
    public void Override()
    {
        var d = new HashMap(3);

        d['a'] = 1;
        d['a'] = 2;
        d['d'] = 3;

        Assert.Equal(2, d['a']);
        Assert.Equal(3, d['d']);
    }
    
    [Fact]
    public void KeynNotFound()
    {
        var d = new HashMap(3);

        Assert.Throws<KeyNotFoundException>(() => d['a']);
    }
}