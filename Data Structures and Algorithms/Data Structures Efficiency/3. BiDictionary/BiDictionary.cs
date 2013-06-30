using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class BiDictionary<TKey1, TKey2, TValue>
{
    private readonly MultiDictionary<TKey1, Entry<TKey1, TKey2, TValue>> orderedByFirstKey = null;
    private readonly MultiDictionary<TKey2, Entry<TKey1, TKey2, TValue>> orderedBySecondKey = null;
    private readonly MultiDictionary<Tuple<TKey1, TKey2>, Entry<TKey1, TKey2, TValue>> orderedByKey1Key2 = null;

    public BiDictionary(bool allowDuplicates)
    {
        this.orderedByFirstKey = new MultiDictionary<TKey1, Entry<TKey1, TKey2, TValue>>(allowDuplicates);
        this.orderedBySecondKey = new MultiDictionary<TKey2, Entry<TKey1, TKey2, TValue>>(allowDuplicates);
        this.orderedByKey1Key2 = new MultiDictionary<Tuple<TKey1, TKey2>, Entry<TKey1, TKey2, TValue>>(allowDuplicates);
    }

    public int Count
    {
        get
        {
            return this.orderedByKey1Key2.KeyValuePairs.Count;
        }
    }

    public void Add(TKey1 firstKey, TKey2 secondKey, TValue value)
    {
        var entry = new Entry<TKey1, TKey2, TValue>(firstKey, secondKey, value);

        this.orderedByFirstKey.Add(firstKey, entry);
        this.orderedBySecondKey.Add(secondKey, entry);

        var key1key2 = new Tuple<TKey1, TKey2>(firstKey, secondKey);
        this.orderedByKey1Key2.Add(key1key2, entry);
    }

    public ICollection<TValue> GetByFirstKey(TKey1 key1)
    {
        return this.orderedByFirstKey[key1].Select(entry => entry.Value).ToArray();
    }

    public void RemoveByFirstKey(TKey1 key1)
    {
        var entries = this.orderedByFirstKey[key1];

        foreach (var entry in entries)
        {
            this.orderedBySecondKey.Remove(entry.SecondKey, entry);

            var key1key2 = new Tuple<TKey1, TKey2>(entry.FirstKey, entry.SecondKey);
            this.orderedByKey1Key2.Remove(key1key2, entry);
        }

        this.orderedByFirstKey.Remove(key1);
    }

    public ICollection<TValue> GetBySecondKey(TKey2 key2)
    {
        return this.orderedBySecondKey[key2].Select(entry => entry.Value).ToArray();
    }

    public void RemoveBySecondKey(TKey2 key2)
    {
        var entries = this.orderedBySecondKey[key2];

        foreach (var entry in entries)
        {
            this.orderedByFirstKey.Remove(entry.FirstKey, entry);

            var key1key2 = new Tuple<TKey1, TKey2>(entry.FirstKey, entry.SecondKey);
            this.orderedByKey1Key2.Remove(key1key2, entry);
        }

        this.orderedBySecondKey.Remove(key2);
    }

    public ICollection<TValue> GetByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var key1key2 = new Tuple<TKey1, TKey2>(key1, key2);

        return this.orderedByKey1Key2[key1key2].Select(entry => entry.Value).ToArray();
    }

    public void RemoveByFirstAndSecondKey(TKey1 key1, TKey2 key2)
    {
        var tuple = new Tuple<TKey1, TKey2>(key1, key2);
        var entries = this.orderedByKey1Key2[tuple];

        foreach (var entry in entries)
        {
            this.orderedByFirstKey.Remove(entry.FirstKey, entry);
            this.orderedBySecondKey.Remove(entry.SecondKey, entry);
        }

        this.orderedByKey1Key2.Remove(tuple);
    }
}