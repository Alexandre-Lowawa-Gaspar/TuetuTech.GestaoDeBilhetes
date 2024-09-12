using System.Security.Claims;
using TuetuTech.GestaoDeBilhetes.Application.Contracts;

namespace TuetuTech.GestaoDeBilhetes.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string UtilizadorId
        {
            get
            {
                return _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
    }
}
