using System;
using Threax.Azure.Abstractions;

namespace Threax.Extensions.Configuration.SchemaBinder
{
    public static class SchemaBinderExtensions
    {
        public static void AddThreaxKeyVaultConfigDefinition(this SchemaConfigurationBinder config, String keyVaultSection = "KeyVault")
        {
            config.Define(keyVaultSection, typeof(AzureKeyVaultConfig));
        }
    }
}
