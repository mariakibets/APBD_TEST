using APBD_Test_02.Entities;

namespace APBD_Test_02.DTO.Requests;

public class BookRequest
{
    // The endpoint should accept the
    //     publishing house ID, name, country, city, authors' IDs as well as genres’ IDs. If a publishing
    //     house does not exist, we should support adding it.
    
    public int BookId { get; set; }
    public string BookName { get; set; }
    public DateTime RealseDate { get; set; }
    public PublishingHouse Publisher { get; set; }
    public List<Author> Author { get; set; }
    public List<GenreRequest> Genre { get; set; }
}