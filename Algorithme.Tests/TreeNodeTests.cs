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
}

public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public TreeNode(T value)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
    }

    public TreeNode<T> Add(T childValue)
    {
        var child = new TreeNode<T>(childValue);
        Children.Add(child);
        return child;
    }

    public int Count() => 
        1 + Children.Sum(node => node.Count());
}