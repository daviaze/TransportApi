using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Application.Services;
using TransportApi.Application.Services.Interfaces;

namespace TransportApi.Application.DependecyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClassesMatchingInterfaces(this IServiceCollection services)
        {

            services.AddScoped<ITransportService, TransportService>();

            return services;
        }
    }
}
