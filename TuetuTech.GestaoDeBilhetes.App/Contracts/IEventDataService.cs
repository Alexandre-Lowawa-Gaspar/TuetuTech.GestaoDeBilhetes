using TuetuTech.GestaoDeBilhetes.App.Services.Base;
using TuetuTech.GestaoDeBilhetes.App.ViewModels;

namespace TuetuTech.GestaoDeBilhetes.App.Contracts
{
    public interface IEventDataService
    {
        Task<List<EventListViewModel>> GetAllEvents();
        Task<EventDetailViewModel> GetEventById(Guid id);
        Task<ApiResponse<Guid>> CreateEvent(EventDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> UpdateEvent(EventDetailViewModel eventDetailViewModel);
        Task<ApiResponse<Guid>> DeleteEvent(Guid id);
    }
}
