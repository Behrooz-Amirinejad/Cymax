namespace Cymax.Web.DataAccess
{
    public interface IRepository <TEntity>  where TEntity : class
    {
        Task<TEntity> GetSingle(TEntity model);

        Task<List<TEntity>> Gets();
    }
}
