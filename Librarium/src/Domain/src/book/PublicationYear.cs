using Error_definitions;

namespace Domain.book;

/// <summary>
/// Represents the publication year of a book.
/// Immutable value object that ensures the year is valid and reasonable.
/// </summary>
public class PublicationYear
{
    public int Value { get; }

    // Gutenberg's printing press invention - earliest reasonable publication year
    private const int MinimumYear = 1440;
    
    // Allow future publications up to 10 years from now
    private static int MaximumYear => DateTime.Now.Year + 10;

    public PublicationYear(int year)
    {
        if (year < MinimumYear || year > MaximumYear)
            throw new BookInvalid(
                $"Publication year must be between {MinimumYear} and {MaximumYear}.");

        Value = year;
    }

    public override string ToString() => Value.ToString();
    public override bool Equals(object? obj) => obj is PublicationYear other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}

