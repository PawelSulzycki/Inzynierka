using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ControlRaspberryPi.Helper;
using ControlRaspberryPi.Server;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace ControlRaspberryPi.Hubs
{
    [HubName("communication")]
    public class CommunicationHub : Hub<ICommunicationHub>
    {
        private static int[] message = new int[5] {0,0,0,0,0};

        public void SendCurrent(int index, int msg)
        {
            message[index] = msg;
            Clients.All.ShowCurrent(message);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public override Task OnConnected()
        {

            Clients.All.ShowCurrent(message);
            return base.OnConnected();
        }
    }

    public interface ICommunicationHub
    {
        void ShowCurrent(int[] msg);
    }

}