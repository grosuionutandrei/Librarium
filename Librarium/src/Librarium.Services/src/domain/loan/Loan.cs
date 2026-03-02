using Error_definitions;
using Librarium.Data.domain.book;
using Librarium.Data.domain.member;

namespace Librarium.Data.domain.loan;

/// <summary>
/// Represents a loan record - when a member borrows a book from the library.
/// Includes loan date and optional return date.
/// </summary>
public class Loan
{
    public Member Member { get; }
    public Book Book { get; }
    public DateTime LoanDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public Loan(Member member, Book book, DateTime loanDate)
    {
        if (member == null)
            throw new LoanInvalid("Member cannot be null.");
        if (book == null)
            throw new LoanInvalid("Book cannot be null.");
        if (loanDate > DateTime.Now)
            throw new LoanInvalid("Loan date cannot be in the future.");

        Member = member;
        Book = book;
        LoanDate = loanDate;
        ReturnDate = null;
    }

    /// <summary>
    /// Records the return of a borrowed book
    /// </summary>
    public void ReturnBook(DateTime returnDate)
    {
        if (returnDate < LoanDate)
            throw new LoanInvalid("Return date cannot be before loan date.");
        if (returnDate > DateTime.Now)
            throw new LoanInvalid("Return date cannot be in the future.");

        ReturnDate = returnDate;
    }

    /// <summary>
    /// Checks if the book is currently on loan (not returned yet)
    /// </summary>
    public bool IsActive => ReturnDate == null;

    public override string ToString() => 
        $"Loan: {Member.FirstName} {Member.LastName} borrowed '{Book.Title}' on {LoanDate:yyyy-MM-dd}" +
        (ReturnDate.HasValue ? $", returned on {ReturnDate:yyyy-MM-dd}" : "");
}