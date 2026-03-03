using Error_definitions;

namespace Domain.author;

/// <summary>
/// Represents an author's first name.
/// Immutable value object that ensures the name is non-empty and properly trimmed.
/// </summary>
public class AuthorFirstName
{
    public string Value { get; }

    public AuthorFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new AuthorInvalid("Author first name cannot be null or empty.");
        if (firstName.Trim().Length > 100)
            throw new AuthorInvalid("Author first name cannot exceed 100 characters.");

        Value = firstName.Trim();
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is AuthorFirstName other && Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    public override int GetHashCode() => Value.ToUpperInvariant().GetHashCode();
}

