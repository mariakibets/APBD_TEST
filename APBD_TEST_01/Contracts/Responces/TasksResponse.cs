using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_01.Contracts.Responces;

public class TasksResponse
{
    [Required] public string TaskName { get; set; }
    
    [Required] public string Description { get; set; }
    
    [Required] public DateTime Deadline { get; set; }
}