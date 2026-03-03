using Error_definitions;

namespace Domain.author;

/// <summary>
/// Represents an Author aggregate root in the domain model.
/// Encapsulates author information using value objects for strong typing and validation.
/// </summary>
public class Author
{
    public Guid Id { get; }
    public AuthorFirstName FirstName { get; }
    public AuthorLastName LastName { get; }
    public AuthorBiography Biography { get; }

    public Author(AuthorFirstName firstName, AuthorLastName lastName, AuthorBiography biography)
    {
        if (firstName == null)
            throw new AuthorInvalid("First name cannot be null.");
        if (lastName == null)
            throw new AuthorInvalid("Last name cannot be null.");
        if (biography == null)
            throw new AuthorInvalid("Biography cannot be null.");

        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Biography = biography;
    }
    public Author(Guid authorId,AuthorFirstName firstName, AuthorLastName lastName, AuthorBiography biography)
    {
        if (firstName == null)
            throw new AuthorInvalid("First name cannot be null.");
        if (lastName == null)
            throw new AuthorInvalid("Last name cannot be null.");
        if (biography == null)
            throw new AuthorInvalid("Biography cannot be null.");

        Id = authorId;
        FirstName = firstName;
        LastName = lastName;
        Biography = biography;
    }
    

    public override string ToString() => $"{FirstName} {LastName}";
}

