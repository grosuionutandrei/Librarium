using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;
using models.dto;
using models.repositorycontracts;

namespace Librarium.Data.infrastructure.repositories;

public class LoansRepository(AppDbContext appDbContext):ILoanRepository
{
    public async Task<IEnumerable<LoanDto>> GetLoansByMember(string memberEmail)
    {
        var response = await appDbContext.Loans
            .Where(l => l.MemberEmail == memberEmail)
            .Select(l => new LoanDto(
                l.BookIsbn,
                l.LoanDate,
                l.ReturnDate))
            .ToListAsync();
        
        return response;
    }
//Todo check first if a book is available 
    public async Task<CreateLoanResponse> CreateLoan(CreateLoanDto request)
    {
        try
        {
            var loanDto = new Librarium.Data.infrastructure.repositories.dto.LoanDto
            {
                MemberEmail = request.MemberEmail,
                BookIsbn = request.Isbn,
                LoanDate = request.LoanDate,
                ReturnDate = request.ReturnDate
            };
            await appDbContext.Loans.AddAsync(loanDto);
            await appDbContext.SaveChangesAsync();
            return new CreateLoanResponse(true);
        }
        catch (Exception ex)
        {
            return new CreateLoanResponse(false);
        }
    }
}