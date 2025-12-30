namespace TicketManager.Infrastructure.Repositories.IRepositories;

public interface IRepository<T>
{
    T Add(T model);
    void AddRange(IEnumerable<T> models);
    T Update(T model);
    void UpdateRange(IEnumerable<T> models);
    void Delete(T model);
    void DeleteRange(IEnumerable<T> models);
}