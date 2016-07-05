using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, IEnumerable<V>>>
    {
        public Dictionary<K, LinkedList<V>> Dictionary { get; }
        public MultiDictionary()
        {
            Dictionary = new Dictionary<K, LinkedList<V>>();
            Count = 0;
        }
        public void Add(K key, V value)
        {
            if (Dictionary.ContainsKey(key))
            {
                Dictionary[key].AddLast(value);
            }
            else
            {
                Dictionary.Add(key, new LinkedList<V>());
                Dictionary[key].AddLast(value);
            }
            Count++;
        }

        public bool Remove(K key)
        {
            int i = Dictionary[key].Count;
            if (!Dictionary.Remove(key)) return false;
            Count -= i;
            return true;
        }

        public bool Remove(K key, V value)
        {
            if (!Dictionary.ContainsKey(key))
                return false;
            if (!Dictionary[key].Remove(value))
                return false;
            Count--;
            return true;
        }

        public void Clear()
        {
            Dictionary.Clear();
            Count = 0;
        }

        public bool ContainsKey(K key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool Contains(K key, V value)
        {
            if (!Dictionary.ContainsKey(key))
            {
                return false;
            }
            return
                Dictionary[key].Contains(value);
        }

        public ICollection<K> Keys { get; }
        public ICollection<V> Values { get; }
        public int Count { get; private set; }

        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator()
        {
            var list = Dictionary.Select(item => new KeyValuePair<K, IEnumerable<V>>(item.Key, item.Value)).ToList();

            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
