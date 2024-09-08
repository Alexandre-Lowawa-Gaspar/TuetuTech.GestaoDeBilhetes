using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Evento, EventoListVm>().ReverseMap();
            CreateMap<Evento, EventoDetailVm>().ReverseMap();
            CreateMap<Categoria, CategoriaDto>().ReverseMap();

        }
    }
}
