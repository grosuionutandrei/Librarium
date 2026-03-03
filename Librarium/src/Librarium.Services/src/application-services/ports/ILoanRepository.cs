using models.dto;
using models.repositorycontracts;

namespace Librarium.Services.application_services.ports;

public interface ILoanRepository
{
Task <IEnumerable<LoanDto>> GetLoansByMember(string memberEmail);
Task <CreateLoanResponse> CreateLoan(CreateLoanDto request);
}