namespace Algorithme.Tests;

public class LnkListTests
{
    [Fact]
    public void ToArrayEmpty()
    {
        var l = new LnkList<int>();

        AssertListLinks(Array.Empty<int>(), l);
    }

    [Fact]
    public void Prepend_Empty()
    {
        var l = new LnkList<int>();
        
        l.Prepend(5);
        
        AssertListLinks(new[] { 5 }, l);
    }

    [Fact]
    public void Prepend_OneElement()
    {
        var l = new LnkList<string>();
        
        l.Prepend("B");
        l.Prepend("A");
        
        AssertListLinks(new[] { "A", "B" }, l);
    }

    [Fact]
    public void Add_Empty()
    {
        var l = new LnkList<float>();

        l.Add(15.8f);
        
        AssertListLinks(new[] { 15.8f }, l);
    }

    [Fact]
    public void Add_OneNode()
    {
        var l = new LnkList<int>();

        l.Add(15);
        l.Add(20);
        
        AssertListLinks(new[] { 15, 20 }, l);
    }

    [Fact]
    public void Add_Many()
    {
        var l = new LnkList<int>();
        l.Add(10);
        l.Add(15);
        l.Add(20);
        
        AssertListLinks(new[] { 10, 15, 20 }, l);
    }

    [Fact]
    public void Insert_Empty()
    {
        var l = new LnkList<int>();
        l.Insert(0, 100);
        
        AssertListLinks(new[] { 100 }, l);
    }

    [Fact]
    public void Insert_OneElement()
    {
        var l = new LnkList<string>();
        l.Add("B");
        
        l.Insert(0, "A");
        
        AssertListLinks(new[] { "A", "B" }, l);
    }

    [Fact]
    public void Insert_TwoElement()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("C");
        
        l.Insert(1, "B");
        
        AssertListLinks(new[] { "A", "B", "C" }, l);
    }

    [Fact]
    public void Insert_ThreeElement()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("C");
        l.Add("D");
        
        l.Insert(1, "B");
        
        AssertListLinks(new[] { "A", "B", "C", "D" }, l);
    }
    
    [Fact]
    public void Insert_IndexOutOfRange()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");

        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => l.Insert(5, "X"));
        
        Assert.Contains("argument was out of the range", 
            exception.Message);
    }
    
    [Fact]
    public void Insert_IndexOutOfRange_Negative()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");

        var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => l.Insert(-2, "X"));
        
        Assert.Contains("argument was out of the range", 
            exception.Message);
    }

    [Fact]
    public void Count_Empty()
    {
       var l = new LnkList<int>(); 
        
        Assert.Equal(0, l.Count());
    }

    [Fact]
    public void Count_ManyElements()
    {
        var l = new LnkList<int>();

        l.Add(10);
        l.Add(20);
        l.Add(30);
        
        Assert.Equal(3, l.Count());
    }

    [Fact]
    public void Remove_Empty()
    {
        var l = new LnkList<string>();

        Assert.False(l.Remove("A"));
        AssertListLinks(Array.Empty<string>(), l);
    }

    [Fact]
    public void Remove_OneElement_Found()
    {
        var l = new LnkList<string>();
        l.Add("A");
        
        Assert.True(l.Remove("A"));
        AssertListLinks(Array.Empty<string>(), l);
    }

    [Fact]
    public void Remove_Many()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        
        Assert.True(l.Remove("B"));
        AssertListLinks(new[] { "A", "C" }, l);
    }

    [Fact]
    public void ToReversedEnumerable_Empty()
    {
        var l = new LnkList<string>();
        
        AssertListLinks(Array.Empty<string>(), l);
    }

    [Fact]
    public void ToReversedEnumerable_OneElement()
    {
        var l = new LnkList<string>();
        l.Add("A");
        
        AssertListLinks(new[] { "A" }, l);
    }

    [Fact]
    public void ToReversedEnumerable_Many()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        
        AssertListLinks(new[] { "A", "B", "C" }, l);
    }
    
    
    private void AssertListLinks<T>(T[] expected, LnkList<T> list)
    {
        Assert.Equal(expected, list.ToEnumerable());
        Assert.Equal(expected.Reverse(), list.ToReversedEnumerable());
        Assert.Equal(expected.Length, list.Count());
    }
    
    [Fact]
    public void RemoveFirst_Empty()
    {
        //funcionando
        var l = new LnkList<string>();
        
        l.RemoveFirst();
        
        AssertListLinks(Array.Empty<string>(), l);
    }
    
    [Fact]
    public void RemoveFirst_OnlyOneElement()
    {
        //funcionando
        var l = new LnkList<string>();
        l.Add("A");
        l.RemoveFirst();
        
        AssertListLinks(Array.Empty<string>(), l);
    }
    
    [Fact]
    public void RemoveFirst_Many()
    {
        //pendiente
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        l.RemoveFirst();
        
        AssertListLinks(new[] { "B", "C" }, l);
    }
    
    [Fact]
    public void RemoveLast_Empty()
    {
        //funcionando
        var l = new LnkList<string>();
        
        l.RemoveLast();
        
        AssertListLinks(Array.Empty<string>(), l);
    }
    
    [Fact]
    public void RemoveLast_OnlyOneElement()
    {
        //funcionando
        var l = new LnkList<string>();
        l.Add("A");
        l.RemoveLast();
        
        AssertListLinks(Array.Empty<string>(), l);
    }
    
    [Fact]
    public void RemoveLast_Many()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        l.RemoveLast();
        
        AssertListLinks(new[] { "A", "B" }, l);
    }
    
}