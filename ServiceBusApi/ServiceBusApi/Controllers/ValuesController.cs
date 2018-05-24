using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private const string ServiceBusConnectionString = "";
        private const string QueueName = "queue1";
        private IQueueClient queueClient;

        public ValuesController()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
        }

        [HttpGet]
        public async Task<IActionResult> PutMessage(string message)
        {
           var queueMessage = new Message(Encoding.UTF8.GetBytes($"{message} (Added = {DateTime.UtcNow})"));

            // Send the message to the queue.
            await queueClient.SendAsync(queueMessage);
            await queueClient.CloseAsync();

            return Content("asdasd");
        }
    }
}