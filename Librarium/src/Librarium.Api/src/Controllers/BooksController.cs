using Error_definitions;
using Librarium.Services.application_interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Librarium.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BooksController(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        try
        {
            var books = await  bookService.GetAllBooks();
            return Ok(books);
        }
        catch (BookInvalid bookInvalid)
        {
            return NotFound( new BookError(BookError.Codes.BookNotFound, bookInvalid.Message));
        }
    }
}


[ApiController]
[Route("api/v2/[controller]")]
public class BooksV2Controller(IBookService bookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllBooksWithAuthors()
    {
        try
        {
            var books = await bookService.GetAllBooksWithAuthors();
            return Ok(books);
        }
        catch (BookInvalid bookInvalid)
        {
            return NotFound(new BookError(BookError.Codes.BookNotFound, bookInvalid.Message));
        }
    }
}


