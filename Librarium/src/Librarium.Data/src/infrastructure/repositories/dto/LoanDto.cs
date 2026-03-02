using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.infrastructure.repositories.dto;

/// <summary>
/// Data Transfer Object for Loan entity.
/// Composite primary key: MemberEmail + BookIsbn (configured via Fluent API in AppDbContext).
/// MemberEmail is a FK to Members table, BookIsbn is a FK to Books table.
/// </summary>
public class LoanDto
{
    [NotNull]
    [MaxLength(255)]
    public string? MemberEmail { get; set; }

    [NotNull]
    [MaxLength(20)]
    public string? BookIsbn { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    // Navigation properties
    public MemberDto? Member { get; set; }
    public BookDto? Book { get; set; }
}

