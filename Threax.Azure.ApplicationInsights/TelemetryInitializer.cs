using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace Threax.Azure.ApplicationInsights
{
    //Pretty much just from the ms docs
    //https://docs.microsoft.com/en-us/azure/azure-monitor/app/app-map?tabs=net#set-cloud-role-name
    public class TelemetryInitializer : ITelemetryInitializer
    {
        private readonly string roleName;
        private readonly string roleInstance;

        public TelemetryInitializer(String roleName, String roleInstance)
        {
            this.roleName = roleName;
            this.roleInstance = roleInstance;
        }

        public void Initialize(ITelemetry telemetry)
        {
            if (string.IsNullOrEmpty(telemetry.Context.Cloud.RoleName))
            {
                //set custom role name here
                telemetry.Context.Cloud.RoleName = roleName;
                telemetry.Context.Cloud.RoleInstance = roleInstance;
            }
        }
    }
}
