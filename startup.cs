using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(testClient.Startup))]

namespace testClient
{
  public class Startup : FunctionsStartup
  {
    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
      FunctionsHostBuilderContext context = builder.GetContext();

      builder.ConfigurationBuilder
          .AddJsonFile(Path.Combine(context.ApplicationRootPath, "local.settings.json"), optional: true, reloadOnChange: false)
          .AddEnvironmentVariables();
    }
  }
}