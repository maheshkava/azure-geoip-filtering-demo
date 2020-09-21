using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web.Http;
using System.Net.Http;

namespace testClient
{
  internal static class Utils
  {
    internal static async Task<ObjectResult> PerformTest(string uri,
            ILogger log)
    {
      log.LogInformation($"Requesting: {uri}");

      using (var client = new HttpClient())
      {
        try
        {
          var response = await client.GetAsync(uri);
          
          log.LogInformation($"Response: {response.Content}");

          return new OkObjectResult("Looks Good!");
        }
        catch (Exception e)
        {
          var response = new ExceptionResult(e, false);
          return response;
        }
      }
    }
  }
}