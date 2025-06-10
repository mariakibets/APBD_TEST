using APBD_Test_02.DTO.Requests;
using APBD_Test_02.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace APBD_Test_02.Controllers;


[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("/all")]
    public async Task<IActionResult> GetBooks(DateTime? realiseDate)
    {
        var result = await _bookService.GetAllActorsAsync(realiseDate);

        try
        {
            if (result.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost("/add/movie")]
    public async Task<IActionResult> addBook(BookRequest book)
    {
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        try
        {
            var result = await _bookService.AddBookAsync(book);
            return Ok(result);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = "An unexpected error occurred." });
        }
    }

}