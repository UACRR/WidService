using Microsoft.Data.SqlClient;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static WidServiceLib.EntityInfo;
using static WidServiceLib.WidService;

namespace WidServiceLib
{
    public class EntityBulkLoader
    {
        public string FilePath { get; set; }
        public int CommitBatchSize { get; set; } = 10000;
        public SqlConnection Conn { get; set; }
        public SqlBulkCopyOptions options = 
                          SqlBulkCopyOptions.TableLock
                        | SqlBulkCopyOptions.FireTriggers
                        | SqlBulkCopyOptions.UseInternalTransaction
                        //| SqlBulkCopyOptions.KeepIdentity
                        | SqlBulkCopyOptions.CheckConstraints;

        private DataTable dt;
        private SqlBulkCopy bulkCopy;

        private string fileFullName = "";
        private List<string> wrongLines = new List<string>();
        private StringWriter bufferedLines = null;
        private long totalBytes = 0;
        private long loadedBytes = 0;
        private long loadedBytesPortion = 0;

        private static string[] ParseSpecial(string fieldsString)
        {
            var firstPos = 0;
            int lastPos;
            var retVal = new List<string>();
            while (true)
            {
                if (firstPos >= fieldsString.Length)
                {
                    retVal.Add("");
                    break;
                }
                else if (fieldsString[firstPos] == '"')
                {
                    lastPos = fieldsString.IndexOf('"', firstPos + 1);
                    while (lastPos < fieldsString.Length - 1 && fieldsString[lastPos + 1] == '"')
                    {
                        lastPos = fieldsString.IndexOf('"', lastPos + 2);
                    }
                    retVal.Add(fieldsString.Substring(firstPos, lastPos - firstPos));
                    firstPos = lastPos + 2;
                    if (firstPos >= fieldsString.Length)
                        break;
                }
                else
                {
                    lastPos = fieldsString.IndexOf('\t', firstPos);
                    if (lastPos == -1)
                    {
                        retVal.Add(fieldsString.Substring(firstPos));
                        break;
                    }
                    else
                    {
                        retVal.Add(fieldsString.Substring(firstPos, lastPos - firstPos));
                        firstPos = lastPos + 1;
                    }
                }
            }
            return retVal.ToArray();
        }

        private static string[] ParseFieldsString(string fieldsString, int fieldsCnt)
        {
            var fields = fieldsString.Split('\t');
            if (fields.Length != fieldsCnt)
            {
                fields = ParseSpecial(fieldsString);
                if (fields.Length != fieldsCnt)
                {
                    //wrongLines.Add(fieldsString);
                    return null;
                }
            }
            for (int i = 0; i < fields.Length; i++)
            {
                if (!string.IsNullOrEmpty(fields[i]) && fields[i][0] == '"' && fields[i].Length > 1)
                {
                    fields[i] = fields[i].Substring(1, fields[i].Length - 2);
                    fields[i] = fields[i].Trim('\t');
                    fields[i] = fields[i].Replace("\t", " ");
                    fields[i] = fields[i].Replace("\"\"", "\"");
                }
            }
            return fields;
        }
        private void AddData(EntityInfoEntry info, string fieldsString, ActionInProgress actionInProgress)
        {
           //try
            {
                DataRow row = dt.NewRow();
                var expectedFeldsCount = info.entityPropInfoList.Count - 1;
                var fields = ParseFieldsString(fieldsString, expectedFeldsCount);
                if(fields == null)
                {
                    wrongLines.Add(fieldsString);
                    return;
                }

                //fields[0] = loadedBytes.ToString();
                //fields[1] = "218030";

                List<object> data = new List<object>();
                row[0] = 0; // Id
                int colIndex = 1;
                for (int i = 0; i < fields.Length; i++)
                {
                    var fieldValue = fields[info.entityPropInfoList[i + 1].seqNrInFile];
                    if (info.entityPropInfoList[i + 1].fieldConverter == null)
                        row[colIndex] = fieldValue;
                    else
                        row[colIndex] = info.entityPropInfoList[i + 1].fieldConverter(fieldValue);
                    colIndex++;
                }
                dt.Rows.Add(row);
                bufferedLines.WriteLine(fieldsString);
                loadedBytes += fieldsString.Length;
                loadedBytesPortion += fieldsString.Length;
            }
            /*catch (Exception)
            {
                Console.WriteLine("Error in AddData");
                Console.WriteLine("Input String:");
                Console.WriteLine(fieldsString);
                Console.WriteLine("Parsed Fields:");
                fields
                throw;
            }*/

            if (dt.Rows.Count == CommitBatchSize)
            {
                Flush(actionInProgress);
            }

        }
        private void Flush(ActionInProgress actionInProgress)
        {
            if (dt == null) // no rows inserted
                return;
            BulkInsert(dt);
            dt.Rows.Clear();
            bufferedLines = new StringWriter();
            var portionPercents = 100 * Convert.ToDouble(loadedBytesPortion) / totalBytes;
            if (portionPercents > 1)
            {
                var totalPercents = 100 * Convert.ToDouble(loadedBytes) / totalBytes;
                if(actionInProgress != null)
                {
                    actionInProgress(totalPercents);
                }
                loadedBytesPortion = 0;
            }
        }
        private void BulkInsert(DataTable dt)
        {
            try
            {
                bulkCopy.WriteToServer(dt);
            }
            catch (Exception)
            {
                File.WriteAllText($"{fileFullName}.err.txt", bufferedLines.ToString());
                throw;
            }
        }

        private void WriteProgressToConsole(double percentDone)
        {
            Console.WriteLine($"{percentDone} done");
        }

        public void LoadSingle(string entityName, ActionInProgress actionInProgress)
        {
            var info = GetEntityInfoEntry(entityName);

            bulkCopy = new SqlBulkCopy(
                Conn,
                options,
                null
            );
            bulkCopy.BulkCopyTimeout = 0;
            bulkCopy.DestinationTableName = info.tableName;
            info.entityPropInfoList.ForEach(epi =>
            {
                bulkCopy.ColumnMappings.Add(epi.propertyInfo.Name, epi.propertyInfo.Name);
            });

            dt = new DataTable();
            for(var i = 0; i < info.entityPropInfoList.Count; i++)
            {
                var seqNr = info.entityPropInfoList[i].seqNrInFile;
                if(seqNr == -1) // Id column
                {
                    dt.Columns.Add("Id", typeof(int));
                    continue;
                }

                var epi = info.entityPropInfoList[i];
                var UnderlyingType = Nullable.GetUnderlyingType(epi.propertyInfo.PropertyType);
                if (UnderlyingType == null)
                    dt.Columns.Add(epi.propertyInfo.Name, epi.propertyInfo.PropertyType);
                else
                    dt.Columns.Add(epi.propertyInfo.Name, UnderlyingType);
            }

            bufferedLines = new StringWriter();
            fileFullName = Path.Combine(FilePath, info.fileName);
            //fileFullName = $"{FilePath}{fileName}.err.txt";
            FileInfo fi = new FileInfo(fileFullName);
            totalBytes = fi.Length;
            loadedBytes = 0;
            loadedBytesPortion = 0;

            using (StreamReader r = new StreamReader(fileFullName))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
                    AddData(info, line, actionInProgress);
                }
                Flush(actionInProgress);
            }
        }

        public void LoadAll()
        {
            int i = 0;
            EntityInfo.GetEntityNames().ForEach(entityName =>
            {
                if (i >= 0)
                    LoadSingle(entityName, WriteProgressToConsole);
                i++;
            });
        }

    }
}
