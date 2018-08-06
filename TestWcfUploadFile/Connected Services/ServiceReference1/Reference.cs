﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWcfUploadFile.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IUpLoadService")]
    public interface IUpLoadService {
        
        // CODEGEN: Generating message contract since the wrapper name (FileUploadMessage) of message FileUploadMessage does not match the default value (UploadFile)
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="UploadFile")]
        void UploadFile(TestWcfUploadFile.ServiceReference1.FileUploadMessage request);
        
        // CODEGEN: Generating message contract since the wrapper name (DownFileRequest) of message DownFileRequest does not match the default value (DownLoadFile)
        [System.ServiceModel.OperationContractAttribute(Action="DownLoadFile", ReplyAction="http://tempuri.org/IUpLoadService/DownLoadFileResponse")]
        TestWcfUploadFile.ServiceReference1.DownFileResult DownLoadFile(TestWcfUploadFile.ServiceReference1.DownFileRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileUploadMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FileUploadMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string SavePath;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileData;
        
        public FileUploadMessage() {
        }
        
        public FileUploadMessage(string FileName, string SavePath, System.IO.Stream FileData) {
            this.FileName = FileName;
            this.SavePath = SavePath;
            this.FileData = FileData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownFileRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownFileRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        public DownFileRequest() {
        }
        
        public DownFileRequest(string FileName) {
            this.FileName = FileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownFileResult", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownFileResult {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long FileSize;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public bool IsSuccess;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileStream;
        
        public DownFileResult() {
        }
        
        public DownFileResult(long FileSize, bool IsSuccess, string Message, System.IO.Stream FileStream) {
            this.FileSize = FileSize;
            this.IsSuccess = IsSuccess;
            this.Message = Message;
            this.FileStream = FileStream;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUpLoadServiceChannel : TestWcfUploadFile.ServiceReference1.IUpLoadService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UpLoadServiceClient : System.ServiceModel.ClientBase<TestWcfUploadFile.ServiceReference1.IUpLoadService>, TestWcfUploadFile.ServiceReference1.IUpLoadService {
        
        public UpLoadServiceClient() {
        }
        
        public UpLoadServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UpLoadServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpLoadServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UpLoadServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void TestWcfUploadFile.ServiceReference1.IUpLoadService.UploadFile(TestWcfUploadFile.ServiceReference1.FileUploadMessage request) {
            base.Channel.UploadFile(request);
        }
        
        public void UploadFile(string FileName, string SavePath, System.IO.Stream FileData) {
            TestWcfUploadFile.ServiceReference1.FileUploadMessage inValue = new TestWcfUploadFile.ServiceReference1.FileUploadMessage();
            inValue.FileName = FileName;
            inValue.SavePath = SavePath;
            inValue.FileData = FileData;
            ((TestWcfUploadFile.ServiceReference1.IUpLoadService)(this)).UploadFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TestWcfUploadFile.ServiceReference1.DownFileResult TestWcfUploadFile.ServiceReference1.IUpLoadService.DownLoadFile(TestWcfUploadFile.ServiceReference1.DownFileRequest request) {
            return base.Channel.DownLoadFile(request);
        }
        
        public long DownLoadFile(string FileName, out bool IsSuccess, out string Message, out System.IO.Stream FileStream) {
            TestWcfUploadFile.ServiceReference1.DownFileRequest inValue = new TestWcfUploadFile.ServiceReference1.DownFileRequest();
            inValue.FileName = FileName;
            TestWcfUploadFile.ServiceReference1.DownFileResult retVal = ((TestWcfUploadFile.ServiceReference1.IUpLoadService)(this)).DownLoadFile(inValue);
            IsSuccess = retVal.IsSuccess;
            Message = retVal.Message;
            FileStream = retVal.FileStream;
            return retVal.FileSize;
        }
    }
}
