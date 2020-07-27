using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.Azure.Abstractions
{
    public class AzureAppInsightsConfig
    {
        /// <summary>
        /// Set this to true to enable app insights.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The instrumentation key to use for connecting to app insights. Default null.
        /// </summary>
        public String InstrumentationKey { get; set; }
    }
}
