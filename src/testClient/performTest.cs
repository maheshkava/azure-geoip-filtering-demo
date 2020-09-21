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
    internal static async Task<ActionResult> PerformTest(string uri,
            ILogger log)
    {
      log.LogInformation($"Requesting: {uri}");

      using (var client = new HttpClient())
      {
        try
        {
          var response = await client.GetAsync(uri);
          var content = await response.Content.ReadAsStringAsync();

          log.LogInformation($"Response ({response.StatusCode}): {content}");

          if (response.StatusCode.Equals(System.Net.HttpStatusCode.OK))
          {
            return new OkObjectResult("Looks Good!");
          }
          else
          {
            return new StatusCodeResult((int)response.StatusCode);
          }
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