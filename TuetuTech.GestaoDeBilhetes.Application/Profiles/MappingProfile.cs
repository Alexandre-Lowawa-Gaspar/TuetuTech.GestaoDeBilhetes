using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Commands.CreatedCategory;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Queries.GetCategoriesList;
using TuetuTech.GestaoDeBilhetes.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.CreateEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.DeleteEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Commands.UpdateEvent;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventDetail;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsExport;
using TuetuTech.GestaoDeBilhetes.Application.Features.Events.Queries.GetEventsList;
using TuetuTech.GestaoDeBilhetes.Application.Features.Orders.Queries.ObterOrdersPorMes;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();


        }
    }
}
