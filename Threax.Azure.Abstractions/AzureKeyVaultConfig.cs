using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Threax.Azure.Abstractions
{
    public class AzureKeyVaultConfig
    {
        /// <summary>
        /// Set this to true to enable looking up secrets from key vault.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Set to the name of the key vault.
        /// </summary>
        public String VaultName { get; set; }

        /// <summary>
        /// Set to a prefix you want to use to filter secrets. They must be in the format prefix--key.
        /// </summary>
        public String Prefix { get; set; }
    }
}
