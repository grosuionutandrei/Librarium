using Error_definitions;
using Librarium.Data.domain.member;
using Microsoft.AspNetCore.Mvc;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
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

public class CreateMemberRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

