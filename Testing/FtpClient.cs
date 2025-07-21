using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Messaging;
using Renci.SshNet;
using static System.Net.WebRequestMethods;

namespace Testing
{
    internal class FtpClient
    {
        public class FtpConnectorBase
        {
            public enum FtpEventType
            {
                FileDownloadStarted = 0,
                FileDownloadInProgress = 1,
                FileDownloadCompleted = 2,
                FileDownloadFailed = 3,
            }

            public class FtpEventArgs
            {
                public FtpEventType EventType { get; set; }
                public object EventInfo { get; set; }
            }

            public event EventHandler<FtpEventArgs> FtpEvent;

            protected string _url;
            protected string _login;
            protected string _password;
            protected int _port;
            protected bool _enableSsl;

            public FtpConnectorBase(string url, string login, string password, int port, bool enableSsl = false)
            {
                _url = url;
                _login = login;
                _password = password;
                _port = port;
                _enableSsl = enableSsl;

            }

            protected void InvokeEvent(FtpEventType eventType, object eventInfo)
            {
                FtpEvent?.Invoke(this,
                    new FtpEventArgs
                    {
                        EventType = eventType,
                        EventInfo = eventInfo,
                    });
            }

            public virtual List<string> ReadDirectory(string targetPath) { return null; }
            public virtual List<string> ReadDirectoryFiles(string targetPath) { return null; }
            public virtual long ReadFileSize(string ftpPath, string fileName) { return 0; }
            public virtual void DownloadFile(string ftpPath, string fileName, string localPath) { }
            public virtual bool FileExists(string ftpPath, string fileName) { return false; }
            public virtual bool HasAccess(string ftpFullPath) { return false; }
            
        }

        public class FtpConnector: FtpConnectorBase
        {
            public FtpConnector(string url, string login, string password, int port, bool enableSsl = false) :
                base(url, login, password, port, enableSsl)
            {
            }
        
            public override List<string> ReadDirectory(string targetPath)
            {
                var credentials = new NetworkCredential(_login, _password);
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{targetPath}");
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                listRequest.Credentials = credentials;
                listRequest.EnableSsl = false;
                List<string> lines = new List<string>();
                using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        var line = listReader.ReadLine();
                        lines.Add(line);
                    }
                }
                return lines;
            }

            public override List<string> ReadDirectoryFiles(string targetPath)
            {
                var credentials = new NetworkCredential(_login, _password);
                FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{targetPath}");
                listRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                listRequest.Credentials = credentials;
                listRequest.EnableSsl = _enableSsl;
                List<string> lines = new List<string>();
                using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        var line = listReader.ReadLine();
                        lines.Add(line);
                    }
                }
                return lines;
            }

            public override long ReadFileSize(string ftpPath, string fileName)
            {
                var credentials = new NetworkCredential(_login, _password);
                FtpWebRequest fileSizeRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{ftpPath}/{fileName}");
                fileSizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                fileSizeRequest.Credentials = credentials;
                fileSizeRequest.EnableSsl = _enableSsl;
                var response = fileSizeRequest.GetResponse();
                return response.ContentLength;
            }

            public override void DownloadFile(string ftpPath, string fileName, string localPath)
            {
                InvokeEvent(FtpEventType.FileDownloadStarted, 0);

                try
                {
                    var fileSize = ReadFileSize(ftpPath, fileName);

                    var credentials = new NetworkCredential(_login, _password);
                    var ftpFullPath = $"{_url}/{ftpPath}/{fileName}";
                    FtpWebRequest downloadRequest = (FtpWebRequest)WebRequest.Create(ftpFullPath);
                    downloadRequest.Credentials = credentials;
                    downloadRequest.EnableSsl = _enableSsl;
                    downloadRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                    Directory.CreateDirectory(localPath);

                    using (FtpWebResponse downloadResponse =
                              (FtpWebResponse)downloadRequest.GetResponse())
                    using (Stream sourceStream = downloadResponse.GetResponseStream())
                    using (Stream targetStream = System.IO.File.Create(Path.Combine(localPath, Path.GetFileName(fileName))))
                    {
                        var accBytesRead = 0;
                        var totalBytesRead = 0.0;
                        var bytesInOnePercent = fileSize / 100.00;
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            targetStream.Write(buffer, 0, read);
                            accBytesRead += read;
                            totalBytesRead += read;
                            if (accBytesRead > bytesInOnePercent)
                            {
                                InvokeEvent(FtpEventType.FileDownloadInProgress, 100 * Convert.ToDouble(totalBytesRead) / fileSize);
                                accBytesRead = 0;
                            }
                        }
                    }
                    InvokeEvent(FtpEventType.FileDownloadCompleted, 0);
                }
                catch (Exception ex)
                {
                    InvokeEvent(FtpEventType.FileDownloadFailed, ex.Message);
                }
            }

            public override bool FileExists(string ftpPath, string fileName)
            {
                var credentials = new NetworkCredential(_login, _password);
                FtpWebRequest fileSizeRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{ftpPath}/{fileName}");
                fileSizeRequest.Credentials = credentials;
                fileSizeRequest.EnableSsl = _enableSsl;
                fileSizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;

                try
                {
                    FtpWebResponse response = (FtpWebResponse)fileSizeRequest.GetResponse();
                    return true;
                }
                catch (WebException ex)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        return false;
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            public override bool HasAccess(string ftpFullPath)
            {
                try
                {
                    var credentials = new NetworkCredential(_login, _password);
                    FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(ftpFullPath);
                    listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    listRequest.Credentials = credentials;
                    listRequest.EnableSsl = _enableSsl;
                    using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
                    using (Stream listStream = listResponse.GetResponseStream())
                    using (StreamReader listReader = new StreamReader(listStream))
                    {
                        if (!listReader.EndOfStream)
                        {
                            listReader.ReadLine();
                        }
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        
        public class SftpConnector: FtpConnectorBase
        {
            public SftpConnector(string url, string login, string password, int port, bool enableSsl = false) :
                base(url, login, password, port, enableSsl)
            {
            }
        
            public override List<string> ReadDirectory(string targetPath)
            {
                var lines = new List<string>();

                using (var client = new SftpClient(_url, _port, _login, _password))
                {
                    client.Connect();
                    foreach (var item in client.ListDirectory(targetPath))
                    {
                        lines.Add(item.Name);
                        //using (Stream fileStream = System.IO.File.Create($@"c:\UACRR\WID_Service\ReplicationWorkFiles\Ipi\{item.Name}"))
                        //{
                            //client.DownloadFile($"IPI/download/{item.Name}", fileStream);
                        //}
                    }
                }

                return lines;
            }

            public override List<string> ReadDirectoryFiles(string targetPath)
            {
                var lines = new List<string>();

                using (var client = new SftpClient(_url, _port, _login, _password))
                {
                    client.Connect();
                    foreach (var item in client.ListDirectory(targetPath))
                    {
                        if(!item.IsDirectory) lines.Add(item.Name);
                    }
                }

                return lines;
            }

            public override long ReadFileSize(string ftpPath, string fileName)
            {
                using (var client = new SftpClient(_url, _port, _login, _password))
                {
                    client.Connect();
                    var fileFullName = $"{ftpPath}/{fileName}";
                    var res = client.Get(fileFullName);
                    return res.Length;
                }
             }

            public override void DownloadFile(string ftpPath, string fileName, string localPath)
            {
                
                InvokeEvent(FtpEventType.FileDownloadStarted, 0);  
 
                try
                {
                
                    using (var client = new SftpClient(_url, _port, _login, _password))
                    {
                        client.Connect();
                        var fileFullName = $"{ftpPath}/{fileName}";
                        var fileSize = client.Get(fileFullName).Length;

                        Directory.CreateDirectory(localPath);

                        using (Stream fileStream = System.IO.File.Create(Path.Combine(localPath, Path.GetFileName(fileName))))
                        {
                            client.DownloadFile(fileFullName, fileStream, x =>
                            {
                                InvokeEvent(FtpEventType.FileDownloadInProgress, 100 * Convert.ToDouble(x) / fileSize);
                            });
                        }
                    }


                    InvokeEvent(FtpEventType.FileDownloadCompleted, 0);
                }
                catch (Exception ex)
                {
                    InvokeEvent(FtpEventType.FileDownloadFailed, ex.Message);
                }
            }

            public override bool FileExists(string ftpPath, string fileName)
            {
                using (var client = new SftpClient(_url, _port, _login, _password))
                {
                    client.Connect();                     
                    var fileFullName = $"{ftpPath}/{fileName}";
                    return client.Exists(fileFullName);
                }
            }

            public override bool HasAccess(string ftpFullPath)
            {
                try
                {
                    using (var client = new SftpClient(_url, _port, _login, _password))
                    {
                        client.Connect();
                        var res = client.ListDirectory(ftpFullPath);
                        return true;                    
                    }
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }

        private FtpConnectorBase _connector;

        public FtpClient(string url, string login, string password, int port, bool useSftp, bool enableSsl = false)
        {
            useSftp = true;
            if(useSftp)
            {
                url = "ftp.suisa.ch";
                login = "UACRR";
                password = "S0c-74084lXY-?";
                port = 22;
                enableSsl = false;
                _connector = new SftpConnector(url, login, password, port, enableSsl);
            }
            else
            {
                url = "ftp://ftp-aws.fasttrackdcn.net";
                login = "wid_140";
                password = "ad1WropKoPhlyb";
                port = 0;
                enableSsl = true;
                _connector = new FtpConnector(url, login, password, port, enableSsl);
            }

            var ftpPath = "IPI/IPI_Pub/Complete_IPI/20250531";
            var res = _connector.FileExists(ftpPath, "IPI01080.EDI.zip");

         }

        public List<string> ReadDirectory(string targetPath) => _connector.ReadDirectory(targetPath);
        public List<string> ReadDirectoryFiles(string targetPath) => _connector.ReadDirectoryFiles(targetPath);
        public long ReadFileSize(string ftpPath, string fileName) => _connector.ReadFileSize(ftpPath, fileName);
        public void DownloadFile(string ftpPath, string fileName, string localPath) => _connector.DownloadFile(ftpPath, fileName, localPath);
        public bool FileExists(string ftpPath, string fileName) => _connector.FileExists(ftpPath, fileName);
        public bool HasAccess(string ftpFullPath) => _connector.HasAccess(ftpFullPath);

    }
}
