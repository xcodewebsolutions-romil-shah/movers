using MoverAndStore.WebApp.Models;

namespace MoverAndStore.WebApp.Repositories
{
    public interface IUserRepository<TEntity> : IGenericRepository<TEntity>
  where TEntity : User
    {

    }

    public class CustomerRepository : GenericRepository<User>, IUserRepository<User>
    {
        //private readonly FastrDbContext _dbContext;

        //public CustomerRepository(FastrDbContext dbContext)
        //    : base(dbContext)
        //{
        //    _dbContext = dbContext;
        //}
    }
    public class UserRepository
    {
    }
}
