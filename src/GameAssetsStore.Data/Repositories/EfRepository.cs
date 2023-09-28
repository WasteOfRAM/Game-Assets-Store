namespace GameAssetsStore.Data.Repositories;

using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public EfRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.DbSet = this.dbContext.Set<TEntity>();
    }

    private readonly ApplicationDbContext dbContext;
    protected DbSet<TEntity> DbSet { get; set; }

    public async Task<TEntity?> GetById(Guid id) => await this.DbSet.FindAsync(id);

    public IQueryable<TEntity> GetAll() => this.DbSet;

    public async Task AddAsync(TEntity entity) => await this.DbSet.AddAsync(entity);

    public void Update(TEntity entity)
    {
        var entry = this.dbContext.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            this.DbSet.Attach(entity);
        }
        
        entry.State = EntityState.Modified;
    }

    public void Delete(TEntity entity) => this.DbSet.Remove(entity);

    public async Task<int> SaveAsync() => await this.dbContext.SaveChangesAsync();
}
