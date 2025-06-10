using APBD_Test_02.DAL;
using APBD_Test_02.DTO.Requests;
using APBD_Test_02.DTO.Responses;
using APBD_Test_02.Entities;
using APBD_Test_02.Services.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace APBD_Test_02.Services;

public class BookService : IBookService
{
    private readonly BookContext _context;

    public BookService(BookContext context)
    {
        _context = context;
    }

    public async Task<List<BookDTO>> GetAllBooksAsync(DateTime? realiseDate)
    {
        var query = _context.Books.AsQueryable();

        if (realiseDate.HasValue)
        {
            query = query.Where(book => book.RealseDate == realiseDate);
        }

        var booksDTO = await query
            .OrderByDescending(book => book.RealseDate)
            .Select(b => new BookDTO
            {
                Id = b.BookId,
                Title = b.Name,
                Publisher = new PublisherDTO
                {
                    Id = b.IdPublisher,
                    Name = b.PublishingHouse.Name,
                    Country = b.PublishingHouse.Country,
                    City = b.PublishingHouse.City,
                },
                ReleaseDate = b.RealseDate,
                Authors = b.BookAuthors
                    .Select(ba => new AuthorDTO
                    {
                        Id = ba.Author.IdAuthor,
                        FirstName = ba.Author.FirstName,
                        LastName = ba.Author.LastName,
                    }).ToList(),
                Genres = b.BookGenres
                    .Select(bg => new GenreDTO
                    {
                        Id = bg.Genre.IdGenre,
                        Title = bg.Genre.Name
                    }).ToList()
            }).ToListAsync();
        return booksDTO;
    }

    public async Task<bool> AddBookAsync(BookRequest requestBook)
    {
        var query = _context.PublishingHouses.AsQueryable();
        var publisherId = requestBook.Publisher.IdPublisher;
        
        
        var book = new Book
        {
            BookId = requestBook.BookId,
            Name = requestBook.BookName,
            RealseDate = requestBook.RealseDate,
            PublishingHouse = requestBook.Publisher,
            BookAuthors = requestBook.Author.Select(ba => new BookAuthor
            {
                IdAuthor = ba.IdAuthor,
            }).ToList(),
            BookGenres = requestBook.Genre.Select(bg => new BookGenre
            {
                IdGenre = bg.Id
            }).ToList()
        };
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return true;
    }

}