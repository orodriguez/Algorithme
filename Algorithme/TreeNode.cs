namespace Algorithme;

public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; }
    public int Level => throw new NotImplementedException();

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

    // O(n)
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

    public void PreOrderTraverse(Action<TreeNode<T>> action)
    {
        action(this);

        foreach (var child in Children) 
            child.PreOrderTraverse(action);
    }

    public void PostOrderTraverse(Action<TreeNode<T>> action)
    {
        foreach (var child in Children) 
            child.PostOrderTraverse(action);
        
        action(this);
    }
    
    public int Height()
    {
        throw new NotImplementedException();
    }

    public void LevelTraverse(Action<TreeNode<T>> action)
    {
        // Hint: Use Level
        throw new NotImplementedException();
    }
}