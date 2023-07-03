namespace GameAssetsStore.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();

    IQueryable<TEntity> GetAllAsNoTracking();

    Task AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    void Delete(TEntity entity);

    Task<int> SaveChangesAsync();
}
