using System.ComponentModel.DataAnnotations;

namespace APBD_Test_02.Entities;

public class Author
{
    [Key]
    public int IdAuthor { get; set; }
    
    [MinLength(2), MaxLength(50)]
    public string FirstName { get; set; }
    [MinLength(2), MaxLength(50)]
    public string LastName { get; set; }
    
    public ICollection<BookAuthor> BookAuthors { get; set; }
}