using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Azure.Abstractions
{
    /// <summary>
    /// Configuration for an app's storage account.
    /// </summary>
    public class AzureStorageConfig
    {
        /// <summary>
        /// The access key for the storage account.
        /// </summary>
        public String AccessKey { get; set; }

        /// <summary>
        /// The name of the storage account for this app.
        /// </summary>
        public String StorageAccount { get; set; }
    }
}
