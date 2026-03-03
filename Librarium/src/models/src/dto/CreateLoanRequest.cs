namespace models.dto;

public record CreateLoanRequest(string MemberEmail, string Isbn,DateTime? ReturnDate);