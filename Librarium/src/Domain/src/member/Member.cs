using Error_definitions;

namespace Domain.member;
/// <summary>
/// Represents a library member.
/// Encapsulates member information using value objects for strong typing and validation.
/// </summary>
public class Member
{
    public string FirstName { get; }
    public string LastName { get; }
    public Email Email { get; }

    public Member(string firstName, string lastName, Email email)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new MemberInvalid("First name cannot be null or empty.");
        if (string.IsNullOrWhiteSpace(lastName))
            throw new MemberInvalid("Last name cannot be null or empty.");
        if (email == null)
            throw new MemberInvalid("Email cannot be null.");

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
        Email = email;
    }
}