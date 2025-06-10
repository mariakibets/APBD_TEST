namespace APBD_Test_02.DTO.Responses;

public class BookDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PublisherDTO Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public List<AuthorDTO> Authors { get; set; }
    public List<GenreDTO> Genres { get; set; }
}