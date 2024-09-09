using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        public EventoRepository(TuetuTechDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsNomeEventoEDataUnico(string nome, DateTime dataEvento)
        {
            var resultado = _dbContext.Eventoos.Any(e => e.Nome == nome && e.Data == dataEvento);
            return Task.FromResult(resultado);
        }
    }
}
