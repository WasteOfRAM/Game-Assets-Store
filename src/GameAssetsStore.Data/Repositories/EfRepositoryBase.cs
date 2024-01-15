namespace GameAssetsStore.Data.Repositories;

using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class EfRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    public EfRepositoryBase(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.DbSet = this.dbContext.Set<TEntity>();
    }

    private readonly ApplicationDbContext dbContext;
    protected DbSet<TEntity> DbSet { get; set; }

    public virtual async Task<TEntity?> GetById(Guid id) => await this.DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<TEntity>> GetAll() => await this.DbSet.ToArrayAsync();

    public virtual async Task<ICollection<TEntity>> GetAllAsNoTracking() => await this.DbSet.AsNoTracking().ToArrayAsync();

    public virtual async Task Add(TEntity entity) => await this.DbSet.AddAsync(entity);

    public virtual void Update(TEntity entity)
    {
        var entry = this.dbContext.Entry(entity);
        if (entry.State == EntityState.Detached)
        {
            this.DbSet.Attach(entity);
        }
        
        entry.State = EntityState.Modified;
    }

    public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

    public async Task<int> Save() => await this.dbContext.SaveChangesAsync();
}
