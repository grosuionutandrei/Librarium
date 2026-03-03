using Domain.book;
using models.api_models;

namespace Librarium.Services.application_services.ports;
/// <summary>
/// Repository interface for Book persistence operations.
/// Defines contracts for retrieving and managing books in the database.
/// </summary>
public interface IBookRepository
{
    Task<IEnumerable<BooksDto>> GetAllBooksAsync();
    Task<IEnumerable<Book>> GetAllBooksWithAuthorsAsync();
}

