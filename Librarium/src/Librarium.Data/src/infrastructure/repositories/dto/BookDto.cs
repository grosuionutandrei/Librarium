using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Librarium.Data.infrastructure.repositories.dto;

/// <summary>
/// Data Transfer Object for Book entity.
/// Used for database persistence and API communication.
/// </summary>
public class BookDto
{
    [Key]
    public string? Isbn { get; set; }

    [NotNull]
    public string? Title { get; set; }

    public int PublicationYear { get; set; }
}