using Microsoft.AspNetCore.Mvc;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController : ControllerBase
{
    // POST /api/loans
    [HttpPost]
    public IActionResult CreateLoan([FromBody] CreateLoanRequest request)
    {
        // TODO: Validate Member and Book existence via Domain/Repository
        // TODO: Create Loan domain entity 
        
        return Created("", new { message = "Loan created successfully" });
    }

    // GET /api/loans/{memberId}
    [HttpGet("{memberId}")]
    public IActionResult GetLoansByMember(string memberId)
    {
        // TODO: Fetch loans for this specific member from Repository
        var loans = new List<LoanDto>
        {
            new LoanDto(Guid.NewGuid(), memberId, "978-3-16-148410-0", DateTime.UtcNow)
        };

        return Ok(loans);
    }
}

public record CreateLoanRequest(string MemberId, string Isbn);
public record LoanDto(Guid LoanId, string MemberId, string Isbn, DateTime LoanDate);