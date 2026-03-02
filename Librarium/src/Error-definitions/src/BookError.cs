namespace Error_definitions;

/// <summary>
/// Represents an error state for book-related operations.
/// Simple data holder for error code and message.
/// </summary>
public class BookError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public BookError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Common book error codes
    /// </summary>
    public static class Codes
    {
        public const string InvalidIsbn = "BOOK_INVALID_ISBN";
        public const string InvalidTitle = "BOOK_INVALID_TITLE";
        public const string InvalidPublicationYear = "BOOK_INVALID_PUBLICATION_YEAR";
        public const string BookNotFound = "BOOK_NOT_FOUND";
        public const string DuplicateIsbn = "BOOK_DUPLICATE_ISBN";
        public const string InvalidBookState = "BOOK_INVALID_STATE";
    }
}