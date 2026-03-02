
using Librarium.Data.domain;
using Librarium.Data.domain.book;
using Mappers;
using models.dto;


/// <summary>
/// Mapper for Book domain model, BookDto (database model), and BooksDto (API DTO).
/// Handles conversions between domain, persistence, and API layers.
/// </summary>
public class BookMapper : IMapper<Book, BooksDto>
{
    /// <summary>
    /// Maps a Book domain model to BooksDto (API response DTO).
    /// </summary>
    /// <param name="book">The domain Book model</param>
    /// <returns>BooksDto with API-friendly properties</returns>
    public BooksDto Map(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        return new BooksDto(
            Title: book.Title.Value,
            ISBN: book.Isbn.Value,
            year: book.PublicationYear.Value
        );
    }

    /// <summary>
    /// Maps a BooksDto (API DTO) back to a Book domain model.
    /// </summary>
    /// <param name="dto">The BooksDto with API data</param>
    /// <returns>A Book domain model instance</returns>
    public Book MapReverse(BooksDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        var isbn = new InternationalStandardBookNumber(dto.ISBN);
        var title = new BookTitle(dto.Title);
        var publicationYear = new PublicationYear(dto.year);

        return new Book(isbn, title, publicationYear);
    }
}

