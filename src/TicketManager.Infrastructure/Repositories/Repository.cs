using TicketManager.Infrastructure.Contexts;
using TicketManager.Infrastructure.Repositories.IRepositories;

namespace TicketManager.Infrastructure.Repositories;

public class Repository<T>(
    TicketManagerDbContext context) : IRepository<T> where T : class
{
    private readonly TicketManagerDbContext _context = context;

    public T Add(T model)
    {
        var obj = this._context.Set<T>().Add(model);
        this._context.SaveChanges();
        return obj.Entity;
    }

    public void AddRange(IEnumerable<T> models)
    {
        this._context.Set<T>().AddRange(models);
        this._context.SaveChanges();
    }

    public T Update(T model)
    {
        var obj = this._context.Set<T>().Update(model);
        this._context.SaveChanges();
        return obj.Entity;
    }

    public void UpdateRange(IEnumerable<T> models)
    {
        this._context.Set<T>().UpdateRange(models);
        this._context.SaveChanges();
    }

    public void Delete(T model)
    {
        this._context.Set<T>().Remove(model);
        this._context.SaveChanges();
    }

    public void DeleteRange(IEnumerable<T> models)
    {
        this._context.Set<T>().RemoveRange(models);
        this._context.SaveChanges();
    }
}