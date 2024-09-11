using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Commands.AdicionarCategoria;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriaDetail;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasList;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categorias.Queries.ObterCategoriasListComEventos;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AdicionarEvento;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.AlterarEvento;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Commands.EliminarEvento;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventoDetail;
using TuetuTech.GestaoDeBilhetes.Application.Features.Eventos.Queries.ObterEventosList;
using TuetuTech.GestaoDeBilhetes.Application.Features.Pedidos.Queries.ObterPedidosPorMeses;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Evento, EventoListVm>().ReverseMap();
            CreateMap<Evento, EventoDetailVm>().ReverseMap();
            CreateMap<Evento, AdicionarEventoCommand>().ReverseMap();
            CreateMap<Evento, AlterarEventoCommand>().ReverseMap();
            CreateMap<Evento, EliminarEventoCommand>().ReverseMap();
            // CreateMap<Evento, EventoExportDto>().ReverseMap();

            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaEventoDto>().ReverseMap();
            CreateMap<Categoria, CategoriaListVm>().ReverseMap();
            CreateMap<Categoria, CategoriaDetailVm>().ReverseMap();
            CreateMap<Categoria, AdicionarCategoriaCommand>().ReverseMap();

            CreateMap<Pedido, PedidosPorMesDto>().ReverseMap();
            

        }
    }
}
