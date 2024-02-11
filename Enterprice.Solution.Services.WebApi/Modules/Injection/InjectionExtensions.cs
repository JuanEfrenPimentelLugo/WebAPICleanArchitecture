using Enterprice.Solution.Services.WebApi.Modules.GlobalException;
using Enterprice.Solution.Transversal.Common;
using Enterprice.Solution.Transversal.Logging;

namespace Enterprice.Solution.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);            
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddTransient<GlobalExceptionHandler>();

            return services;
        }
    }
}
