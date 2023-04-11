using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.IRepositories
{
    public interface IRepositoryRep<TEntity> where TEntity : class
    {
        Task<TEntity> GetItemByIdAsync(int id);
        Task UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity iditem);
    }
}
