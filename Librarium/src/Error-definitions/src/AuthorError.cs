namespace Error_definitions;

/// <summary>
/// Represents an error state for author-related operations.
/// Simple data holder for error code and message.
/// </summary>
public class AuthorError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public AuthorError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Common author error codes
    /// </summary>
    public static class Codes
    {
        public const string InvalidFirstName = "AUTHOR_INVALID_FIRST_NAME";
        public const string InvalidLastName = "AUTHOR_INVALID_LAST_NAME";
        public const string InvalidBiography = "AUTHOR_INVALID_BIOGRAPHY";
        public const string AuthorNotFound = "AUTHOR_NOT_FOUND";
        public const string DuplicateAuthor = "AUTHOR_DUPLICATE";
        public const string InvalidAuthorState = "AUTHOR_INVALID_STATE";
    }
}

