using System.IO;
using System.ServiceModel;

namespace WcfFileUploadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUpLoadService" in both code and config file together.
    [ServiceContract]
    public interface IUpLoadService
    {
        [OperationContract(Action = "UploadFile", IsOneWay = true)]
        void UploadFile(FileUploadMessage request);

        [OperationContract(Action = "DownLoadFile")]
        DownFileResult DownLoadFile(DownFileRequest fileName);
    }


    [MessageContract]
    public class FileUploadMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string SavePath;

        [MessageHeader(MustUnderstand = true)]
        public string FileName;

        [MessageBodyMember(Order = 1)]
        public Stream FileData;

    }

    [MessageContract]
    public class DownFileRequest
    {
        [MessageHeader]
        public string FileName { get; set; }
    }

    [MessageContract]
    public class DownFileResult
    {
        [MessageHeader]
        public long FileSize { get; set; }
        [MessageHeader]
        public bool IsSuccess { get; set; }
        [MessageHeader]
        public string Message { get; set; }
        [MessageBodyMember]
        public Stream FileStream { get; set; }
    }
}
