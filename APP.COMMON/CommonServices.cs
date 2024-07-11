using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommonServiceCollection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
