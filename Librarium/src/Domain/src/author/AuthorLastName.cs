using Error_definitions;

namespace Domain.author;

/// <summary>
/// Represents an author's last name.
/// Immutable value object that ensures the name is non-empty and properly trimmed.
/// </summary>
public class AuthorLastName
{
    public string Value { get; }

    public AuthorLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new AuthorInvalid("Author last name cannot be null or empty.");
        if (lastName.Trim().Length > 100)
            throw new AuthorInvalid("Author last name cannot exceed 100 characters.");

        Value = lastName.Trim();
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is AuthorLastName other && Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
    public override int GetHashCode() => Value.ToUpperInvariant().GetHashCode();
}

