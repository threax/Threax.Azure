using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.DependencyInjection;
using System;
using Threax.Azure.Abstractions;
using Threax.Azure.ApplicationInsights;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add application insights using the config from the Threax.Azure.Abstractions library.
        /// Optionally you can also include a callback that is called when app insights is configured, which exposes more options.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure"></param>
        /// <param name="configureAppInsights"></param>
        /// <returns></returns>
        public static IServiceCollection AddThreaxAppInsights(this IServiceCollection services, Action<AzureAppInsightsConfig> configure, Action<ApplicationInsightsServiceOptions> configureAppInsights = null)
        {
            var options = new AzureAppInsightsConfig();
            configure.Invoke(options);

            if (options.Enabled)
            {
                services.AddSingleton<ITelemetryInitializer>(s => new TelemetryInitializer(options.RoleName, options.RoleInstance));
                services.AddApplicationInsightsTelemetry(o =>
                {
                    o.InstrumentationKey = options.InstrumentationKey;
                    o.DeveloperMode = options.DeveloperMode;
                    o.ApplicationVersion = options.ApplicationVersion;
                    configureAppInsights?.Invoke(o);
                });
            }

            return services;
        }
    }
}
