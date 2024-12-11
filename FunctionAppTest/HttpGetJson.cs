using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionAppTest
{
    public class HttpGetJson
    {
        private readonly ILogger<HttpGetJson> _logger;

        public HttpGetJson(ILogger<HttpGetJson> logger)
        {
            _logger = logger;
        }

        [Function("HttpGetJson")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "get-json")] HttpRequestData req)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            _logger.LogInformation($"---> C# HTTP trigger function processed a request at {now}.");

            var configAuthor = Environment.GetEnvironmentVariable("ConfigAuthor");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(new
            {
                message = $"Welcome to Azure Functions! Now it's {now}.",
                author = configAuthor,
                date = DateTime.Now,
                formatedDate = now,
                statusCode = HttpStatusCode.OK
            });

            return response;
        }
    }
}
