namespace Algorithme;

public class HashMap<TKey, TValue>
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

    public TValue this[TKey key]
    {
        get => Get(key);
        set => Set(key, value);
    }
    
    // O(1)
    private TValue Get(TKey key)
    {
        var index = Hash(key);
        var bucket = _buckets[index]; 
        return bucket.Get(key);
    }
    
    // O(n) | O(1)
    private void Set(TKey key, TValue value)
    {
        var index = Hash(key);
        var bucket = _buckets[index];
        bucket.Set(key, value);
    }

    private int Hash(TKey key) => 
        Math.Abs(key.GetHashCode()) % _capacity;

    private class Bucket
    {
        private readonly LinkedList<(TKey key, TValue value)> _values;

        public Bucket() => 
            _values = new LinkedList<(TKey key, TValue value)>();

        public TValue Get(TKey key)
        {
            var keyValue = _values.FirstOrDefault(kv => Equals(kv.key, key));

            if (Equals(keyValue.key, default(TKey)))
                throw new KeyNotFoundException();
            
            return keyValue.value;
        }

        public void Set(TKey key, TValue value)
        {
            var keyValue = _values.FirstOrDefault(kv => Equals(kv.key, key));

            if (!Equals(keyValue.key, default(TKey)))
                _values.Remove(keyValue);
            
            _values.AddLast((key, value));
        }
    }
}