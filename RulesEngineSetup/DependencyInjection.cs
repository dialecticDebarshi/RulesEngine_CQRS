using RuleEngine.Application;
using RuleEngine.Infrastructure;
namespace RulesEngine.Plugins.Claims
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
            .AddInfrastructureDI();
            return services;

        }
    }
}
