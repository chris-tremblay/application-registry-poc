using System.Runtime.CompilerServices;

// Give our unit tests visibility to internal classes because we have to test them
[assembly: InternalsVisibleTo("MyNexus.ApplicationRegistry.IntegrationTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")] // Used for mocking