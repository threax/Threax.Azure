using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Azure.Abstractions
{
    public class AzureAppInsightsConfig
    {
        /// <summary>
        /// Set this to true to enable app insights. This is processed by the dependency injection extension method, so it can always be called.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The instrumentation key to use for connecting to app insights. Default null.
        /// </summary>
        public String InstrumentationKey { get; set; }

        /// <summary>
        /// The Cloud Role Name for this app instance. Default null
        /// </summary>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-map?tabs=net#set-cloud-role-name
        /// </remarks>
        public string RoleName { get; set; }

        /// <summary>
        /// The Cloud Role Instance Name for this app instance. Default: null
        /// </summary>
        /// <remarks>
        /// See https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-map?tabs=net#set-cloud-role-name
        /// </remarks>
        public string RoleInstance { get; set; }
  
        /// <summary>
        /// Gets or sets a value indicating whether telemetry channel should be set to developer mode. Default: null
        /// </summary>
        public bool? DeveloperMode { get; set; }

        /// <summary>
        /// Gets or sets the application version reported with telemetries. Default: null
        /// </summary>
        public string ApplicationVersion { get; set; }
    }
}
