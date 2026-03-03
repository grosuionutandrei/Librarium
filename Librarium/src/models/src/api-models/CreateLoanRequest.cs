namespace models.api_models;

public record CreateLoanRequest(string MemberEmail, string Isbn,DateTime? ReturnDate);