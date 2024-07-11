using Microsoft.Extensions.DependencyInjection;

using APP.Security;
using APP.Security.Repo.Implimantation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DashboardServiceCollection
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services)
        {
            services.AddTransient<ILoginUser, LoginUser>();
            return services;
        }

    }
}
