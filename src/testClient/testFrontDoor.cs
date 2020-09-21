using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace testClient
{
  public class testFrontDoor
  {
    private readonly IConfiguration config;
    public testFrontDoor(IConfiguration config)
    {
      this.config = config;
    }

    [FunctionName("testFrontDoor")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
      string uri = config.GetValue<string>("FrontDoorUri");
      return await Utils.PerformTest(uri, log);
    }
  }
}
