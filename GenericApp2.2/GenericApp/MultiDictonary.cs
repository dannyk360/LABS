using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>, IEnumerable<KeyValuePair<K, IEnumerable<V>>> where K:struct where V:new()
    {
        public Dictionary<K, LinkedList<V>> Dictionary { get; }
        
        public MultiDictionary()
        {
            Dictionary = new Dictionary<K, LinkedList<V>>();
            Count = 0;
        }
        public void Add(K key, V value)
        {
            if(typeof(K).GetCustomAttributes(typeof(KeyAttribute),true) == null)
                throw new Exception("Key must have attribute");
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

        public void CreateNewValue(K key) 
        {
            Add(key, new V());
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
            {
                
                return false;
            }
            if (!Dictionary[key].Remove(value))
            {
                
                return false;
            }
            
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
            
            var result = Dictionary.ContainsKey(key);
            
            return result;
        }

        public bool Contains(K key, V value)
        {
            
            if (!Dictionary.ContainsKey(key))
            {
                return false;
            }
            var res = Dictionary[key].Contains(value);
           
            return res;
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

    public class KeyAttribute : Attribute
    {

    }
}
