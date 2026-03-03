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
}