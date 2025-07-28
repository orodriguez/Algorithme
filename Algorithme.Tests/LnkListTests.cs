namespace Algorithme.Tests;

public class LnkListTests
{
    [Fact]
    public void ToArrayEmpty()
    {
        var l = new LnkList<int>();

        Assert.Equal(Array.Empty<int>(), l.ToEnumerable());
    }
    
    [Fact]
    public void Prepend_Empty()
    {
        var l = new LnkList<int>();
        
        l.Prepend(5);
        
        Assert.Equal(new[] { 5 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Prepend_OneElement()
    {
        var l = new LnkList<string>();
        
        l.Prepend("B");
        l.Prepend("A");
        
        Assert.Equal(new[] { "A", "B" }, l.ToEnumerable());
    }
    
    [Fact]
    public void Add_Empty()
    {
        var l = new LnkList<float>();

        l.Add(15.8f);
        
        Assert.Equal(new[] { 15.8f }, l.ToEnumerable());
    }
    
    [Fact]
    public void Add_OneNode()
    {
        var l = new LnkList<int>();

        l.Add(15);
        l.Add(20);
        
        Assert.Equal(new[] { 15, 20 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Add_ListHasTwoValues()
    {
        var l = new LnkList<int>();
        l.Add(10);
        l.Add(15);
        
        l.Add(20);
        
        Assert.Equal(new[] { 10, 15, 20 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Insert_Empty()
    {
        var l = new LnkList<int>();
        l.Insert(0, 100);
        
        Assert.Equal(new[] { 100 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Insert_OneElement()
    {
        var l = new LnkList<int>();
        l.Add(20);
        
        l.Insert(0, 100);
        
        Assert.Equal(new[] { 100, 20 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Insert_TwoElement()
    {
        var l = new LnkList<int>();
        l.Add(20);
        l.Add(40);
        
        l.Insert(1, 30);
        
        Assert.Equal(new[] { 20, 30, 40 }, l.ToEnumerable());
    }
    
    [Fact]
    public void Insert_ThreeElement()
    {
        var l = new LnkList<int>();
        l.Add(20);
        l.Add(30);
        l.Add(50);
        
        l.Insert(2, 40);
        
        Assert.Equal(new[] { 20, 30, 40, 50 }, l.ToEnumerable());
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
        Assert.Empty(l.ToEnumerable());
    }
    
    [Fact]
    public void Remove_OneElement_Found()
    {
        var l = new LnkList<string>();
        l.Add("A");
        
        Assert.True(l.Remove("A"));
        Assert.Empty(l.ToEnumerable());
    }
    
    [Fact]
    public void Remove_Many()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        
        Assert.True(l.Remove("B"));
        Assert.Equal(new[] { "A", "C" }, l.ToEnumerable());
    }
    
    [Fact]
    public void ToReversedEnumerable()
    {
        var l = new LnkList<string>();
        
        Assert.Empty(l.ToReversedEnumerable());
    }
    
    [Fact]
    public void ToReversedEnumerable_OneElement()
    {
        var l = new LnkList<string>();
        l.Add("A");
        
        Assert.Equal(new[] { "A" }, l.ToReversedEnumerable());
    }
    
    [Fact]
    public void ToReversedEnumerable_Many()
    {
        var l = new LnkList<string>();
        l.Add("A");
        l.Add("B");
        l.Add("C");
        
        Assert.Equal(new[] { "C", "B", "A" }, l.ToReversedEnumerable());
    }
    [Fact]
    public void Contains_ValueExists_ReturnsTrue()
    {
        var list = new LnkList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.True(list.Contains(20));
    }

    [Fact]
    public void Contains_ValueDoesNotExist_ReturnsFalse()
    {
        var list = new LnkList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Assert.False(list.Contains(99));
    }

    [Fact]
    public void RemoveFirst_OnlyFirstOccurrenceRemoved()
    {
        var list = new LnkList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(2); // duplicate

        list.RemoveFirst(2);

        Assert.Equal(new[] { 1, 3, 2 }, list.ToEnumerable());
    }

    [Fact]
    public void RemoveLast_OnlyLastOccurrenceRemoved()
    {
        var list = new LnkList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(2); // duplicate

        list.RemoveLast(2);

        Assert.Equal(new[] { 1, 2, 3 }, list.ToEnumerable());
    }
}