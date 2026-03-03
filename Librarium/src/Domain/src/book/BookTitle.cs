using Error_definitions;

namespace Domain.book;

/// <summary>
/// Represents a book title.
/// Immutable value object that ensures titles are non-empty and properly trimmed.
/// </summary>
public class BookTitle
{
    public string Value { get; }

    public BookTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new BookInvalid("Book title cannot be null or empty.");
        Value = title.Trim();
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is BookTitle other && Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    public override int GetHashCode() => Value.ToUpperInvariant().GetHashCode();
}