﻿namespace GameAssetsStore.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Interfaces;
using Models.Interfaces;

public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class, ISoftDelete
{
    public EfRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.DbSet = this.dbContext.Set<TEntity>();
    }

    private readonly ApplicationDbContext dbContext;
    protected DbSet<TEntity> DbSet { get; set; }


    public IQueryable<TEntity> GetAll() => this.DbSet;

    public IQueryable<TEntity> GetAllAsNoTracking() => this.GetAllAsNoTracking().AsNoTracking();

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

    public void Delete(TEntity entity)
    {
        if (entity is ISoftDelete)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }
        else
        {
            this.DbSet.Remove(entity);
        }
    }

    public async Task<int> SaveChangesAsync() => await this.dbContext.SaveChangesAsync();
}