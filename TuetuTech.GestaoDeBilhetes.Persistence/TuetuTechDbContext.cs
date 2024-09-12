using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts;
using TuetuTech.GestaoDeBilhetes.Domain.Common;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence
{
    public class TuetuTechDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;
        //public TuetuTechDbContext(DbContextOptions<TuetuTechDbContext> options) : base(options)
        //{

        //}
        public TuetuTechDbContext(DbContextOptions<TuetuTechDbContext> op, ILoggedInUserService loggedInUserService) : base(op)
        {
            _loggedInUserService = loggedInUserService;
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TuetuTechDbContext).Assembly);
            //seed data, added through migrations
            var concertoGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var showGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var conferenciaGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = concertoGuid,
                Nome = "Concertos"
            });
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = musicalGuid,
                Nome = "Musicais"
            });
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = showGuid,
                Nome = "Shows"
            });
            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                CategoriaId = conferenciaGuid,
                Nome = "Conferências"
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Nome = "John Egbert Live",
                Preco = 65,
                Artista = "John Egbert",
                Data = DateTime.Now.AddMonths(6),
                Descricao = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                CategoriaId = concertoGuid
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Nome = "The State of Affairs: Michael Live!",
                Preco = 85,
                Artista = "Michael Johnson",
                Data = DateTime.Now.AddMonths(9),
                Descricao = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                CategoriaId = concertoGuid
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Nome = "Clash of the DJs",
                Preco = 85,
                Artista = "DJ 'The Mike'",
                Data = DateTime.Now.AddMonths(4),
                Descricao = "DJs from all over the world will compete in this epic battle for eternal fame.",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                CategoriaId = concertoGuid
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Nome = "Spanish guitar hits with Manuel",
                Preco = 25,
                Artista = "Manuel Santinonisi",
                Data = DateTime.Now.AddMonths(4),
                Descricao = "Get on the hype of Spanish Guitar concerts with Manuel.",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                CategoriaId = concertoGuid
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Nome = "Techorama 2021",
                Preco = 400,
                Artista = "Many",
                Data = DateTime.Now.AddMonths(10),
                Descricao = "The best tech conference in the world",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                CategoriaId = conferenciaGuid
            });

            modelBuilder.Entity<Evento>().HasData(new Evento
            {
                EventoId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Nome = "To the Moon and Back",
                Preco = 135,
                Artista = "Nick Sailor",
                Data = DateTime.Now.AddMonths(8),
                Descricao = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                CategoriaId = musicalGuid
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                Total = 400,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                Total = 135,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                Total = 85,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                Total = 245,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
                Total = 142,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                Total = 40,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
            });

            modelBuilder.Entity<Pedido>().HasData(new Pedido
            {
                Id = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
                Total = 116,
                Pago = true,
                Data = DateTime.Now,
                UtilizadorId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<InformacaoGeral>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DataCriacao = DateTime.Now;
                        entry.Entity.CriadoPor = _loggedInUserService.UtilizadorId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.DataAlteracao = DateTime.Now;
                        entry.Entity.AlteradoPor = _loggedInUserService.UtilizadorId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

