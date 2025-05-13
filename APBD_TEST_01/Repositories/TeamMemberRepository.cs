using APBD_TEST_01.Entities;
using Microsoft.Data.SqlClient;
using Task = APBD_TEST_01.Entities.Task;

namespace APBD_TEST_01.Repositories;

public class TeamMemberRepository : ITeamMemberRepository
{
    private readonly string _connectionString;
    
    public TeamMemberRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }

    public async Task<bool> MemberExists(int id, CancellationToken token = default)
    {
        const string query = """
                             SELECT 
                                  IIF(EXISTS (SELECT 1 FROM TeamMember 
                                      WHERE TeamMemebr.IdTeamMember  = @id), 1, 0);
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@id", id);
        var result = Convert.ToInt32(await command.ExecuteScalarAsync(token));

        return result == 1;
    }

    public async Task<TeamMember?> getTeamMemberById(int id, CancellationToken token = default)
    {
        const string query = """
                             SELECT IdTeamMember, FirstName, LastName, Email, k.IdAssighedTp, 
                             FROM TeamMember
                             Where IdTeamMember = @id;
                             JOIN Task k On TeamMemebr.IdTeamMember = k.IdAssignedTo
                             JOIN Task t On TeamMemebr.IdTaskType = t.IdCreator
                             """;

        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@id", id);
        var reader = await command.ExecuteReaderAsync(token);
        
        // List<Task> assignedTasks = new();

        TeamMember? teamMember = null;
        while (await reader.ReadAsync(token))
        {
            if (teamMember == null)
            {
                teamMember = new TeamMember
                {
                    IdTeamMember = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3)
                    // AssignedTasks = reader.GetInt32(4)
                };
            }
        }
        return teamMember;
    }
}