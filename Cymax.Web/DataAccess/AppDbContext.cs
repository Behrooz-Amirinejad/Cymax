using Microsoft.EntityFrameworkCore;

namespace Cymax.Web.DataAccess
{
    public class AppDbContext : DbContext 
    {
        private readonly ILogger<AppDbContext> _logger;
        private Type _type;

        public AppDbContext(DbContextOptions option , ILogger<AppDbContext> logger)
            : base(option)
        {
            this._logger = logger;
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            this._logger.LogInformation("Set  started");
            this._type = typeof(TEntity);
            _type.GetCustomAttributes(typeof(TEntity), true).OfType<TEntity>().FirstOrDefault();
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this._logger.LogInformation("Model binding creating started");
            base.OnModelCreating(modelBuilder);
        }
    }
}
