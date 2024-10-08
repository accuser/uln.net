using System;

namespace ULN
{
    public class ULN : IComparable<ULN>, IEquatable<ULN>
    {
        private readonly string _value;

        private ULN(string value)
        {
            _value = value;
        }

        public static ULN FromString(string value)
        {
            return new ULN(ULNValidator.RequireValidULN(value));
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ULN);
        }

        public bool Equals(ULN? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return _value == other._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(ULN? left, ULN? right)
        {
            if (left is null)
                return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(ULN? left, ULN? right)
        {
            return !(left == right);
        }

        public int CompareTo(ULN? other)
        {
            if (other is null)
                return 1;
            return string.Compare(_value, other._value, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return $"ULN({_value})";
        }
    }
}