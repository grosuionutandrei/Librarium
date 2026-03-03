using Domain.member;
using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;
using models.api_models;

namespace Librarium.Data.infrastructure.repositories;

public class MemberRepository(AppDbContext _dbContext):IMemberRepository
{
    public async Task<IEnumerable<MemberDto>> GetAllMembers()
    {
        
        return await _dbContext.Members
            .Select(m => new MemberDto(
                m.FirstName,
                m.LastName,
                m.Email
            ))
            .ToListAsync();
    }

    public async Task<IEnumerable<Member>> GetAllMembersWithPhoneNumber()
    {
        return await _dbContext.Members.Select(m =>
            new Member(new MemberId(m.MemberId),m.FirstName,m.LastName, new Email(m.Email), new PhoneNumber(m.PhoneNumber))).ToListAsync();
    }
}