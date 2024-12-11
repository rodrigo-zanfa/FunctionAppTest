using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionAppTest
{
    public class Cron5Mins
    {
        private readonly ILogger _logger;

        public Cron5Mins(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Cron5Mins>();
        }

        [Function("Cron5Mins")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"---> C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"---> Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
