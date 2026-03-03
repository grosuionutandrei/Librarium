namespace models.repositorycontracts;

public record CreateLoanRequest(string MemberEmail, string Isbn,DateTime LoanDate,  DateTime? ReturnDate);