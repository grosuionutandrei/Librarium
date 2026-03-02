using Error_definitions;
using Librarium.Data.domain.member;
using Librarium.Services.application_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController(IMemberService memberService) : ControllerBase
{
    // GET /api/members
    [HttpGet]
    public async Task<IActionResult> GetAllMembers()
    {
        try
        {
            var response = await memberService.GetAllMembers();
            return Ok(response);

        }
        catch(MemberInvalid)
        {
            return NotFound(new { message = "Member not found" });
        }
        
    }

    /// <summary>
    /// Creates a new member with email validation
    /// </summary>
    [HttpPost]
    public IActionResult CreateMember([FromBody] CreateMemberRequest request)
    {
        try
        {
            // Domain model validates and throws MemberInvalid if something is wrong
            var email = new Email(request.Email);
            var member = new Member(request.FirstName, request.LastName, email);

            // If we get here, member is valid
            // In a real scenario, map 'member' domain object to a DTO before returning
            return Ok(new { message = "Member created successfully", member });
        }
        catch (MemberInvalid ex)
        {
            // Convert domain exception to MemberError for API response
            var error = new MemberError(MemberError.Codes.InvalidMemberState, ex.Message);
            return BadRequest(error);
        }
    }
}

// Request Models
public record CreateMemberRequest(string FirstName, string LastName, string Email);
public record MemberDto(string FirstName, string LastName, string Email);

