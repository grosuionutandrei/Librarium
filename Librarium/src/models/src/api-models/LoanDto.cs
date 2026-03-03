namespace models.api_models;

/// <summary>
/// Data Transfer Object for Loan.
/// Represents a loan record with member and book information.
/// Used in API responses and requests for loan operations.
/// </summary>
public record LoanDto(
    string BookIsbn,
    DateTime LoanDate,
    DateTime? ReturnDate);
