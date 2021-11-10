using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRHub.Hubs
{
    public interface ITestingHub
    {
         Task SendMessage(string message1, string message2);
    }
}
