namespace GameAssetsStore.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> GetAll();

    Task<TEntity?> GetById(Guid id);

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<int> SaveAsync();
}
