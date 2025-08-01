namespace Algorithme;

public class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; set; }
    public int Level { get; private set; }

    public TreeNode(T value, int level = 0)
    {
        Value = value;
        Children = new List<TreeNode<T>>();
        Level = level;
    }

    public TreeNode<T> Add(T childValue)
    {
        var child = new TreeNode<T>(childValue, Level + 1);
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
    
    public int Height() => 
        Children.Any() 
            ? 1 + Children.Max(node => node.Height()) 
            : 0;
    
    // O(n)
    public void LevelTraverse(Action<TreeNode<T>> action)
    {
        var queue = new Queue<TreeNode<T>>();
        // O(1)
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            // O(1)
            var current = queue.Dequeue();
            action(current);

            foreach (var child in current.Children) 
                queue.Enqueue(child);
        }
    }
}