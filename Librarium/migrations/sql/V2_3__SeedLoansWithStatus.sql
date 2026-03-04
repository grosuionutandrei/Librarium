USE Librarium
GO

INSERT INTO [LoansWithStatus] ([MemberEmail], [BookIsbn], [LoanDate], [ReturnDate], [LoanStatus])
SELECT
    [MemberEmail],
    [BookIsbn],
    [LoanDate],
    [ReturnDate],
    CASE
        WHEN [ReturnDate] IS NULL THEN 'Active'
        ELSE 'Returned'
    END AS [LoanStatus]
FROM [Loans];
GO

