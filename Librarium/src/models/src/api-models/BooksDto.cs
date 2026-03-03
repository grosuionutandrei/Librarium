

namespace models.api_models;
public record BooksDto(string Title, string ISBN, int year);
public record BooksWithAuthorsResponseDto(
    BooksDto Book,
    List<AuthorResponseDto> Authors
);