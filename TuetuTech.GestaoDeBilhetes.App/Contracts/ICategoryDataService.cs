using TuetuTech.GestaoDeBilhetes.App.Services;
using TuetuTech.GestaoDeBilhetes.App.Services.Base;
using TuetuTech.GestaoDeBilhetes.App.ViewModels;

namespace TuetuTech.GestaoDeBilhetes.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
