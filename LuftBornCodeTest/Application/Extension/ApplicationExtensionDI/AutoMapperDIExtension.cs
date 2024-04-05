using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extension.ApplicationExtensionDI
{
    public static class AutoMapperDIExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(mc =>
            {
                mc.ShouldMapMethod = (m) => m.ContainsGenericParameters && m.GetGenericMethodDefinition().GetGenericArguments().Any(i => i.GetGenericParameterConstraints().Length == 0);
                mc.AddMaps(Assembly.GetExecutingAssembly());
            }).CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
