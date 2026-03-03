USE Librarium
    GO
CREATE TABLE [Authors] (
    [AuthorId] uniqueidentifier NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    [Biography] nvarchar(2000) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([AuthorId])
);

CREATE TABLE [BookAuthors] (
    [AuthorsAuthorId] uniqueidentifier NOT NULL,
    [BooksDtoIsbn] nvarchar(20) NOT NULL,
    CONSTRAINT [PK_BookAuthors] PRIMARY KEY ([AuthorsAuthorId], [BooksDtoIsbn]),
    CONSTRAINT [FK_BookAuthors_Authors_AuthorsAuthorId] FOREIGN KEY ([AuthorsAuthorId]) REFERENCES [Authors] ([AuthorId]) ON DELETE CASCADE,
    CONSTRAINT [FK_BookAuthors_Books_BooksDtoIsbn] FOREIGN KEY ([BooksDtoIsbn]) REFERENCES [Books] ([Isbn]) ON DELETE CASCADE
);

CREATE INDEX [IX_BookAuthors_BooksDtoIsbn] ON [BookAuthors] ([BooksDtoIsbn]);
