using Error_definitions;

namespace Domain.book;
/// <summary>
/// Represents an International Standard Book Number (ISBN).
/// ISBN is stored as a string to preserve formatting, leading zeros, and hyphens.
/// Supports both ISBN-10 (10 digits) and ISBN-13 (13 digits) formats.
/// </summary>
public class InternationalStandardBookNumber
{
    public string Value { get; }

    public InternationalStandardBookNumber(string isbn)
    {
        if (string.IsNullOrWhiteSpace(isbn))
            throw new BookInvalid("ISBN cannot be null or empty.");

        // Remove hyphens and spaces for validation
        var cleanIsbn = isbn.Replace("-", "").Replace(" ", "");

        // Validate ISBN-10 or ISBN-13 format
        if (!IsValidIsbn(cleanIsbn))
            throw new BookInvalid("Invalid ISBN format. Must be ISBN-10 or ISBN-13.");

        Value = isbn;
    }

    private static bool IsValidIsbn(string isbn)
    {
        // Remove any non-alphanumeric characters
        var cleaned = System.Text.RegularExpressions.Regex.Replace(isbn, "[^0-9X]", "");

        if (cleaned.Length == 10)
            return IsValidIsbn10(cleaned);
        
        if (cleaned.Length == 13)
            return IsValidIsbn13(cleaned);

        return false;
    }

    private static bool IsValidIsbn10(string isbn)
    {
        if (isbn.Length != 10)
            return false;

        // Last character can be 'X' (represents 10)
        if (!char.IsDigit(isbn[9]) && isbn[9] != 'X')
            return false;

        var sum = 0;
        for (int i = 0; i < 9; i++)
        {
            if (!char.IsDigit(isbn[i]))
                return false;
            sum += (int.Parse(isbn[i].ToString())) * (10 - i);
        }

        var checkDigit = isbn[9] == 'X' ? 10 : int.Parse(isbn[9].ToString());
        sum += checkDigit;

        return sum % 11 == 0;
    }

    private static bool IsValidIsbn13(string isbn)
    {
        if (isbn.Length != 13 || !isbn.All(char.IsDigit))
            return false;

        var sum = 0;
        for (int i = 0; i < 12; i++)
        {
            var digit = int.Parse(isbn[i].ToString());
            sum += (i % 2 == 0) ? digit : digit * 3;
        }

        var checkDigit = (10 - (sum % 10)) % 10;
        return checkDigit == int.Parse(isbn[12].ToString());
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is InternationalStandardBookNumber other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}