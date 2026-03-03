using Error_definitions;
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
    
}


