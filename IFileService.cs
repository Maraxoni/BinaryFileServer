using CoreWCF;

namespace BinaryFileServer
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        string Echo(string text);
        [OperationContract]
        Stream DownloadImage(string name);
    }
}
