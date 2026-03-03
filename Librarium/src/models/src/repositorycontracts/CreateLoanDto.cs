namespace models.repositorycontracts;

public record CreateLoanDto(string MemberEmail, string Isbn,DateTime LoanDate,  DateTime? ReturnDate);