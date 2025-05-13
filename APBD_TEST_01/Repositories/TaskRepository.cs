using APBD_TEST_01.Entities;
using Microsoft.Data.SqlClient;
using Task = APBD_TEST_01.Entities.Task;

namespace APBD_TEST_01.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly string _connectionString;
    
    public TaskRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }


    public async Task<bool> TaskExists(int id, CancellationToken token = default)
    {
        const string query = """
                             SELECT 
                                  IIF(EXISTS (SELECT 1 FROM Task 
                                      WHERE Task.IdAssignedTo  = @id OR Task.IdCreator = @Id), 1, 0);
                             """;

            await using SqlConnection con = new(_connectionString);
            await using SqlCommand command = new SqlCommand(query, con);
            await con.OpenAsync(token);
            command.Parameters.AddWithValue("@id", id);
            var result = Convert.ToInt32(await command.ExecuteScalarAsync(token));

            return result == 1;
    }

    public async Task<List<Entities.Task?>> GetAllTAsks(int memebrId, CancellationToken token = default)
    {
        const string query = """
                             SELECT IdTask,Name, Description, Description, Deadline, IdAssignedTo, IdCreator
                             FROM Task
                             WHERE (Task.IdAssignedTo  = @id AND Task.IdCreator = @id)
                             ORDER BY DESC ";"
                             """;
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@id", memebrId);
        using SqlDataReader reader = await command.ExecuteReaderAsync(token);
        List<Entities.Task?> tasks = new List<Entities.Task?>();
        
        Task? task = null;
        while (await reader.ReadAsync(token))
        {
            task = new Task()
            {
                IdTask = reader.GetInt32(0),
                TaskName = reader.GetString(1),
                Description = reader.GetString(2),
                Deadline = reader.GetDateTime(3),
                IdAssighedTp = reader.GetInt32(4),
                IdCreatot = reader.GetInt32(5),
            };
            tasks.Add(task);
        }
        
        return tasks;
    }
}