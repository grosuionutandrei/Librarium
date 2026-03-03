using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.api_models;

namespace Librarium.Services.application_services.services;

public class MemberService(IMemberRepository memberRepository):IMemberService
{
    public  async  Task<List<MemberDto>> GetAllMembers()
    {

        var response = await memberRepository.GetAllMembers();
        return response.ToList();
    }

    public async Task<List<MemberWithPhoneNumberDto>> GetAllMembersWithPhoneNumber()
    {
        
        var response = await memberRepository.GetAllMembersWithPhoneNumber();
        return response.Select(m=> new MemberWithPhoneNumberDto(m.MemberId.Id,m.FirstName,m.LastName,m.Email.ToString(),m.PhoneNumber.ToString())).ToList();
    }
}