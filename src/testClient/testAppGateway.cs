using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace testClient
{
    public class testAppGateway
    {
        private readonly IConfiguration config;
        public testAppGateway(IConfiguration config)
        {
            this.config = config;
        }

        [FunctionName("testAppGateway")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string uri = config.GetValue<string>("AppGatewayUri");
            return await Utils.PerformTest(uri, log);
        }
    }
}
