using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.DataProtection.AzureStorage.Ext
{
    public class DataProtectionConfig
    {
        /// <summary>
        /// Set this to true to use azure blob storage to store data persistence keys.
        /// Otherwise the file system will be used. Default: false
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The name of the container for storing data persistence keys. Default: 'data-persistence-keys'
        /// </summary>
        public String Container { get; set; } = "data-persistence-keys";

        /// <summary>
        /// The path for storing data persistence keys. Default: 'keys.xml'
        /// </summary>
        public String Path { get; set; } = "keys.xml";
    }
}
