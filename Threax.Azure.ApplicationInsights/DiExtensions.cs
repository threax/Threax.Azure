using Microsoft.Extensions.DependencyInjection;
using System;
using Threax.Azure.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        public static IServiceCollection AddThreaxAzureStorageDataProtection(this IServiceCollection services, Action<AzureAppInsightsConfig> configure)
        {
            

            return services;
        }
    }
}
