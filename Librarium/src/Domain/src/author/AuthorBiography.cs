using Error_definitions;

namespace Domain.author;

/// <summary>
/// Represents an author's biography.
/// Immutable value object that ensures the biography does not exceed the maximum length.
/// Optional — an author may have no biography.
/// </summary>
public class AuthorBiography
{
    public string? Value { get; }

    private const int MaxLength = 2000;

    public AuthorBiography(string? biography)
    {
        if (biography != null && biography.Trim().Length > MaxLength)
            throw new AuthorInvalid($"Author biography cannot exceed {MaxLength} characters.");

        Value = biography?.Trim();
    }

    public override string ToString() => Value ?? string.Empty;
    public override bool Equals(object? obj) => obj is AuthorBiography other && Value == other.Value;
    public override int GetHashCode() => Value?.GetHashCode() ?? 0;
}

