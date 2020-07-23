using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Azure.Abstractions
{
    public class AzureStorageConfig
    {
        /// <summary>
        /// The name of the section that should be used by convention for the storage account config. Value: 'Storage'
        /// </summary>
        public const String SectionName = "Storage";

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
