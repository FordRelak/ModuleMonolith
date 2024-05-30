namespace ModuleMonolith.Framework.Domain;
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject? left, ValueObject? right) => Equals(left, right);

    public static bool operator !=(ValueObject? left, ValueObject? right) => !Equals(left, right);

    public override int GetHashCode()
    {
        IEnumerable<int> EqualityComponentsEnumerable()
        {
            foreach (var x in GetEqualityComponents())
                yield return x?.GetHashCode() ?? 0;
        }

        return EqualityComponentsEnumerable().Aggregate((int a, int b) => a ^ b);
    }

    public bool Equals(ValueObject? other) => Equals((object?)other);
}
