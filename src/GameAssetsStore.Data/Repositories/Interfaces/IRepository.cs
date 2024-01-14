namespace GameAssetsStore.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll();

    Task<IEnumerable<TEntity>> GetAllAsNoTracking();

    Task<TEntity?> GetById(Guid id);

    Task Add(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<int> Save();
}
