using Error_definitions;
using Librarium.Services.application_interfaces;
using Microsoft.AspNetCore.Mvc;
using models.api_models;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoansController(ILoansService loansService) : ControllerBase
{
    // POST /api/loans
    [HttpPost]
    public async Task<IActionResult> CreateLoan([FromBody] CreateLoanRequest request)
    {
        var response = await  loansService.CreateLoan(request);
        if (!response.Created)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    // GET /api/loans/{memberId}
    [HttpGet("{memberEmail}")]
    public async Task<IActionResult> GetLoansByMember(string memberEmail)
    {
        try
        {
            var response = await loansService.GetLoansByMember(memberEmail);
            return Ok(response);
        }
        catch (LoanInvalid ex)
        {
            return  NotFound(new LoanError(LoanError.Codes.LoanNotFound, ex.Message));
        }

    }
}


public record LoanDto(Guid LoanId, string MemberId, string Isbn, DateTime LoanDate);