namespace Algorithme.Tests;

public class ArrayTests
{
    [Fact]
    public void Array_Access()
    {
        var a = new[] { 1, 2, 3, 4, 5 };

        Assert.Equal(1, a[0]);
        Assert.Equal(2, a[1]);
    }
    
    [Fact]
    public void Array_Write()
    {
        var a = new[] { 1, 2, 3, 4, 5 };
        a[1] = 10;
        
        Assert.Equal(10, a[1]);
    }
    
    [Fact]
    public void List_Access()
    {
        var l = new List<string> { "a", "b", "c" };

        Assert.Equal("a", l[0]);
        Assert.Equal("b", l[1]);
    }
    
    [Fact]
    public void List_Add()
    {
        var l = new List<string> { "a", "b", "c" };
        l.Add("x");

        Assert.Equal("x", l[3]);
    }
    
    [Fact]
    public void List_Add_OverCapacity()
    {
        var l = new List<string>(3);
        
        Assert.Equal(3, l.Capacity);
        
        l.Add("x"); // O(1)
        l.Add("y"); // O(1)
        l.Add("w"); // O(1)
        l.Add("z"); // O(n)
        
        Assert.Equal(6, l.Capacity);
    }
    
    [Fact]
    public void List_Search_For()
    {
        var l = new List<string> { "a", "b", "c" };

        var target = "b";
        int? result = null;

        for (int i = 0; i < l.Count; i++)
        {
            if (l[i] == target)
            {
                result = i;
                break;
            }
        } 
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void List_Search_Foreach()
    {
        var l = new List<string> { "a", "b", "c" };

        var target = "b";
        int? result = null;
        
        int i = 0;
        foreach (var element in l)
        {
            if (element == target)
            {
                result = i;
                break;
            }
            i++;
        }
        
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void List_IndexOf()
    {
        var l = new List<string> { "a", "b", "c" };
        
        Assert.Equal(1, l.IndexOf("b"));
    }
    
    [Fact]
    public void List_Where()
    {
        var l = new List<int> { 1, 2, 3, 4, 5 };

        var evens = l.Where(e => e % 2 == 0);
        
        Assert.Equal(new[] { 2, 4 }, evens);
    }
}