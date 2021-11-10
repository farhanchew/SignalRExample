using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Hubs
{
    public class TestingHub : Hub<ITestingHub>
    {
        public async Task SendMessage(string message1, string message2)
        {
            await Clients.All.SendMessage(message1, message2);
        }
        
    }
}
