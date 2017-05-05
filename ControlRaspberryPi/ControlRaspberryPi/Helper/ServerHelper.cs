using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Web;
using ControlRaspberryPi.Server;

namespace ControlRaspberryPi.Helper
{
    public class ServerHelper
    {
        private readonly EndpointAddress EndPoint = new EndpointAddress("http://192.168.0.30:2223/Server");
        //private readonly EndpointAddress EndPoint = new EndpointAddress("http://10.104.35.26:2223/Server");
        private static ServerHelper _instance;
        private IServer _serverWcf;

        private ServerHelper()
        {
            var connectionServer = new ChannelFactory<IServer>(
                 new BasicHttpBinding(),
                 EndPoint);
            _serverWcf = connectionServer.CreateChannel();
        }

        public static ServerHelper GetInstance()
        {
            if (_instance == null)
                _instance = new ServerHelper();

            return _instance;
        }

        public IServer GetServer()
        {
            return _serverWcf;
        }
    }
}