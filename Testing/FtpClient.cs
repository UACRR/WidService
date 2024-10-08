using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Testing
{
    internal class FtpClient
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


        private string _url;
        private string _login;
        private string _password;
        private bool _enableSsl;
        public FtpClient(string url, string login, string password, bool enableSsl = false)
        {
            _url = url;
            _login = login;
            _password = password;
            _enableSsl = enableSsl;
        }
        public List<string> ReadDirectory(string targetPath)
        {
            var credentials = new NetworkCredential(_login, _password);
            FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{targetPath}");
            listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
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

        public List<string> ReadDirectoryFiles(string targetPath)
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

        public long ReadFileSize(string ftpPath, string fileName)
        {
            var credentials = new NetworkCredential(_login, _password);
            FtpWebRequest fileSizeRequest = (FtpWebRequest)WebRequest.Create($"{_url}/{ftpPath}/{fileName}");
            fileSizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            fileSizeRequest.Credentials = credentials;
            fileSizeRequest.EnableSsl = _enableSsl;
            var response = fileSizeRequest.GetResponse();
            return response.ContentLength;
        }

        public void DownloadFile(string ftpPath, string fileName, string localPath)
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
                using (Stream targetStream = File.Create(Path.Combine(localPath, Path.GetFileName(fileName))))
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

        public bool FileExists(string ftpPath, string fileName)
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

        public bool HasAccess(string ftpFullPath)
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

        private void InvokeEvent(FtpEventType eventType, object eventInfo)
        {
            FtpEvent?.Invoke(this,
                new FtpEventArgs
                {
                    EventType = eventType,
                    EventInfo = eventInfo,
                });
        }
    }
}
