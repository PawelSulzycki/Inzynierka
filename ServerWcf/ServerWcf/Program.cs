using System;
using System.ServiceModel;

namespace ServerWcf
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Uri adres = new Uri("http://localhost:2223/Server");
			ServiceHost host = new ServiceHost (typeof(Server), adres);
			host.AddServiceEndpoint (typeof(IServer), new BasicHttpBinding (), adres);
			host.Open ();
			Console.WriteLine ("Serwer utworziny pomyslnie");
			Console.WriteLine ("http://192.168.0.30:2223/Server");
			Console.ReadLine ();
			host.Close ();
		}
	}
}
