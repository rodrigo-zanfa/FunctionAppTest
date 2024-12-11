using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppTest
{
    public class HttpGet
    {
        private readonly ILogger<HttpGet> _logger;

        public HttpGet(ILogger<HttpGet> logger)
        {
            _logger = logger;
        }

        [Function("HttpGet")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            _logger.LogInformation($"---> C# HTTP trigger function processed a request at {now}.");

            return new OkObjectResult($"Welcome to Azure Functions! Now it's {now}.");
        }
    }
}
