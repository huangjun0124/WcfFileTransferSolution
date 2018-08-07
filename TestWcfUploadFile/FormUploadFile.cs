using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using TestWcfUploadFile.ServiceReference1;

namespace TestWcfUploadFile
{
    public partial class FormUploadFile : Form
    {
        public FormUploadFile()
        {
            InitializeComponent();
        }

        private string SelectFile()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() != DialogResult.OK) return null;
            return of.FileName;
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string fileName = SelectFile();
            if(string.IsNullOrEmpty(fileName)) return;
            this.Cursor = Cursors.WaitCursor;
            FileStream stream = File.OpenRead(fileName);
            IUpLoadService service = new UpLoadServiceClient();
            var req = new FileUploadMessage(fileName.Substring(0, fileName.LastIndexOf('.')), "", stream);
            service.UploadFile(req);
            stream.Close();
            this.Cursor = Cursors.Default;
            MessageBox.Show("文件上传到服务器成功", "上传WCF", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInvokeByHand_Click(object sender, EventArgs e)
        {
            string fileName = SelectFile();
            if (string.IsNullOrEmpty(fileName)) return;
            this.Cursor = Cursors.WaitCursor;
            FileStream stream = File.OpenRead(fileName);
            var req = new FileUploadMessage(fileName.Substring(fileName.LastIndexOf('\\')+1), "", stream);

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            binding.MaxReceivedMessageSize = 9223372036854775807;
            binding.SendTimeout = new TimeSpan(0,0,10,0); // 设置十分钟超时

            IUpLoadService channel = ChannelFactory<IUpLoadService>.CreateChannel(binding,
                new EndpointAddress("http://localhost:62805/UpLoadService.svc"));

            using (channel as IDisposable)
            {
                channel.UploadFile(req);
                stream.Close();
                this.Cursor = Cursors.Default;
                MessageBox.Show("文件上传到服务器成功", "上传WCF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDownLoad1_Click(object sender, EventArgs e)
        {
            string fileName = SelectFile();
            if (string.IsNullOrEmpty(fileName)) return;
            this.Cursor = Cursors.WaitCursor;
            DownFileRequest req = new DownFileRequest(fileName);
            IUpLoadService svc = new UpLoadServiceClient();
            var res = svc.DownLoadFile(req);
            if (res.IsSuccess)
            {
                using (var fileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory+"\\"+fileName.Substring(fileName.LastIndexOf('\\')+1)) )
                {
                    CopyTo(res.FileStream, fileStream);
                }
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show(res.IsSuccess?"文件下载成功!":res.Message, "上传文件测试", MessageBoxButtons.OK,
                res.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Error);
        }

        public static void CopyTo(Stream input, Stream output)
        {
            byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
            int bytesRead;

            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }

        private void btnDownload2_Click(object sender, EventArgs e)
        {
            string fileName = SelectFile();
            if (string.IsNullOrEmpty(fileName)) return;
            this.Cursor = Cursors.WaitCursor;
            DownFileRequest req = new DownFileRequest(fileName);

            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            binding.MaxReceivedMessageSize = 9223372036854775807;

            IUpLoadService channel = ChannelFactory<IUpLoadService>.CreateChannel(binding,
                new EndpointAddress("http://localhost:62805/UpLoadService.svc"));

            using (channel as IDisposable)
            {
                var res = channel.DownLoadFile(req);
                if (res.IsSuccess)
                {
                    using (var fileStream = File.Create(AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName.Substring(fileName.LastIndexOf('\\') + 1)))
                    {
                        CopyTo(res.FileStream, fileStream);
                    }
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show(res.IsSuccess ? "文件下载成功!" : res.Message, "上传文件测试", MessageBoxButtons.OK,
                    res.IsSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }

        }
    }
}
