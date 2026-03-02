
using models.dto;

namespace Librarium.Services.application_interfaces;

public interface IBookService
{
    Task<List<BooksDto>> GetBooksByMemberId(int memberId);
    Task <List<BooksDto>> GetAllBooks();
}