namespace Algorithme.Tests;

public class TreeNodeTests
{
    [Fact]
    public void Constructor()
    {
        var root = new TreeNode<string>("Goku");
        Assert.Equal("Goku", root.Value);
        Assert.Empty(root.Children);
    }
    
    [Fact]
    public void Add()
    {
        var root = new TreeNode<string>("Goku");
        root.Add("Gohan");

        var child = Assert.Single(root.Children);
        Assert.Equal("Gohan", child.Value);
        Assert.Empty(child.Children);
    }

    [Fact]
    public void Count_One()
    {
        var root = new TreeNode<string>("Goku");
        
        Assert.Equal(1, root.Count());
    }
    
    [Fact]
    public void Count_ManyChildren()
    {
        var root = new TreeNode<string>("Goku");

        root.Add("Gohan");
        root.Add("Goten");
        
        Assert.Equal(3, root.Count());
    }
    
    [Fact]
    public void Count_ManyGrandChildren()
    {
        var goku = new TreeNode<string>("Goku");

        var gohan = goku.Add("Gohan");
        gohan.Add("Pan");
        
        goku.Add("Goten");
        
        Assert.Equal(4, goku.Count());
    }

    [Fact]
    public void Search_One()
    {
        var root = new TreeNode<int>(10);

        var node = root.Search(10);
        
        Assert.NotNull(node);
        Assert.Equal(10, node.Value);
    }
    
    [Fact]
    public void Search_NotFound()
    {
        var root = new TreeNode<int>(10);

        var node = root.Search(50);
        Assert.Null(node);
    }

    [Fact]
    public void Search_Children()
    {
        var goku = new TreeNode<string>("Goku");
        goku.Add("Gohan");
        
        var child = goku.Search("Gohan");
        
        Assert.NotNull(child);
        Assert.Equal("Gohan", child.Value);
    }
    
    [Fact]
    public void Search_GrandChildren()
    {
        var root = new TreeNode<string>("Goku");
        root.Add("Gohan").Add("Pan");
        
        var child = root.Search("Pan");
        
        Assert.NotNull(child);
        Assert.Equal("Pan", child.Value);
    }
}