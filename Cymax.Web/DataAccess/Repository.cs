using Cymax.Web.Feeder;
using Cymax.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Cymax.Web.DataAccess;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _appDb;

    public Repository(AppDbContext appDb )
    {
        this._appDb = appDb;
        _appDb.Set<TEntity>();
    }
    

    public async Task<TEntity> GetSingle(TEntity model)
    {
        var item = ParcelFeeder.GetParcelList().First();
        return (TEntity)Convert.ChangeType(item , typeof(TEntity));
    }

    public async Task<List<TEntity>> Gets()
    {
        var entities = ParcelFeeder.GetParcelList();
        return (List<TEntity>) Convert.ChangeType(entities, typeof(List<TEntity>));
    }

}

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }
}
