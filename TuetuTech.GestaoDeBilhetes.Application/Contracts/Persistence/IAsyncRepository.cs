using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T?> ObterPorIdAsync(Guid id);
        Task<IReadOnlyList<T>> ObterTodosAsync();
        Task<T> AdicionarAsync(T entidade);
        Task AlterarAsync(T entidade);
        Task EliminarAsync(T entidade);
        Task<IReadOnlyList<T>> ObterRespostaPaginadaAsync(int pagina, int tamanho);
    }
}
