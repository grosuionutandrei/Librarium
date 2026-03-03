using models.api_models;

namespace Librarium.Services.application_interfaces;

public interface IBookService
{
    Task<List<BooksDto>> GetBooksByMemberId(int memberId);
    Task <List<BooksDto>> GetAllBooks();
    Task<List<BooksWithAuthorsResponseDto>> GetAllBooksWithAuthors();
}