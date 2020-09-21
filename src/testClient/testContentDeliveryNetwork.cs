using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace testClient
{
  public class testContentDeliveryNetwork
  {
    private readonly IConfiguration config;
    public testContentDeliveryNetwork(IConfiguration config)
    {
      this.config = config;
    }

    [FunctionName("testContentDeliveryNetwork")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
      string uri = config.GetValue<string>("ContentDeliveryNetworkUri");
      return await Utils.PerformTest(uri, log);
    }
  }
}
