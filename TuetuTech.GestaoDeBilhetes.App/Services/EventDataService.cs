﻿using AutoMapper;
using Blazored.LocalStorage;
using TuetuTech.GestaoDeBilhetes.App.Contracts;
using TuetuTech.GestaoDeBilhetes.App.Services.Base;
using TuetuTech.GestaoDeBilhetes.App.ViewModels;

namespace TuetuTech.GestaoDeBilhetes.App.Services
{
    public class EventDataService: BaseDataService, IEventDataService
    {
        
        private readonly IMapper _mapper;

        public EventDataService(IClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<EventListViewModel>> GetAllEvents()
        {
            var allEvents = await _client.GetAllEventsAsync();
            var mappedEvents = _mapper.Map<ICollection<EventListViewModel>>(allEvents);
            return mappedEvents.ToList();
        }

        public async Task<EventDetailViewModel> GetEventById(Guid id)
        {
            var selectedEvent = await _client.GetEventByIdAsync(id);
            var mappedEvent = _mapper.Map<EventDetailViewModel>(selectedEvent);
            return mappedEvent;
        }

        public async Task<ApiResponse<Guid>> CreateEvent(EventDetailViewModel eventDetailViewModel)
        {
            try
            {
                CreateEventCommand createEventCommand = _mapper.Map<CreateEventCommand>(eventDetailViewModel);
                var newId = await _client.AddEventAsync(createEventCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateEvent(EventDetailViewModel eventDetailViewModel)
        {
            try
            {
                UpdateEventCommand updateEventCommand = _mapper.Map<UpdateEventCommand>(eventDetailViewModel);
                await _client.UpdateEventAsync(updateEventCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteEvent(Guid id)
        {
            try
            {
                await _client.DeleteEventAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
