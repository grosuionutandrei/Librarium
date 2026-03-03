using Error_definitions;
using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.api_models;
using models.repositorycontracts;

namespace Librarium.Services.application_services.services;

public class LoanService(ILoanRepository loanRepository):ILoansService
{
    public async  Task<List<LoanDto>> GetLoansByMember(string memberEmail)
    {
        try
        {
            var response = await loanRepository.GetLoansByMember(memberEmail);
            return response.ToList();
        }
        catch (Exception ex)
        {
            throw new LoanInvalid("GetLoansByMember", ex);
        }

    }

    public async Task<CreateLoanResponse> CreateLoan(CreateLoanRequest request)
    {
        try
        {
            var loanDto = new CreateLoanDto(request.MemberEmail, request.Isbn, DateTime.UtcNow, request.ReturnDate);
            var response = await loanRepository.CreateLoan(loanDto);
            return response;
        }
        catch (Exception ex)
        {
            return new CreateLoanResponse(false);
        }
    }
}