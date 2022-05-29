using Airport.DistanceMeasure.Application.Interfaces;
using Airport.DistanceMeasure.Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.DistanceMeasure.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAirportDistanceMeasureService, AirportDistanceMeasureService>();
            services.AddScoped<IGetAirportsService, GenericRequestAsyncService>();
        }
    }
}
