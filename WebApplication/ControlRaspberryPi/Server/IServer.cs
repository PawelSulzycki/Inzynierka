using System.ServiceModel;

namespace ControlRaspberryPi.Server
{
    [ServiceContract]
    public interface IServer
    {
        [OperationContract]
        string Hello();
        [OperationContract]
        string Light(string name, int index);
        [OperationContract]
        int State(int index);
    }
}