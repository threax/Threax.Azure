using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using Threax.Configuration.AzureKeyVault;
using Threax.Extensions.Configuration.SchemaBinder;

namespace Threax.Extensions.Configuration.SchemaBinder
{
    public static class SchemaBinderExtensions
    {
        public static void AddThreaxKeyVaultConfigDefinition(this SchemaConfigurationBinder config, String keyVaultSection = "KeyVault")
        {
            config.Define(keyVaultSection, typeof(ThreaxAzureKeyVaultConfig));
        }
    }
}
