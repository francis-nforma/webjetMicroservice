using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace userService.Database.Repository
{
    public interface IDataRepository<TEntity>
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Add(TEntity entity);
        Task Delete(int id);
        Task Update(TEntity entity);
    }
}
