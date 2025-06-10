using System.ComponentModel.DataAnnotations;

namespace APBD_Test_02.Entities;

public class PublishingHouse
{
    [Key]
    public int IdPublisher { get; set; }

    [MinLength(2), MaxLength(50)]
    public string Name { get; set; }
    
    [MinLength(2), MaxLength(50)]
    public string Country { get; set; }
    
    [MinLength(2), MaxLength(50)]
    public string City { get; set; }
    
    public ICollection<Book> Books { get; set; }
}