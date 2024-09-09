﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Contracts.Persistence
{
    public interface ICategoriaRepository : IAsyncRepository<Categoria>
    {
        Task<List<Categoria>> ObterTodasComEventosAsync(bool incluiEventosPassados);
    }
}
