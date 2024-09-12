using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;
using TuetuTech.GestaoDeBilhetes.Persistence;

namespace TuetuTech.GestaoDeBilhetes.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InicializandoDbParaTestes(TuetuTechDbContext context)
        {

            var concertoGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var showGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenciaGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");


            context.Categorias.Add(new Categoria
            {
                CategoriaId = concertoGuid,
                Nome = "Concerts"
            });
            context.Categorias.Add(new Categoria
            {
                CategoriaId = musicalGuid,
                Nome = "Musicais"
            });
            context.Categorias.Add(new Categoria
            {
                CategoriaId = conferenciaGuid,
                Nome = "Conferencias"
            });
            context.Categorias.Add(new Categoria
            {
                CategoriaId = showGuid,
                Nome = "Shows"
            });
            context.SaveChanges();


        }
    }
}
