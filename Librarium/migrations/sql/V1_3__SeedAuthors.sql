USE Librarium
GO

INSERT INTO [Authors] ([AuthorId], [FirstName], [LastName], [Biography])
VALUES
    ('A1000000-0000-0000-0000-000000000001', 'Jane',      'Austen',      'Jane Austen was an English novelist known for her six major novels, including Pride and Prejudice.'),
    ('A1000000-0000-0000-0000-000000000002', 'George',    'Orwell',      'George Orwell was an English novelist and essayist, best known for 1984 and Animal Farm.'),
    ('A1000000-0000-0000-0000-000000000003', 'F. Scott',  'Fitzgerald',  'F. Scott Fitzgerald was an American novelist and short story writer, widely regarded as one of the greatest American writers of the 20th century.'),
    ('A1000000-0000-0000-0000-000000000004', 'J.D.',      'Salinger',    'J.D. Salinger was an American writer best known for his novel The Catcher in the Rye.'),
    ('A1000000-0000-0000-0000-000000000005', 'Harper',    'Lee',         'Harper Lee was an American novelist best known for To Kill a Mockingbird, which won the Pulitzer Prize in 1961.');

INSERT INTO [BookAuthors] ([AuthorsAuthorId], [BooksDtoIsbn])
VALUES
    ('A1000000-0000-0000-0000-000000000001', '978-0141439518'),  -- Jane Austen        -> Pride and Prejudice
    ('A1000000-0000-0000-0000-000000000002', '978-0451524935'),  -- George Orwell      -> 1984
    ('A1000000-0000-0000-0000-000000000003', '978-0743273565'),  -- F. Scott Fitzgerald -> The Great Gatsby
    ('A1000000-0000-0000-0000-000000000004', '978-0316769174'),  -- J.D. Salinger      -> The Catcher in the Rye
    ('A1000000-0000-0000-0000-000000000005', '978-0061120084');  -- Harper Lee         -> To Kill a Mockingbird

