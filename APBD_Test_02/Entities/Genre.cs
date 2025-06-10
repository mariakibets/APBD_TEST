using System.ComponentModel.DataAnnotations;

namespace APBD_Test_02.Entities;

public class Genre
{
    [Key]
    public int IdGenre { get; set; }
    
    [MinLength(2), MaxLength(50)]
    public string Name { get; set; }
    
    public ICollection<BookGenre> BookGenres { get; set; }
}