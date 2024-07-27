using System.Diagnostics.CodeAnalysis;
using B3.CalculoCdb.Domain.Interfaces;
using B3.CalculoCdb.Domain.Services;

namespace B3.CalculoCdb.Api.DI
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICalculoCdbService, CalculoCdbService>();
        }
    }
}