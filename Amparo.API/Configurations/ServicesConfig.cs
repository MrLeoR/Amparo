using Amparo.Aplicacao.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Amparo.API.Configurations
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var type = typeof(IService);

            var typesAssigned = Assembly
                .Load("Amparo.Aplicacao")
                .GetTypes()
                .Where(t => t != type && type.IsAssignableFrom(t));

            foreach (var t in typesAssigned)
                services.AddScoped(t);

            return services;
        }
    }
}
