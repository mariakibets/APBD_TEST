using APBD_Test_02.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_Test_02.DAL;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    public BookContext(DbContextOptions<BookContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.IdBook, ba.IdAuthor });
        
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.IdBook);
        
        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.IdAuthor);
        
        modelBuilder.Entity<BookGenre>()
            .HasKey(ba => new { ba.IdBook, ba.IdGenre });
            
        modelBuilder.Entity<BookGenre>()
            .HasOne(ba => ba.Genre)
            .WithMany(g => g.BookGenres)
            .HasForeignKey(ba => ba.IdGenre);
        
        modelBuilder.Entity<BookGenre>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookGenres)
            .HasForeignKey(ba => ba.IdBook);
        
        modelBuilder.Entity<Book>()
            .HasOne(b => b.PublishingHouse)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.IdPublisher);
    }
}