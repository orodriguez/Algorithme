namespace Algorithme;

public class HashMap
{
    private readonly Bucket[] _buckets;
    private readonly int _capacity;

    public HashMap(int capacity = 10)
    {
        _capacity = capacity;
        _buckets = new Bucket[capacity];
        for (var i = 0; i < _buckets.Length; i++) 
            _buckets[i] = new Bucket();
    }

    public int this[char key]
    {
        get => Get(key);
        set => Set(key, value);
    }
    
    // O(1)
    private int Get(char key)
    {
        var index = Hash(key);
        var bucket = _buckets[index]; 
        return bucket.Get(key);
    }
    
    // O(1)
    private void Set(char key, int value)
    {
        var index = Hash(key);
        var bucket = _buckets[index];
        bucket.Set(key, value);
    }

    private int Hash(char key) => 
        key % _capacity;

    private class Bucket
    {
        private readonly LinkedList<(char key, int value)> _values;

        public Bucket() => 
            _values = new LinkedList<(char key, int value)>();

        public int Get(char key)
        {
            var keyValue = _values.FirstOrDefault(kv => kv.key == key);

            if (keyValue.key != key)
                throw new KeyNotFoundException();
            
            return keyValue.value;
        }

        public void Set(char key, int value)
        {
            var keyValue = _values.FirstOrDefault(kv => kv.key == key);

            if (keyValue.key == key)
                _values.Remove(keyValue);
            
            _values.AddLast((key, value));
        }
    }
}