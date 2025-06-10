namespace APBD_Test_02.Entities;

public class BookGenre
{
    public int IdGenre { get; set; }
    public Genre Genre { get; set; }
    public int IdBook { get; set; }
    public Book Book { get; set; }
}