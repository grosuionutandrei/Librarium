using Error_definitions;

namespace Librarium.Data.domain.book;

/// <summary>
/// Represents a Book aggregate root in the domain model.
/// Encapsulates book information using value objects for strong typing and validation.
/// </summary>
public class Book
{
    public int Id { get; set; }
    public InternationalStandardBookNumber Isbn { get; }
    public BookTitle Title { get; }
    public PublicationYear PublicationYear { get; }

    public Book(InternationalStandardBookNumber isbn, BookTitle title, PublicationYear publicationYear)
    {
        if (isbn == null)
            throw new BookInvalid("ISBN cannot be null.");
        if (title == null)
            throw new BookInvalid("Title cannot be null.");
        if (publicationYear == null)
            throw new BookInvalid("Publication year cannot be null.");

        Isbn = isbn;
        Title = title;
        PublicationYear = publicationYear;
    }

    public override string ToString() => $"{Title} (ISBN: {Isbn}, Year: {PublicationYear})";
}