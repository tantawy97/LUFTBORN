using Microsoft.Extensions.DependencyInjection;

namespace Application.Extension.ApplicationExtensionDI
{
    public static class DependanciesExtension
    {
        public static IServiceCollection AddApplicationDependancies(this IServiceCollection services)
        {
            services.AddMediatR();
            services.AddAutoMapper();
            services.AddRepository();
            return services;
        }
    }
}