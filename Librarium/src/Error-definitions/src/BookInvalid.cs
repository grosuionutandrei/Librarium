namespace Error_definitions;

/// <summary>
/// Exception thrown when a Book is in an invalid state.
/// Used to represent domain validation errors for book-related operations.
/// </summary>
public class BookInvalid : Exception
{
    public BookInvalid(string message) : base(message)
    {
    }

    public BookInvalid(string message, Exception innerException) : base(message, innerException)
    {
    }
}


