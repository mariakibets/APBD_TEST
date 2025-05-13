using APBD_TEST_01.Contracts.Responces;
using APBD_TEST_01.Entities;
using APBD_TEST_01.Repositories;
using APBD_TEST_01.Services.Abstraction;


namespace APBD_TEST_01.Services;

public class TeamMemberService : ITeamMemberService
{
    private readonly ITeamMemberRepository _teamMemberRepository;
    private readonly ITaskRepository _taskRepository;

    public TeamMemberService(ITeamMemberRepository teamMemberRepository, ITaskRepository taskRepository)
    {
        _teamMemberRepository = teamMemberRepository;
        _taskRepository = taskRepository;
    }

    public async Task<TeamMemberResponse?> GetAllTasksAndMembers(int memberId, CancellationToken token)
    {
        var existMember = await _teamMemberRepository.MemberExists(memberId, token);
        if (!existMember)
            return null;

        var member = await _teamMemberRepository.getTeamMemberById(memberId, token);
        if (member == null)
            return null;

        var tasks = await _taskRepository.GetAllTAsks(memberId, token);

        var response = new TeamMemberResponse
        {
            IdTeamMember = member.IdTeamMember,
            FirstName = member.FirstName,
            LastName = member.LastName,
            AssignedTasks = tasks
                .Where(t => t.IdAssighedTp == memberId)
                .Select(t => new TasksResponse
                {
                    TaskName = t.TaskName,
                    Description = t.Description,
                    Deadline = t.Deadline
                }).ToList(),
            CreatedTasks = tasks
                .Where(t => t.IdCreatot == memberId)
                .Select(t => new TasksResponse
                {
                    TaskName = t.TaskName,
                    Description = t.Description,
                    Deadline = t.Deadline
                }).ToList()
        };

        return response;
    }
}