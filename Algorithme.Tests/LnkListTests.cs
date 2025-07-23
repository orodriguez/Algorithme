namespace Algorithme.Tests;

public class LnkListTests
{
    [Fact]
    public void ToArrayEmpty()
    {
        var l = new LnkList();

        Assert.Equal(Array.Empty<int>(), l.ToArray());
    }
    
    [Fact]
    public void Prepend_Empty()
    {
        var l = new LnkList();
        
        l.Prepend(5);
        
        Assert.Equal(new[] { 5 }, l.ToArray());
    }
    
    [Fact]
    public void Prepend_OneElement()
    {
        var l = new LnkList();
        
        l.Prepend(10);
        l.Prepend(5);
        
        Assert.Equal(new[] { 5, 10 }, l.ToArray());
    }
    
    [Fact]
    public void Add_Empty()
    {
        var l = new LnkList();

        l.Add(15);
        
        Assert.Equal(new[] { 15 }, l.ToArray());
    }
    
    [Fact]
    public void Add_OneNode()
    {
        var l = new LnkList();

        l.Add(15);
        l.Add(20);
        
        Assert.Equal(new[] { 15, 20 }, l.ToArray());
    }
    
    [Fact]
    public void Add_ListHasTwoValues()
    {
        var l = new LnkList();
        l.Add(10);
        l.Add(15);
        
        l.Add(20);
        
        Assert.Equal(new[] { 10, 15, 20 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_Empty()
    {
        var l = new LnkList();
        l.Insert(0, 100);
        
        Assert.Equal(new[] { 100 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_OneElement()
    {
        var l = new LnkList();
        l.Add(20);
        
        l.Insert(0, 100);
        
        Assert.Equal(new[] { 100, 20 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_TwoElement()
    {
        var l = new LnkList();
        l.Add(20);
        l.Add(40);
        
        l.Insert(1, 30);
        
        Assert.Equal(new[] { 20, 30, 40 }, l.ToArray());
    }
    
    [Fact]
    public void Insert_ThreeElement()
    {
        var l = new LnkList();
        l.Add(20);
        l.Add(30);
        l.Add(50);
        
        l.Insert(2, 40);
        
        Assert.Equal(new[] { 20, 30, 40, 50 }, l.ToArray());
    }
}