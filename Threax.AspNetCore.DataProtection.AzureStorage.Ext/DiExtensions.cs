using Microsoft.AspNetCore.DataProtection;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Blob;
using System;
using Threax.AspNetCore.DataProtection.AzureStorage.Ext;
using Threax.Azure.Abstractions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        /// <summary>
        /// Add the azure storage data protection extensions. This has 2 config methods, one to get the app's storage
        /// account and another to set the data persistence itself. This can be called even if you have it disabled
        /// since it will check that internally and act accoringly.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureStorage"></param>
        /// <param name="configureDataProtection"></param>
        /// <returns></returns>
        public static IServiceCollection AddThreaxAzureStorageDataProtection(this IServiceCollection services, Action<AzureStorageConfig> configureStorage, Action<DataProtectionConfig> configureDataProtection)
        {
            var storageConfig = new AzureStorageConfig();
            configureStorage.Invoke(storageConfig);

            var dataProtectConfig = new DataProtectionConfig();
            configureDataProtection.Invoke(dataProtectConfig);

            if (dataProtectConfig.Enabled)
            {
                var credentials = new StorageCredentials(storageConfig.StorageAccount, storageConfig.AccessKey);
                var storageAccount = new CloudStorageAccount(credentials, storageConfig.StorageAccount, "core.windows.net", useHttps: true);
                var client = storageAccount.CreateCloudBlobClient();
                var container = client.GetContainerReference(dataProtectConfig.Container);

                container.CreateIfNotExists();
                services.AddDataProtection().PersistKeysToAzureBlobStorage(container, dataProtectConfig.Path);
            }

            return services;
        }
    }
}
