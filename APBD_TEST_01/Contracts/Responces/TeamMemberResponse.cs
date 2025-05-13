using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_01.Contracts.Responces;

public class TeamMemberResponse
{
    [Required] public int IdTeamMember { get; set; }
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    public List<TasksResponse> AssignedTasks { get; set; }
    public List<TasksResponse> CreatedTasks { get; set; }
}