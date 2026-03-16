using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WidSubmit.UcSubmProcessControl;
using System.Windows.Forms;
using WidSubmit.Implementation;
using System.Configuration;
using System.IO;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO.Compression;

namespace WidSubmit
{
    public class SubmActionRunner
    {
        public static bool SubmHasReadyWorks()
        {
            var res = false;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.fnSubmHasReadyWorks()";
                res = (bool)cmd.ExecuteScalar();
            });
            return res;
        } 
        
        public static bool SubmFileExists()
        {
            var res = false;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select dbo.fnSubmFileExists()";
                res = (bool)cmd.ExecuteScalar();
            });
            return res;
        } 
        
        public static void UpdateFromMs()
        {
            if(SubmFileUploaded())
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Оновлення інформації не дозволене - файл був викладений на FTP, але процес передачі не був завершений. Повторіть передачу файлу.",
                        "Публікація творів",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSubmWorksUpdate";
                cmd.ExecuteNonQuery();
            });
        }
        
        public static void CreateSubmFile()
        {
            var hasReadyWorks = SubmHasReadyWorks();

            if (!hasReadyWorks)
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Відсутні твори для передачі, файл не буде створений.",
                        "Публікація творів",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            var submFileExists = SubmFileExists();
            if (submFileExists)
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Підготовлений до передачі в WID файл вже створений. Замінити його на новий?",
                        "Публікація творів",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning))
                {
                    return;
                }
            }

            if(SubmFileUploaded())
            {
                if (DialogResult.Yes !=
                    MessageBox.Show("Зміна файлу не дозволена - файл був викладений на FTP, але процес передачі не був завершений. Повторіть передачу файлу.",
                        "Публікація творів",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    return;
                }
            }
            
            var writer = new SubmFileWriter();
            writer.CreateSubmFile();
        }   

        public static async Task CreateAndSendSubmFile()
        {
            if (DialogResult.Yes != MessageBox.Show("Передати файл публікації?", "Публікація творів", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            var submFileName = "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select SubmFileName from Submission where Id = dbo.fnCurSubmId()";
                submFileName = (string)cmd.ExecuteScalar();
            });

            // ЗАПОБІЖНИК - не чіпаємо вже переданий файл.
            if(SubmFileUploaded())
            {
                return;
            }

            // Створюємо і передаємо файл
            var writer = new SubmFileWriter();
            submFileName =  writer.CreateSubmFile();

            var appSettings = ConfigurationManager.AppSettings;
                
            var folderPath = Path.Combine(appSettings["FileExchangeRootDir"], "OutFiles");
            var sourceFile = Path.Combine(folderPath, submFileName);

            var wrongLineIdx = FileValidator.Validate(sourceFile);
            if(wrongLineIdx.Count() != 0)
            {
                MessageBox.Show("Файл містить помилки", "Файли обміну", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            await UploadFile(submFileName);
        } 

        public static string CheckSubmDeclined()
        {
            var submFileName = "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select SubmFileName from Submission where Id = dbo.fnCurSubmId()";
                submFileName = (string)cmd.ExecuteScalar();
            });

            var appSettings = ConfigurationManager.AppSettings;
            var ftpClient = new FtpClient(
                appSettings["FileExchangeFtpErrorDir"],
                appSettings["FileExchangeFtpLogin"],
                appSettings["FileExchangeFtpPassword"]
            );
            var ftpFiles = ftpClient.ReadDirectoryFiles("").ToList();
            return ftpFiles.Any(x => x.ToUpper().Contains(submFileName.ToUpper())) ? submFileName : "";

         }

        public static string DownloadRespFile()
        {
            // Знаходимо в БД назву поточного файлу публікації і останнього прийнятого файлу відповіді
            var curSubmFileName = "";
            var lastRespFileName = "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select SubmFileName from Submission where Id = dbo.fnCurSubmId()";
                curSubmFileName = (string)cmd.ExecuteScalar();

                cmd.CommandText = "select max(RespFileName) from Submission";
                lastRespFileName = (string)cmd.ExecuteScalar();
            });

            //!!!!!!!!!!!!!!!!!!!! Для тестування
            curSubmFileName = "WID2026031507242653300140.021";

            // Завантажуємо з ФТП повний перелік файлів відповіді
            var appSettings = ConfigurationManager.AppSettings;
            var ftpClient = new FtpClient(
                appSettings["FileExchangeFtpRespDir"],
                appSettings["FileExchangeFtpLogin"],
                appSettings["FileExchangeFtpPassword"]
            );
            var ftpFileNames = ftpClient.ReadDirectoryFiles("");
            
            // Серед завантаженого переліку вибираємо назви файлів, які створені пізніше останнього прийнятого
            var ftpCandidateFileNames = new List<string>();
            ftpFileNames.ForEach(fileName =>
            {
                // Прибираємо розширення у запакованих файлах
                var fileNameNoGz = fileName;
                if(Path.GetExtension(fileName).ToLower() == ".gz")
                {
                    fileNameNoGz = Path.GetFileNameWithoutExtension(fileName);
                }

                // Про всяк випадок перевіряємо що назва файлу відповідає файлу відповіді
                if(Path.GetExtension(fileNameNoGz).ToLower() == ".021")
                {
                    // Після чого додаємо файл якщо він старший за останній файл відповіді
                    if(string.Compare(fileName, lastRespFileName) > 0)
                    {
                        ftpCandidateFileNames.Add(fileName);
                    }
                }
            });

            // Шукаємо файл відповіді який відповідає файлу публікації
            var retVal = ""; // якщо файл не знайдений
            foreach(var fileName in ftpCandidateFileNames)
            {
                // Сперш завантажуємо файл з ФТП (ftpClient вже налаштований на фолдер файлів відповіді)
                var targetDir = Path.Combine(appSettings["FileExchangeRootDir"], "RespFiles");
                ftpClient.DownloadFile("", fileName, targetDir);

                // За потреби розпаковуємо файл
                var targetFileNameFull = Path.Combine(targetDir, fileName);
                if(Path.GetExtension(fileName).ToLower() == ".gz")
                {
                    var sourceFileNameFull = Path.Combine(targetDir, fileName);
                    var targetFileName = Path.GetFileNameWithoutExtension(fileName);
                    targetFileNameFull = Path.Combine(targetDir, targetFileName);
                    Helpers.DecompressFile(sourceFileNameFull, targetFileNameFull);
                    File.Delete(sourceFileNameFull);
                }
                
                // Аналізуємо перший рядок файла відповіді на відповідність поточнму файлу публікації
                using(StreamReader reader = new StreamReader(targetFileNameFull))
                {
                    var lineRecHdr = reader.ReadLine();
                    if(lineRecHdr != null && lineRecHdr.Length < 131) // Запобігаємо аналізу невірного файлу
                    {
                        var submFileNameInResp = lineRecHdr.Substring(101 /*102 - 1*/, 29);
                        if(submFileNameInResp.ToLower() == curSubmFileName.ToLower())
                        {
                            retVal = Path.GetFileName(targetFileNameFull);
                            break;
                        }
                    }
                }
    
            };

            return retVal;
        }

        public static void ApplyRespFile()
        {
            var reader = new RespFileReader();
            reader.ApplyRespFile();
            //reader.ReadRespFile("WID20260219194138140300.021");
        }

        public static void CloseSubm()
        {
            Helpers.RunSqlSocWidSubmitExT(cmd => {
                // Попередньо встановлюэмо статус заверешено, якщо процедура завершиться з помилками статус не буде застосовано
                cmd.CommandText = "update Submission set SubmissionStatusId = @status where Id = dbo.fnCurSubmId()";
                cmd.Parameters.AddWithValue("@status", SubmStatusEnum.COMPLETED);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSubmClose";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();
            });
        }

        private static bool SubmFileUploaded()
        {
            var submFileName = "";
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select SubmFileName from Submission where Id = dbo.fnCurSubmId()";
                submFileName = (string)cmd.ExecuteScalar();
            });

            if(submFileName.Trim() == "")
            {
                return false;
            }

            var appSettings = ConfigurationManager.AppSettings;

            var targetFile = $"{appSettings["FileExchangeFtpSubmDir"]}/{submFileName}";
            FtpWebRequest fileSizeRequest = (FtpWebRequest)WebRequest.Create($"{targetFile}");
            fileSizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
            fileSizeRequest.Credentials = new NetworkCredential(appSettings["FileExchangeFtpLogin"], appSettings["FileExchangeFtpPassword"]);

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

        private static async Task UploadFile(string submFileName)
        {
            var appSettings = ConfigurationManager.AppSettings;

            var targetFile = $"{appSettings["FileExchangeFtpSubmDir"]}/{submFileName}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetFile);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(appSettings["FileExchangeFtpLogin"], appSettings["FileExchangeFtpPassword"]);

            var folderPath = Path.Combine(appSettings["FileExchangeRootDir"], "OutFiles");
            var sourceFile = Path.Combine(folderPath, submFileName);

            using (FileStream fileStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read))
            {
                using (Stream requestStream = request.GetRequestStream())
                {
                    await fileStream.CopyToAsync(requestStream);
                }
            }
            FtpStatusCode statusCode;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                statusCode = response.StatusCode;
            }
        }

    }

 

}
