using APBD_TEST_01.Entities;

namespace APBD_TEST_01.Repositories;

public interface ITeamMemberRepository
{
    public Task<bool> MemberExists(int id, CancellationToken token = default);
    public Task<TeamMember?> getTeamMemberById(int id, CancellationToken token = default);
}