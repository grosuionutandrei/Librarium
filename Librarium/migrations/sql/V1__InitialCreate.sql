
USE Librarium
GO

CREATE TABLE [Books] (
    [Isbn] nvarchar(20) NOT NULL,
    [Title] nvarchar(500) NOT NULL,
    [PublicationYear] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Isbn])
    );

CREATE TABLE [Members] (
    [Email] nvarchar(255) NOT NULL,
    [FirstName] nvarchar(100) NOT NULL,
    [LastName] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Members] PRIMARY KEY ([Email])
    );

CREATE TABLE [Loans] (
    [MemberEmail] nvarchar(255) NOT NULL,
    [BookIsbn] nvarchar(20) NOT NULL,
    [LoanDate] datetime2 NOT NULL,
    [ReturnDate] datetime2 NULL,
    CONSTRAINT [PK_Loans] PRIMARY KEY ([MemberEmail], [BookIsbn]),
    CONSTRAINT [FK_Loans_Books_BookIsbn]
    FOREIGN KEY ([BookIsbn])
    REFERENCES [Books] ([Isbn])
    ON DELETE NO ACTION,
    CONSTRAINT [FK_Loans_Members_MemberEmail]
    FOREIGN KEY ([MemberEmail])
    REFERENCES [Members] ([Email])
    ON DELETE NO ACTION
    );

CREATE INDEX [IX_Loans_BookIsbn]
    ON [Loans] ([BookIsbn]);