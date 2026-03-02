namespace Error_definitions;

/// <summary>
/// Exception thrown when a Loan is in an invalid state.
/// Used to represent domain validation errors for loan-related operations.
/// </summary>
public class LoanInvalid : Exception
{
    public LoanInvalid(string message) : base(message)
    {
    }

    public LoanInvalid(string message, Exception innerException) : base(message, innerException)
    {
    }
}

