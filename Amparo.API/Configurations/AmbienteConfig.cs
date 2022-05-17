using Amparo.Aplicacao.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amparo.API.Configurations
{
    public static class AmbienteConfig
    {
        public static IServiceCollection ConfigureAmbiente(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider =>
            {
                var ambiente = new Ambiente();
                configuration.Bind(ambiente);

                return ambiente;
            });

            return services;
        }
    }
}
