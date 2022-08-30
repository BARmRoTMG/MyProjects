using System;

namespace DataStructures
{
    public class HashTable<TKey, TValue>
    {
        DoubleLinkedList<Data>[] hash;

        public HashTable(int cap = 1024)
        {
            hash = new DoubleLinkedList<Data>[cap];
        }

        public void Add(TKey key, TValue value)
        {
            int index = GetIndexByKey(key);

            if(hash[index] == null)
                hash[index] = new DoubleLinkedList<Data>();

            hash[index].AddLast(new Data(key, value));
        }

        private int GetIndexByKey(TKey key)
        {
            int hashValue = key.GetHashCode();
            return hashValue % hash.Length;
        }

        class Data
        {
            public TKey key;
            public TValue value;

            public Data(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}
