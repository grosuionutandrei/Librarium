
using Librarium.Data.domain.book;
using Librarium.Data.infrastructure.repositories.dto;
using Librarium.Services.application_services.ports;
using Microsoft.EntityFrameworkCore;
using models.dto;

namespace Librarium.Data.infrastructure.repositories;


/// <summary>
/// Implementation of the BookRepository interface.
/// Handles all database operations for books using Entity Framework Core.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    // /// <summary>
    // /// Retrieves a book by its ISBN from the database.
    // /// </summary>
    // /// <param name="isbn">The International Standard Book Number</param>
    // /// <returns>The book if found; otherwise null</returns>
    // public async Task<Book?> GetByIsbnAsync(string isbn)
    // {
    //     if (string.IsNullOrWhiteSpace(isbn))
    //         return null;
    //
    //     return new Book();
    // }

    /// <summary>
    /// Retrieves all books from the database.
    /// </summary>
    /// <returns>A collection of all books</returns>
    public async Task<IEnumerable<BooksDto>> GetAllBooksAsync()
    {
        return await _dbContext.Books
            .Where(b => b.Isbn != null)
            .Select(b => new BooksDto(
                b.Title,
                b.Isbn!,
                b.PublicationYear
            ))
            .ToListAsync();
    }
    
    
    

  







  

 

  
}

