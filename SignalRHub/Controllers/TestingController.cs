using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRHub.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHub.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestingController : ControllerBase
    {
        private readonly IHubContext<TestingHub, ITestingHub> _hub;

        public TestingController(IHubContext<TestingHub, ITestingHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public async Task<ActionResult<string>> BroadcastMessage(string message1, string message2)
        {

            await _hub.Clients.All.SendMessage(message1, message2);
            return Ok(message1);
        }
    }
}
