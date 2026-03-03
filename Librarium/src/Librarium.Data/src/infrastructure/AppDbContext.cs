using Librarium.Data.infrastructure.repositories.dto;
using Microsoft.EntityFrameworkCore;
using BookDto = Librarium.Data.infrastructure.repositories.dto.BookDto;
using MemberDto = Librarium.Data.infrastructure.repositories.dto.MemberDto;

namespace Librarium.Data.infrastructure;

/// <summary>
/// Application DbContext for Librarium.
/// Defines the database models and entity configurations.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Books DbSet
    /// </summary>
    public DbSet<BookDto> Books { get; set; }

    /// <summary>
    /// Members DbSet
    /// </summary>
    public DbSet<MemberDto> Members { get; set; }

    /// <summary>
    /// Loans DbSet
    /// </summary>
    public DbSet<LoanDto> Loans { get; set; }
    /// <summary>
    /// Authors DbSet
    /// </summary>
    public DbSet<AuthorDto> Authors { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<BookDto>(entity =>
        {
            entity.HasKey(e => e.Isbn);
            entity.Property(e => e.Isbn).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(500).IsRequired();
            entity.Property(e => e.PublicationYear).IsRequired();
            entity.ToTable("Books");
        });
    
        modelBuilder.Entity<MemberDto>(entity =>
        {
            entity.HasKey(e => e.Email);
            entity.Property(e => e.Email).HasMaxLength(255).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.MemberId).IsRequired();
            entity.Property(e => e.PhoneNumber).HasMaxLength(20).IsRequired();
           
            entity.ToTable("Members");
        });
    
        modelBuilder.Entity<LoanDto>(entity =>
        {
            // Composite primary key: MemberEmail + BookIsbn
            entity.HasKey(e => new { e.MemberEmail, e.BookIsbn });
    
            // FK to Members table (Email is PK of MemberDto)
            entity.HasOne(e => e.Member)
                .WithMany()
                .HasForeignKey(e => e.MemberEmail)
                .HasPrincipalKey(m => m.Email)
                .OnDelete(DeleteBehavior.Restrict);
    
            // FK to Books table (Isbn is PK of BookDto)
            entity.HasOne(e => e.Book)
                .WithMany()
                .HasForeignKey(e => e.BookIsbn)
                .HasPrincipalKey(b => b.Isbn)
                .OnDelete(DeleteBehavior.Restrict);
    
            entity.Property(e => e.LoanDate).IsRequired();
            entity.Property(e => e.ReturnDate).IsRequired(false);
    
            entity.ToTable("Loans");
        });

        modelBuilder.Entity<AuthorDto>(entity =>
        {
            entity.HasKey(e => e.AuthorId);
            entity.Property(e => e.AuthorId).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Biography).HasMaxLength(2000).IsRequired(false);
            entity.ToTable("Authors");
        });

        // Many-to-many: Book ↔ Author via explicit join table "BookAuthors"
        modelBuilder.Entity<BookDto>()
            .HasMany(b => b.Authors)
            .WithMany(a => a.BooksDto)
            .UsingEntity(j => j.ToTable("BookAuthors"));
    }
}
