using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WidSubmit.Implementation
{
    public class RespFileReader
    {
        private string _fileName;
        private string _fileFullName;
        private int _submissionId;

        public void ApplyRespFile()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select RespFileName from Submission where Id = dbo.fnCurSubmId()";
                _fileName = (string)cmd.ExecuteScalar();
            });

            var folderPath = Path.Combine(ConfigurationManager.AppSettings["FileExchangeRootDir"], "RespFiles");
            _fileFullName = Path.Combine(folderPath, _fileName);

            FixRespFile();
            ReadRespFile();

            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spBindRespToSubm";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "spSubmWorksUpdateFromResp";
                cmd.ExecuteNonQuery();
            });
        }
        private void FixRespFile()
        {
            var linesIn = File.ReadAllLines(_fileFullName);
            var linesOut = new List<string>();

            int tranSeqNr = -1;
            var sb = new StringBuilder();
            linesIn.ToList().ForEach(line => {
                if(line.Trim() == "")
                    return;
                var recType = line.Substring(0, 3).ToUpper();
                switch(recType)
                {
                    case "HDR":
                    case "GRH":
                    case "GRT":
                    case "TRL":
                        linesOut.Add(line);
                        break;
                    case "ACK":
                    case "MSG":
                        if(recType == "ACK")
                            tranSeqNr++;
                        sb.Clear();
                        sb.Append(line);
                        sb.Remove(3, 8); 
                        sb.Insert(3, tranSeqNr.ToString("D8"));
                        linesOut.Add(sb.ToString());
                        break;
                }
            });

            File.WriteAllLines(_fileFullName, linesOut);
        }

        private void ReadRespFile()
        {
            var lines = File.ReadAllLines(_fileFullName);
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select dbo.fnCurSubmId()";
                _submissionId = (int)cmd.ExecuteScalar();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRespFileDataDelete";
                cmd.ExecuteNonQuery();

                var loaderAck = new BulkUploadToSql();
                loaderAck.conn = cmd.Connection;
                loaderAck.TableName = "Z_RecAck";

                var loaderMsg = new BulkUploadToSql();
                loaderMsg.conn = cmd.Connection;
                loaderMsg.TableName = "Z_RecMsg";
                
                lines.ToList().ForEach(line =>
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        return;
                    }

                    var entityType = GetEntityType(line);
                    if (entityType == null)
                    {
                        return;
                    }

                    var data = new List<object>();
                    data.Add(DBNull.Value);

                    if (entityType == typeof(RecAck))
                    {
                        data.Add(DBNull.Value);
                    }
                    else
                    {
                        data.Add(_submissionId);
                    }

                    data.AddRange(FieldValuesFromLine(entityType, line, 2));

                    if (entityType == typeof(RecAck))
                    {
                        loaderAck.AddData(data);
                    }
                    else
                    {
                        loaderMsg.AddData(data);
                    }

                });

                loaderAck.Flush();
                loaderMsg.Flush();
            });

            
        }

        private Type GetEntityType(string line)
        {
            var recType = line.Substring(0, 3);
            switch(recType)
            {
                case "ACK": return typeof(RecAck);
                case "MSG": return typeof(RecMsg);
                default: return null;
            }
        }

        private List<object> FieldValuesFromLine(Type t, string line, int startIdx)
        {
            var retVal = new List<object>();
            var piList = t.GetProperties();
            for (int i = startIdx; i < piList.Count(); i++)
            {
                var pi = piList[i];
                var posInFile = (CustomPosInFileAttribute)pi.GetCustomAttribute(typeof(CustomPosInFileAttribute));
                retVal.Add(line.Substring(posInFile.Start - 1, posInFile.Size).Trim());
            }
            return retVal;
        }
    }
}
