using models.api_models;

namespace Librarium.Services.application_interfaces;

public interface IMemberService
{
    Task<List<MemberDto>> GetAllMembers();
}