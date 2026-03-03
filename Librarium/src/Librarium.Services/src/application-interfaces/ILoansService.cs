using models.api_models;

namespace Librarium.Services.application_interfaces;

public interface ILoansService
{
    Task<List<LoanDto>> GetLoansByMember(string memberEmail);
    Task<CreateLoanResponse> CreateLoan(CreateLoanRequest request);
}