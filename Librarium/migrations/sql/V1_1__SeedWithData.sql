INSERT INTO [Books] ([Isbn], [Title], [PublicationYear])
VALUES
    ('978-0141439518', 'Pride and Prejudice', 1813),
    ('978-0451524935', '1984', 1949),
    ('978-0743273565', 'The Great Gatsby', 1925),
    ('978-0316769174', 'The Catcher in the Rye', 1951),
    ('978-0061120084', 'To Kill a Mockingbird', 1960);

INSERT INTO [Members] ([Email], [FirstName], [LastName])
VALUES
    ('alex.rivera@email.com', 'Alex', 'Rivera'),
    ('sam.smith@email.com', 'Sam', 'Smith'),
    ('jordan.lee@email.com', 'Jordan', 'Lee'),
    ('casey.jones@email.com', 'Casey', 'Jones');

INSERT INTO [Loans] ([MemberEmail], [BookIsbn], [LoanDate], [ReturnDate])
VALUES
    ('alex.rivera@email.com', '978-0451524935', '2024-01-10 10:00:00', '2024-01-24 14:30:00'),
    ('alex.rivera@email.com', '978-0141439518', '2024-02-15 09:15:00', NULL),
    ('jordan.lee@email.com', '978-0743273565', '2024-02-20 16:45:00', NULL),
    ('casey.jones@email.com', '978-0316769174', '2024-02-28 11:00:00', NULL),
    ('casey.jones@email.com', '978-0061120084', '2024-02-28 11:05:00', NULL);