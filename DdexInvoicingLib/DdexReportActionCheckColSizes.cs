using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportActionCheckColSizes : DdexReportActionBase
    {
        private Dictionary<string, int[]> maxColLengths = new Dictionary<string, int[]>();
        private Dictionary<string, string[]> longestColValues = new Dictionary<string, string[]>();

        private Dictionary<string, string> recToTableMap = new Dictionary<string, string>
        {
            { "HEAD","DdexRecordHead" }
            , { "FOOT","DdexRecordFoot" }
            , { "SY02.02","DdexRecordSy_02_02" }
            , { "AS01.01","DdexRecordAs" }
            , { "MW01.01","DdexRecordMw" }
            , { "SU03.02","DdexRecordSu" }
            , { "RU01.01","DdexRecordRu" }
            , { "LI01.02","DdexRecordLi" }
        };

        public DdexReportActionCheckColSizes()
        {
       }

        private void UpdateFieldLengths(DdexRecordBase record)
        {
            if (!maxColLengths.ContainsKey(record.RecordId))
            {
                int[] fieldLengths = new int[record.fields.Length];
                string[] colValues = new string[record.fields.Length];
                for (int i = 0; i < fieldLengths.Length; i++)
                {
                    fieldLengths[i] = 0;
                }
                maxColLengths.Add(record.RecordId, fieldLengths);
                longestColValues.Add(record.RecordId, colValues);
            }
            int[] curFieldLengths = maxColLengths[record.RecordId];
            string[] curFieldValues = longestColValues[record.RecordId];
            for (int i = 0; i < curFieldLengths.Length; i++)
            {
                if(curFieldLengths[i] < record.fields[i].Length)
                {
                    curFieldLengths[i] = record.fields[i].Length;
                    curFieldValues[i] = record.fields[i];
                }
             }
        }
        private bool ValidateColSizes()
        {
            return false;
            bool haveSmallColumns = false;
            using (SqlConnection conn = new SqlConnection(report.ConnectString))
            {
                conn.Open();

                foreach (var pair in maxColLengths)
                {
                    string recordType = pair.Key;
                    var requiredColLengths = pair.Value;
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"select COLUMN_NAME, CHARACTER_MAXIMUM_LENGTH, DATA_TYPE
                        from INFORMATION_SCHEMA.COLUMNS
                        where TABLE_NAME = @TableName
                        order by ORDINAL_POSITION";

                        cmd.Parameters.Add(new SqlParameter("@TableName", recToTableMap[recordType]));
                        DataTable dtColInfo = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                da.Fill(dtColInfo);
                            }
                            catch (Exception ex)
                            {
                                Logger.WriteLine(ex.Message);
                                throw;
                            }
                        }

                        int i = recordType.Equals("HEAD") || recordType.Equals("FOOT") || recordType.Equals("SY02.02") || recordType.Equals("AS01.01")
                            ? 1 : recordType.Equals("RU01.01") || recordType.Equals("SU03.02") ? 2 : 3;
                        int fieldIndex = 1;
                        for (; fieldIndex < requiredColLengths.Length; i++, fieldIndex++)
                        {
                            DataRow colInfo = dtColInfo.Rows[i];
                            string colName = (string)colInfo[0];
                            int colSize = colInfo[1] == DBNull.Value ? 0 : (int)colInfo[1];
                            string colType = (string)colInfo[2];
                            string fieldValue = longestColValues[recordType][fieldIndex];
                            int requiredColLength = requiredColLengths[fieldIndex];
                            if (colType.Equals("nvarchar") && colSize < requiredColLength)
                            {
                                haveSmallColumns = true;
                                Logger.WriteLine($@"Розмір рядку {recordType.Replace('.', '_')}.{colName} треба збільшити з {colSize} до {requiredColLength} внаслідок значення {fieldValue}");
                            }
                        }
                    }
                }
            }
            return haveSmallColumns;
        }

        public override string GetDescription() { return "Перевіка достатності розміру колонок таблиць"; }

        public override void ProcessHead(HEADRecordGoogle record)
        {
            UpdateFieldLengths(record);
        }
        public override void ProcessFoot(FOOTRecord record)
        {
            UpdateFieldLengths(record);
            if (ValidateColSizes())
                throw new Exception("Необхідно збільшити розмір колонок таблиць.");
        }
        public override void ProcessSY_02_02(SYRecord_02_02 record)
        {
            UpdateFieldLengths(record);
        }
        public override void ProcessBlock(DdexReportBlock block)
        {
            UpdateFieldLengths(block.asRecord);
            UpdateFieldLengths(block.canonicalMwRecord);
            foreach(var ruRecord in block.ruRecords)
            {
                UpdateFieldLengths(ruRecord);
            }
            foreach (var suRecord in block.suRecords)
            {
                UpdateFieldLengths(suRecord);
                foreach(var liRecord in suRecord.liRecords)
                {
                    UpdateFieldLengths(liRecord);
                    UpdateFieldLengths(liRecord.mwRecord);
                }
            }
        }

        
    }
}
