using TuetuTech.GestaoDeBilhetes.App.ViewModels;

namespace TuetuTech.GestaoDeBilhetes.App.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
