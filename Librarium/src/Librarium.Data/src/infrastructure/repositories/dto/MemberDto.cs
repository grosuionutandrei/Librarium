using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.infrastructure.repositories.dto;

/// <summary>
/// Data Transfer Object for Member entity.
/// Used for database persistence and API communication.
/// </summary>
public class MemberDto
{
    [NotNull]
    public Guid MemberId { get; set; }
    
    [NotNull]
    public string? FirstName { get; set; }

    [NotNull]
    public string? LastName { get; set; }

    [Key]
    public string? Email { get; set; }
    [NotNull]
    public string PhoneNumber { get; set; }
}
