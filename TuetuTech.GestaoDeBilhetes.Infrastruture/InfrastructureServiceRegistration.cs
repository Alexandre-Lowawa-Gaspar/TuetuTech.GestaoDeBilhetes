using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Application.Contracts.Infrastruture;
using TuetuTech.GestaoDeBilhetes.Infrastruture.FileExport;

namespace TuetuTech.GestaoDeBilhetes.Infrastruture
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICsvExporter, CsvExporter>();
            return services;
        }
    }
}
