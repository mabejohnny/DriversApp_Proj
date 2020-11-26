using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using TruckDriverApp.Hubs;

namespace TruckDriverApp.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IHubContext<SmsHub> HubContext { get; set; }

        public SmsController(IHubContext<SmsHub> hub)
        {
            HubContext = hub;
        }

        [HttpPost("webhooks/inbound-sms")]
        public async Task<IActionResult> InboundSms()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var json = await reader.ReadToEndAsync();
                //var inbound = JsonConvert.DeserializeObject<InboundSms>(json);
                //await HubContext.Clients.All.SendAsync("InboundSms", inbound.Msisdn, inbound.Text);
            }
            return NoContent();
        }
    }
}
