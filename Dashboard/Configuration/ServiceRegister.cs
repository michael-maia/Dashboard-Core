using Dashboard.Services;
using Dashboard.Services.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
