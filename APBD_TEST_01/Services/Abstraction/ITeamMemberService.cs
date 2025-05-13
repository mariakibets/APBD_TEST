using APBD_TEST_01.Contracts.Responces;

namespace APBD_TEST_01.Services.Abstraction;

public interface ITeamMemberService
{
    public Task<TeamMemberResponse> GetAllTasksAndMembers(int memberId, CancellationToken token);
}