namespace Algorithme;

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

    public TreeNode<T> Search(T value)
    {
        // O(1)
        if (Equals(Value, value))
            return this;

        // O(n)
        return Children
            .Select(child => child.Search(value))
            .FirstOrDefault(node => node != null);
    }
}