using System;
using Raspberry.IO.GeneralPurpose;
namespace ServerWcf
{
	public class Server:IServer
	{
		private static int[] _state = new int[5]{0,0,0,0,0}; 
		private OutputPinConfiguration[] namePin = {
			ConnectorPin.P1Pin07.Output (),
			ConnectorPin.P1Pin11.Output (),
			ConnectorPin.P1Pin13.Output (),
			ConnectorPin.P1Pin15.Output (),
			ConnectorPin.P1Pin37.Output (),
		};
		public string Hello()
		{
			return "Hello World";
		}
		public string Light(string name, int index)
		{
			Led Led = new Led (namePin[index]);
			if (name == "ON") 
			{
				Led.TurnON (Led.connection);
				_state [index] = 1;
				//_state = true;
				return "swiatlo zostalo zapalone";
			}else
			{
				Led.TurnOff(Led.connection);
				//_state = false;
				_state [index] = 0;
				return "swiatlo  zgaszone";
			}

		}
		public int State(int index)
		{
			return _state[index];
	    }
	}
}

