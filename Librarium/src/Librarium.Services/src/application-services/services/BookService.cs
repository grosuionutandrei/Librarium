
using Librarium.Services.application_interfaces;
using Librarium.Services.application_services.ports;
using models.api_models;

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

    public async Task<List<BooksWithAuthorsResponseDto>> GetAllBooksWithAuthors()
    {
        var response = await bookRepository.GetAllBooksWithAuthorsAsync();
        return response.Select(b => new BooksWithAuthorsResponseDto(
            new BooksDto(b.Title.Value, b.Isbn.Value, b.PublicationYear.Value),
            b.Authors.Select(a => new AuthorResponseDto(a.FirstName.Value, a.LastName.Value)).ToList()
        )).ToList();
    }
}