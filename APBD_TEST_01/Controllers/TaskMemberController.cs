using APBD_TEST_01.Services.Abstraction;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TEST_01.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskMemberController : ControllerBase
{
    private readonly ITeamMemberService _teamMemberService;

    public TaskMemberController(ITeamMemberService teamMemberService)
    {
        _teamMemberService = teamMemberService;
    }

    [HttpGet("/tasks/{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAppointmentDetails(int id, CancellationToken token=default)
    {
        var result = await _teamMemberService.GetAllTasksAndMembers(id,token);

      return Ok(result);
    }
}