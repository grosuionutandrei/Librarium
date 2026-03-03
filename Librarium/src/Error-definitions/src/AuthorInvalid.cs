namespace Error_definitions;

/// <summary>
/// Exception thrown when an Author is in an invalid state.
/// Used to represent domain validation errors for author-related operations.
/// </summary>
public class AuthorInvalid : Exception
{
    public AuthorInvalid(string message) : base(message)
    {
    }

    public AuthorInvalid(string message, Exception innerException) : base(message, innerException)
    {
    }
}

