using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPortal.Core.Services
{
    public interface IService <TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task Add(TEntity pizza);
        Task Update(TEntity entity);
        Task Delete(long id);
    }
}