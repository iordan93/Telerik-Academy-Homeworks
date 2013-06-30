using System;

internal class Entry<TKey1, TKey2, TValue> : IEquatable<Entry<TKey1, TKey2, TValue>>
{
    public Entry(TKey1 firstKey, TKey2 secondKey, TValue value)
    {
        this.FirstKey = firstKey;
        this.SecondKey = secondKey;
        this.Value = value;
    }

    public TKey1 FirstKey { get; private set; }

    public TKey2 SecondKey { get; private set; }

    public TValue Value { get; private set; }

    public override bool Equals(object obj)
    {
        return this.Equals(obj as Entry<TKey1, TKey2, TValue>);
    }

    public bool Equals(Entry<TKey1, TKey2, TValue> other)
    {
        if (other != null)
        {
            return this.FirstKey.Equals(other.FirstKey) && this.SecondKey.Equals(other.SecondKey) && this.Value.Equals(other.Value);
        }

        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = 0;

            hashCode ^= this.FirstKey.GetHashCode();
            hashCode ^= this.SecondKey.GetHashCode();
            hashCode ^= this.Value.GetHashCode();

            return hashCode;
        }
    }
}
