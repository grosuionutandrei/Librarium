namespace Error_definitions;

/// <summary>
/// Represents an error state for loan-related operations.
/// Simple data holder for error code and message.
/// </summary>
public class LoanError
{
    public string Code { get; set; }
    public string Message { get; set; }

    public LoanError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Common loan error codes
    /// </summary>
    public static class Codes
    {
        public const string InvalidMember = "LOAN_INVALID_MEMBER";
        public const string InvalidBook = "LOAN_INVALID_BOOK";
        public const string InvalidLoanDate = "LOAN_INVALID_LOAN_DATE";
        public const string InvalidReturnDate = "LOAN_INVALID_RETURN_DATE";
        public const string LoanNotFound = "LOAN_NOT_FOUND";
        public const string BookAlreadyLoaned = "LOAN_BOOK_ALREADY_LOANED";
        public const string InvalidLoanState = "LOAN_INVALID_STATE";
    }
}

