using TuetuTech.GestaoDeBilhetes.App.Services.Base;

namespace TuetuTech.GestaoDeBilhetes.App.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
