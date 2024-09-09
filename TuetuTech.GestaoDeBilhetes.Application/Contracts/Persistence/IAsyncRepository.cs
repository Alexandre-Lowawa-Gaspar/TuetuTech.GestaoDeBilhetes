using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> ObterPorIdAsync(Guid id);
        Task<IReadOnlyList<T>> ObterTodosAsync();
        Task<T> AdicionarAsync(T entidade);
        Task<T> AlterarAsync(T entidade);
        Task<T> EliminarAsync(T entidade);
    }
}
