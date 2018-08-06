using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Hosting;

namespace WcfFileUploadService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UpLoadService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UpLoadService.svc or UpLoadService.svc.cs at the Solution Explorer and start debugging.
    public class UpLoadService : IUpLoadService
    {
        public static void CopyTo(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        public DownFileResult DownLoadFile(DownFileRequest fileRequest)
        {
            DownFileResult msg = new DownFileResult();
            string fileName = fileRequest.FileName;
            if (!File.Exists(fileName))
            {
                msg.IsSuccess = false;
                msg.FileSize = 0;
                msg.Message = "服务器不存在此文件";
                msg.FileStream = new MemoryStream();
                return msg;
            }

            Stream ms = new MemoryStream();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            CopyTo(fs, ms);
            ms.Position = 0;  //重要，不为0的话，客户端读取有问题
            
            msg.IsSuccess = true;
            msg.FileSize = ms.Length;
            msg.FileStream = ms;
            fs.Flush();
            fs.Close();
            return msg;
        }

        public void UploadFile(FileUploadMessage request)
        {
            string dateString = DateTime.Now.ToShortDateString() + @"\";
            string fileName = request.FileName;
            Stream sourceStream = request.FileData;
            FileStream targetStream = null;

            if (!sourceStream.CanRead)
            {
                throw new Exception("数据流不可读!");
            }

            string uploadFolder = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string filePath = Path.Combine(uploadFolder, fileName);
            using (targetStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //read from the input stream in 4K chunks
                //and save to output stream
                const int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int count = 0;
                while ((count = sourceStream.Read(buffer, 0, bufferLen)) > 0)
                {
                    targetStream.Write(buffer, 0, count);
                }
                targetStream.Close();
                sourceStream.Close();
            }
        }

    }
}
