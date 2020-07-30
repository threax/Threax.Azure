using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.IO;
using Threax.Azure.Abstractions;
using Threax.Configuration.AzureKeyVault;

namespace Microsoft.Extensions.Configuration
{
    public static class IConfigurationBuilderExtensions
    {
        /// <summary>
        /// Add configuration from a key vault. A AzureKeyVaultConfig object will be loaded and processed from the file.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="keyVaultSection"></param>
        public static void AddThreaxKeyVaultConfig(this IConfigurationBuilder config, String keyVaultSection = "KeyVault")
        {
            var builtConfig = config.Build();
            var keyVaultConfig = new AzureKeyVaultConfig();
            builtConfig.GetSection(keyVaultSection).Bind(keyVaultConfig);

            if (keyVaultConfig.Enabled)
            {
                String connectionString = null;
                if (!String.IsNullOrEmpty(keyVaultConfig.ConnectionStringFile))
                {
                    connectionString = File.ReadAllText(keyVaultConfig.ConnectionStringFile);
                }

                var azureServiceTokenProvider = new AzureServiceTokenProvider(connectionString: connectionString);
                //This is disposable, but if you dispose it the config won't work. The MS docs show it this way so...
                var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

                IKeyVaultSecretManager manager;
                if (string.IsNullOrEmpty(keyVaultConfig.Prefix))
                {
                    manager = new DefaultKeyVaultSecretManager();
                }
                else
                {
                    manager = new PrefixKeyVaultSecretManager(keyVaultConfig.Prefix);
                }

                config.AddAzureKeyVault($"https://{keyVaultConfig.VaultName}.vault.azure.net/", keyVaultClient, manager);
            }
        }
    }
}
