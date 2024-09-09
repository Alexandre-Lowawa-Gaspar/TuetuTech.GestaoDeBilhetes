using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(TuetuTechDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Categoria>> ObterTodasComEventosAsync(bool incluiEventosPassados)
        {
            var todasCategorias = await _dbContext.Categorias.Include(x => x.Eventos).ToListAsync();
            if (!incluiEventosPassados)
            {
                todasCategorias.ForEach(p => p.Eventos!.ToList().RemoveAll(c => c.Data < DateTime.Today));
            }
            return todasCategorias;
        }
    }
}
