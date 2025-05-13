namespace APBD_TEST_01.Entities;

public class Task
{
    public int IdTask { get; set; }
    
    public string TaskName { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Deadline { get; set; }
    
    public int IdProject { get; set; }
    
    public int IdTaskType { get; set; }
    
    public int IdAssighedTp { get; set; }
    
    public int IdCreatot { get; set; }
}