
using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.dto;

namespace Librarium.Services.application_services.services;

public class BookService(IBookRepository bookRepository):IBookService
{
    public Task<List<BooksDto>> GetBooksByMemberId(int memberId)
    {
        throw new NotImplementedException();
    }

    public async  Task<List<BooksDto>> GetAllBooks()
    {
        var response = await bookRepository.GetAllBooksAsync();
        return response.ToList();
    }
}