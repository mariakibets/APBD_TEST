using APBD_Test_02.DTO.Requests;
using APBD_Test_02.DTO.Responses;

namespace APBD_Test_02.Services.Intefaces;

public interface IBookService
{
    Task<List<BookDTO>> GetAllBooksAsync(DateTime? realiseDate);
    
    Task<bool> AddBookAsync(BookRequest book);
}