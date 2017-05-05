using System;
using System.ServiceModel;
using Raspberry.IO.GeneralPurpose;

namespace ServerWcf
{
	[ServiceContract]
	public interface IServer
	{
		[OperationContract]
		string Hello ();

		[OperationContract]
		string Light(string name, int index);

		[OperationContract]
		int State (int index);
	}
}

