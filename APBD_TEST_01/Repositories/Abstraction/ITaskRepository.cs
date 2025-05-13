using APBD_TEST_01.Contracts.Responces;

namespace APBD_TEST_01.Repositories;

public interface ITaskRepository
{
    public Task<bool> TaskExists(int id, CancellationToken token = default);
    public Task<List<Entities.Task?>> GetAllTAsks(int memebrId, CancellationToken token = default);

}