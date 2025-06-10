using System.ComponentModel.DataAnnotations;

namespace APBD_Test_02.Entities;

public class Book
{
    [Key]
    public int BookId { get; set; }
    [MinLength(2), MaxLength(50)]
    public string Name { get; set; }
    [MinLength(2), MaxLength(50)]
    public DateTime RealseDate { get; set; }
    
    public int IdPublisher { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    
    public ICollection<BookGenre> BookGenres { get; set; }
}