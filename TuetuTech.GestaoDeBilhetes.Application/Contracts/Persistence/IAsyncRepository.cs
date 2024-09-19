using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entidade);
        Task UpdateAsync(T entidade);
        Task DeleteAsync(T entidade);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
