using Error_definitions;

namespace Domain.member;

/// <summary>
/// Represents an email address.
/// Immutable value object that validates email format and domain.
/// </summary>
public class Email
{
    public string Value { get; }

    private static readonly string[] AllowedDomains = 
    { 
        "gmail.com", 
        "yahoo.com", 
        "outlook.com", 
        "hotmail.com", 
        "icloud.com",
        "protonmail.com",
        "mail.com"
    };

    private static readonly string[] AllowedExtensions = 
    { 
        ".com", 
        ".org", 
        ".net", 
        ".edu", 
        ".gov", 
        ".co.uk",
        ".de",
        ".fr",
        ".it",
        ".es",
        ".pt",
        ".nl",
        ".be",
        ".ch",
        ".at",
        ".se",
        ".no",
        ".dk",
        ".fi",
        ".pl",
        ".cz",
        ".ro",
        ".gr",
        ".ie"
    };

    public Email(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new MemberInvalid("Email cannot be null or empty.");

        var trimmedEmail = email.Trim().ToLowerInvariant();

        if (!IsValidEmail(trimmedEmail))
            throw new MemberInvalid("Invalid email format. Email must contain '@' and a valid domain.");

        Value = trimmedEmail;
    }

    private static bool IsValidEmail(string email)
    {
        // Check for @ symbol
        var atIndex = email.LastIndexOf('@');
        if (atIndex < 1 || atIndex == email.Length - 1)
            return false;

        var localPart = email[..atIndex];
        var domain = email[(atIndex + 1)..];

        // Validate local part (before @)
        if (!IsValidLocalPart(localPart))
            return false;

        // Validate domain
        if (!IsValidDomain(domain))
            return false;

        return true;
    }

    private static bool IsValidLocalPart(string localPart)
    {
        if (string.IsNullOrEmpty(localPart) || localPart.Length > 64)
            return false;

        // Allow alphanumeric, dots, hyphens, underscores
        return System.Text.RegularExpressions.Regex.IsMatch(localPart, @"^[a-z0-9._-]+$");
    }

    private static bool IsValidDomain(string domain)
    {
        if (string.IsNullOrEmpty(domain) || domain.Length > 255)
            return false;

        // Check if domain has valid extension
        var hasValidExtension = AllowedExtensions.Any(ext => domain.EndsWith(ext));
        if (!hasValidExtension)
            return false;

        // Allow any domain with valid extension (not just predefined ones)
        // But validate the domain format
        return System.Text.RegularExpressions.Regex.IsMatch(domain, @"^[a-z0-9][a-z0-9.-]*[a-z0-9]$");
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is Email other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}

