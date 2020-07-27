# Threax.Azure
These libraries provide some nicer integrations to Azure for the Threax framework or other applications based on Microsoft's docs.

The Threax.Azure.Abstractions library is also used as part of the Threax.Pipelines provisioning tool for creating the associated Azure resources.

## Threax.Azure.Abstractions
Basic config classes and other abstractions for using these libraries.

## Threax.AspNetCore.DataProtection
Enable data protection on blob storage. If you are using the Threax.Configuration.SchemaBinder you can initialize this like the following:
```
services.AddThreaxAzureStorageDataProtection(o => Configuration.Bind("Storage", o), o => Configuration.Bind("AzureDataProtection", o));
```

Also add a storage section to your appsettings

```
"Storage": {
  "StorageAccount": "smofreightidstor",
  "AccessKey": "comesfromsecret"
},
```

## Threax.Azure.ApplicationInsights
This library adds support for using application insights with your app.

## Threax.Configuration.AzureKeyVault
This makes it easy to use Azure Key Vault with .Net Core Configuration by implementing some classes used in the documentation. This enables the use of prefixes to only load some of the secrets in the key vault instead of all of them.

To integrate it add the following to `ConfigureAppConfiguration` in Program.cs in the order you want it loaded.

```
config.AddThreaxKeyVaultConfig();
```

This will pick up on a section called "KeyVault" by convention in whatever config has been loaded so far. Add this section to your appsettings file as appropriate.

```
"KeyVault": {
  "VaultName": "yourapp-kv",
  "Enabled": true,
  "Prefix": "yourapp-secret"
},
```

This would load any secrets prefixed with `yourapp-secret` like `yourapp-secret--AppConfig--ConnectionString`. Anything that does not start with the prefix is not loaded. Note that this does not prevent the app from seeing the non-prefixed secrets, but it does keep them out of the config.

This uses the default constructor of `AzureServiceTokenProvider`, which says: 

Creates an instance of the AzureServiceTokenProvider class. If no connection string is specified, Managed Service Identity, Visual Studio, Azure CLI, and Integrated Windows Authentication are tried to get a token. Even If no connection string is specified in code, one can be specified in the AzureServicesAuthConnectionString environment variable.

Any of those authentication methods can be used. If the app is running as an App Service give the App's Service Principal permission to the key vault and this will work with no further configuration.

## Config Schema Documentation
To get documentation in your config schema add any of these libraries to your csproj like this:
```
<PackageReference Include="Threax.Azure.Abstractions" Version="CURRENT_VERSION" GeneratePathProperty="true" />
```

Then add the following to the bottom of your csproj to ensure the docs are copied to the output folder.
```
<Copy SourceFiles="$(PkgThreax_Azure_Abstractions)\lib\netstandard2.0\Threax.Azure.Abstractions.xml" DestinationFolder="$(OutDir)" />
```