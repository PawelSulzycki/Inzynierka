using System;
using Raspberry.IO.GeneralPurpose;
namespace ServerWcf
{
	public class Led
	{
		public GpioConnection connection;
		OutputPinConfiguration led1;
		public Led (OutputPinConfiguration pin)
		{
			led1 = pin;
			connection = new GpioConnection(led1);
		}
		public void TurnON(GpioConnection connection)
		{
			this.connection.Toggle (led1);
		}
		public void TurnOff(GpioConnection connection)
		{
			this.connection.Close ();
		}

	}
}

