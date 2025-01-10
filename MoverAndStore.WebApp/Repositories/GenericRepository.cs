namespace MoverAndStore.WebApp.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        //IQueryable<TEntity> GetAll();
        //IQueryable<TEntity> Query();
        //TEntity Get(Predicate<TEntity> predicate);
        //IEnumerable<TEntity> GetList(Predicate<TEntity> predicate);
        //Task<TEntity> CreateAsync(TEntity entity);
        //Task CreateRangeAsync(List<TEntity> entity);
        //void Update(TEntity entity);
        //void Delete(TEntity entity);
        //void DeleteRange(List<TEntity> entity);
    }


    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        //private readonly MSCOneDbContext _dbContext;

        //public GenericRepository(MSCOneDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //    public IQueryable<TEntity> GetAll()
        //    {
        //        return _dbContext.Set<TEntity>().AsNoTracking();
        //    }

        //    public IQueryable<TEntity> Query()
        //    {
        //        return _dbContext.Set<TEntity>().AsQueryable();
        //    }

        //    public virtual TEntity Get(Predicate<TEntity> predicate)
        //    {
        //        return _dbContext.Set<TEntity>().FirstOrDefault(e => predicate(e));
        //    }

        //    public virtual IEnumerable<TEntity> GetList(Predicate<TEntity> predicate)
        //    {
        //        return _dbContext.Set<TEntity>().AsQueryable();
        //    }

        //    public virtual async Task<TEntity> CreateAsync(TEntity entity)
        //    {
        //        try
        //        {
        //            await _dbContext.Set<TEntity>().AddAsync(entity);
        //            return entity;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }

        //    public virtual async Task CreateRangeAsync(List<TEntity> entity)
        //    {
        //        try
        //        {
        //            await _dbContext.Set<TEntity>().AddRangeAsync(entity);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw;
        //        }
        //    }

        //    public virtual void Update(TEntity entity)
        //    {
        //        _dbContext.Set<TEntity>().Update(entity);
        //    }

        //    public virtual void Delete(TEntity entity)
        //    {
        //        _dbContext.Set<TEntity>().Remove(entity);
        //    }

        //    public virtual void DeleteRange(List<TEntity> entity)
        //    {
        //        _dbContext.Set<TEntity>().RemoveRange(entity);
        //    }
        //}
    }
}
