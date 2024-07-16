using APP.Admin.Repo.Implimentation;
using APP.Admin.Repo.Interface;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AdminServiceCollection
    {
        public static IServiceCollection AddAdminServices(this IServiceCollection services)
        {
            services.AddTransient<IMenuItems, MenuItemRepo>();
            return services;
        }

    }
}
