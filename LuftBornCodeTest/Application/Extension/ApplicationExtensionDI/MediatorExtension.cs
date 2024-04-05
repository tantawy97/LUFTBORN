using Application.Extension.ApplicationExtensionDI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extension.ApplicationExtensionDI
{
    public static class MediatorExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependanciesExtension).Assembly));

            return services;
        }
    }
}
