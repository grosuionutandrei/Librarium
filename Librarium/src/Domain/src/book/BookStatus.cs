namespace Domain.book;

public class LoanStatus
{
    public string Value { get; }
    private static readonly HashSet<string> AllowedValues =
        new(StringComparer.OrdinalIgnoreCase)
        {
            "Active", "Returned", "Overdue", "Lost"
        };
    private LoanStatus(string value) => Value = value;

    public static LoanStatus From(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !AllowedValues.Contains(value))
            throw new ArgumentException($"'{value}' is not a valid LoanStatus. Allowed: {string.Join(", ", AllowedValues)}");
     
        return new LoanStatus(AllowedValues.First(v => v.Equals(value, StringComparison.OrdinalIgnoreCase)));
    }
    
    public static LoanStatus Active   => new("Active");
    public static LoanStatus Returned => new("Returned");
    public static LoanStatus Overdue  => new("Overdue");
    public static LoanStatus Lost     => new("Lost");

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is LoanStatus other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}